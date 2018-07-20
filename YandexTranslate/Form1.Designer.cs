namespace YandexTranslate
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.translateButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.destText = new System.Windows.Forms.TextBox();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.sourceLangSelector = new System.Windows.Forms.ComboBox();
            this.destLangSelector = new System.Windows.Forms.ComboBox();
            this.switchLangButton = new System.Windows.Forms.Button();
            this.liveTranslateSwitch = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // translateButton
            // 
            this.translateButton.Enabled = false;
            this.translateButton.Location = new System.Drawing.Point(9, 128);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(145, 89);
            this.translateButton.TabIndex = 0;
            this.translateButton.Text = "Перевести";
            this.translateButton.UseVisualStyleBackColor = true;
            this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.destText);
            this.panel1.Controls.Add(this.sourceText);
            this.panel1.Location = new System.Drawing.Point(160, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 208);
            this.panel1.TabIndex = 3;
            // 
            // destText
            // 
            this.destText.Location = new System.Drawing.Point(226, 0);
            this.destText.Multiline = true;
            this.destText.Name = "destText";
            this.destText.Size = new System.Drawing.Size(226, 208);
            this.destText.TabIndex = 1;
            // 
            // sourceText
            // 
            this.sourceText.Location = new System.Drawing.Point(0, 0);
            this.sourceText.Multiline = true;
            this.sourceText.Name = "sourceText";
            this.sourceText.Size = new System.Drawing.Size(226, 208);
            this.sourceText.TabIndex = 0;
            // 
            // sourceLangSelector
            // 
            this.sourceLangSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceLangSelector.FormattingEnabled = true;
            this.sourceLangSelector.Location = new System.Drawing.Point(9, 13);
            this.sourceLangSelector.Name = "sourceLangSelector";
            this.sourceLangSelector.Size = new System.Drawing.Size(145, 21);
            this.sourceLangSelector.TabIndex = 4;
            // 
            // destLangSelector
            // 
            this.destLangSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destLangSelector.FormattingEnabled = true;
            this.destLangSelector.Location = new System.Drawing.Point(9, 78);
            this.destLangSelector.Name = "destLangSelector";
            this.destLangSelector.Size = new System.Drawing.Size(145, 21);
            this.destLangSelector.TabIndex = 5;
            // 
            // switchLangButton
            // 
            this.switchLangButton.FlatAppearance.BorderSize = 0;
            this.switchLangButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.switchLangButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.switchLangButton.Location = new System.Drawing.Point(53, 40);
            this.switchLangButton.Name = "switchLangButton";
            this.switchLangButton.Size = new System.Drawing.Size(46, 32);
            this.switchLangButton.TabIndex = 6;
            this.switchLangButton.Text = "↑↓";
            this.switchLangButton.UseVisualStyleBackColor = true;
            // 
            // liveTranslateSwitch
            // 
            this.liveTranslateSwitch.AutoSize = true;
            this.liveTranslateSwitch.Checked = true;
            this.liveTranslateSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.liveTranslateSwitch.Location = new System.Drawing.Point(9, 105);
            this.liveTranslateSwitch.Name = "liveTranslateSwitch";
            this.liveTranslateSwitch.Size = new System.Drawing.Size(116, 17);
            this.liveTranslateSwitch.TabIndex = 7;
            this.liveTranslateSwitch.Text = "\"Живой\" перевод";
            this.liveTranslateSwitch.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 229);
            this.Controls.Add(this.liveTranslateSwitch);
            this.Controls.Add(this.switchLangButton);
            this.Controls.Add(this.destLangSelector);
            this.Controls.Add(this.sourceLangSelector);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.translateButton);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox destText;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.ComboBox sourceLangSelector;
        private System.Windows.Forms.ComboBox destLangSelector;
        private System.Windows.Forms.Button switchLangButton;
        private System.Windows.Forms.CheckBox liveTranslateSwitch;
    }
}

