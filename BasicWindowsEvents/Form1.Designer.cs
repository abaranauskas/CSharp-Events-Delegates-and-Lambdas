namespace BasicWindowsEvents
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
            this.CountriesComboBox = new System.Windows.Forms.ComboBox();
            this.CountriesLabel = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CountriesComboBox
            // 
            this.CountriesComboBox.FormattingEnabled = true;
            this.CountriesComboBox.Location = new System.Drawing.Point(175, 95);
            this.CountriesComboBox.Name = "CountriesComboBox";
            this.CountriesComboBox.Size = new System.Drawing.Size(136, 21);
            this.CountriesComboBox.TabIndex = 0;
            this.CountriesComboBox.SelectedIndexChanged += new System.EventHandler(this.CountriesComboBox_SelectedIndexChanged);
            // 
            // CountriesLabel
            // 
            this.CountriesLabel.AutoSize = true;
            this.CountriesLabel.Location = new System.Drawing.Point(172, 54);
            this.CountriesLabel.Name = "CountriesLabel";
            this.CountriesLabel.Size = new System.Drawing.Size(51, 13);
            this.CountriesLabel.TabIndex = 1;
            this.CountriesLabel.Text = "Countries";
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(175, 148);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(135, 23);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 416);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.CountriesLabel);
            this.Controls.Add(this.CountriesComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CountriesComboBox;
        private System.Windows.Forms.Label CountriesLabel;
        private System.Windows.Forms.Button Submit;
    }
}

