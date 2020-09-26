namespace Agreement
{
    partial class LanguagePicker
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
            this.Russian_Lang = new System.Windows.Forms.Button();
            this.English_Lang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Russian_Lang
            // 
            this.Russian_Lang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Russian_Lang.Location = new System.Drawing.Point(12, 12);
            this.Russian_Lang.Name = "Russian_Lang";
            this.Russian_Lang.Size = new System.Drawing.Size(182, 166);
            this.Russian_Lang.TabIndex = 0;
            this.Russian_Lang.Text = "Русский";
            this.Russian_Lang.UseVisualStyleBackColor = true;
            this.Russian_Lang.Click += new System.EventHandler(this.Russian_Lang_Click);
            // 
            // English_Lang
            // 
            this.English_Lang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.English_Lang.Location = new System.Drawing.Point(200, 12);
            this.English_Lang.Name = "English_Lang";
            this.English_Lang.Size = new System.Drawing.Size(182, 166);
            this.English_Lang.TabIndex = 1;
            this.English_Lang.Text = "English";
            this.English_Lang.UseVisualStyleBackColor = true;
            this.English_Lang.Click += new System.EventHandler(this.English_Lang_Click);
            // 
            // LanguagePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(394, 190);
            this.Controls.Add(this.English_Lang);
            this.Controls.Add(this.Russian_Lang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LanguagePicker";
            this.Text = "Language picker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Russian_Lang;
        private System.Windows.Forms.Button English_Lang;
    }
}