namespace Agreement
{
    partial class MainMenu
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
            this.ReceiveBTN = new System.Windows.Forms.Button();
            this.SendingBTN = new System.Windows.Forms.Button();
            this.EncryptBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SRCBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiveBTN
            // 
            this.ReceiveBTN.Location = new System.Drawing.Point(12, 12);
            this.ReceiveBTN.Name = "ReceiveBTN";
            this.ReceiveBTN.Size = new System.Drawing.Size(367, 23);
            this.ReceiveBTN.TabIndex = 0;
            this.ReceiveBTN.Text = "BTN_RCV_SIDE";
            this.ReceiveBTN.UseVisualStyleBackColor = true;
            this.ReceiveBTN.Click += new System.EventHandler(this.ReceiveBTN_Click);
            // 
            // SendingBTN
            // 
            this.SendingBTN.Location = new System.Drawing.Point(12, 41);
            this.SendingBTN.Name = "SendingBTN";
            this.SendingBTN.Size = new System.Drawing.Size(367, 23);
            this.SendingBTN.TabIndex = 1;
            this.SendingBTN.Text = "BTN_SEND_SIDE";
            this.SendingBTN.UseVisualStyleBackColor = true;
            this.SendingBTN.Click += new System.EventHandler(this.SendingBTN_Click);
            // 
            // EncryptBTN
            // 
            this.EncryptBTN.Location = new System.Drawing.Point(12, 70);
            this.EncryptBTN.Name = "EncryptBTN";
            this.EncryptBTN.Size = new System.Drawing.Size(367, 23);
            this.EncryptBTN.TabIndex = 2;
            this.EncryptBTN.Text = "BTN_JUST_ENCRYPT";
            this.EncryptBTN.UseVisualStyleBackColor = true;
            this.EncryptBTN.Click += new System.EventHandler(this.EncryptBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::Agreement.Properties.Resources.planet;
            this.pictureBox1.InitialImage = global::Agreement.Properties.Resources.planet;
            this.pictureBox1.Location = new System.Drawing.Point(12, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // SRCBTN
            // 
            this.SRCBTN.Location = new System.Drawing.Point(183, 99);
            this.SRCBTN.Name = "SRCBTN";
            this.SRCBTN.Size = new System.Drawing.Size(196, 29);
            this.SRCBTN.TabIndex = 4;
            this.SRCBTN.Text = "BTN_SOURCE";
            this.SRCBTN.UseVisualStyleBackColor = true;
            this.SRCBTN.Click += new System.EventHandler(this.SRCBTN_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(391, 140);
            this.Controls.Add(this.SRCBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.EncryptBTN);
            this.Controls.Add(this.SendingBTN);
            this.Controls.Add(this.ReceiveBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.ShowIcon = false;
            this.Text = "Main menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReceiveBTN;
        private System.Windows.Forms.Button SendingBTN;
        private System.Windows.Forms.Button EncryptBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button SRCBTN;
    }
}

