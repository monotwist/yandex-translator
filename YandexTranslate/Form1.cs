using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace YandexTranslate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitEvents();
            InitVariables();
        }

        private void InitEvents()
        {
            panel1.Resize += (sender, e) =>
            {
                var parent = (sender as Panel);
                var size = new Size(parent.Width / 2, parent.Height);
                sourceText.Size = size;
                destText.Size = size;
                destText.Location = new Point(size.Width, 0);
            };

            sourceText.TextChanged += LiveTranslate;

            liveTranslateSwitch.CheckedChanged += (sender, e) =>
            {
                if ((sender as CheckBox).Checked)
                {
                    sourceText.TextChanged -= LiveTranslate;
                    sourceText.TextChanged += LiveTranslate;
                }
                else
                    sourceText.TextChanged -= LiveTranslate;
            };

            sourceLangSelector.SelectedIndexChanged += (sender, e) =>
            {
                var parent = sender as ComboBox;
                if (parent.SelectedIndex == 0)
                    swapLangButton.Enabled = false;
                else
                    swapLangButton.Enabled = true;
            };
        }

        private async void InitVariables()
        {
            ApiSettings.ApiKey = "trnsl.1.1.20180720T045104Z.3b603be702905c49.b19db5e51d21fcc36424800c088a9819a376f447"; //ну я хуй знает, в шарпе все равно не спрячешь
            var uiLang = CultureInfo.InstalledUICulture.TwoLetterISOLanguageName.ToString();
            translateButton.Text = uiLang == "ru" ? "Перевести" : "Translate";
            liveTranslateSwitch.Text = uiLang == "ru" ? liveTranslateSwitch.Text : "\"Live\" translate";
            var langs = await LanguageProvider.GetLanguages(uiLang);
            var langFullNames = langs.Values.ToList();
            langFullNames.Sort();
            destLangSelector.Items.AddRange(langFullNames.ToArray());
            langFullNames.Insert(0, uiLang == "ru" ? "Авто" : "Auto");
            sourceLangSelector.Items.AddRange(langFullNames.ToArray());
            sourceLangSelector.SelectedIndex = 0;
            destLangSelector.SelectedIndex = 0;
            translateButton.Enabled = true;
        }

        private async Task Translate(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            var srcFullName = sourceLangSelector.SelectedItem.ToString();
            var destFullName = destLangSelector.SelectedItem.ToString();



            var srcLang = LanguageProvider.FindCodeByFullName(srcFullName);
            if (srcFullName == "Auto" || srcFullName == "Авто")
                srcLang = await Translator.DetectLanguage(text);
            var destLang = LanguageProvider.FindCodeByFullName(destFullName);

            if (srcLang == null || destLang == null)
                return;

            var rT = await Translator.Translate(sourceText.Text, srcLang, destLang);

            destText.Text = rT;
        }

        private async void LiveTranslate(object sender, EventArgs e)
        {
            (sender as Control).TextChanged -= LiveTranslate;
            await Task.Delay(500);
            (sender as Control).TextChanged += LiveTranslate;
            await Translate(sourceText.Text);
        }

        private async void translateButton_Click(object sender, EventArgs e)
        {
            await Translate(sourceText.Text);
        }

        private void swapLangButton_Click(object sender, EventArgs e)
        {
            var srcIdx = sourceLangSelector.SelectedIndex;
            var destIdx = destLangSelector.SelectedIndex;

            sourceLangSelector.SelectedIndex = destIdx + 1;
            destLangSelector.SelectedIndex = srcIdx - 1;
        }
    }
}
