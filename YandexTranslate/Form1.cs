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
            this.Shown += (sender, e) =>
            {
                Init();
            };
        }

        private async void Init()
        {
            panel1.Resize += (sender, e) =>
            {
                var parent = (sender as Panel);
                var size = new Size(parent.Width / 2, parent.Height);
                sourceText.Size = size;
                destText.Size = size;
                destText.Location = new Point(size.Width, 0);
            };
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
        
        private async void Translate(string text)
        {
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

        private void translateButton_Click(object sender, EventArgs e)
        {
            Translate(sourceText.Text);
        }
    }
}
