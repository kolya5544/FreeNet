namespace Agreement
{
    partial class EncryptWindow
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
            this.Label_Key = new System.Windows.Forms.Label();
            this.TB_KEY = new System.Windows.Forms.TextBox();
            this.BtnKeyConfirm = new System.Windows.Forms.Button();
            this.Label_Message = new System.Windows.Forms.Label();
            this.TB_MSG_GOT = new System.Windows.Forms.TextBox();
            this.Btn_Decrypt = new System.Windows.Forms.Button();
            this.Btn_Encrypt = new System.Windows.Forms.Button();
            this.Label_EncryptOut = new System.Windows.Forms.Label();
            this.TB_ENC_OUT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Label_Key
            // 
            this.Label_Key.AutoSize = true;
            this.Label_Key.Location = new System.Drawing.Point(9, 9);
            this.Label_Key.Name = "Label_Key";
            this.Label_Key.Size = new System.Drawing.Size(90, 13);
            this.Label_Key.TabIndex = 0;
            this.Label_Key.Text = "LBL_YOUR_KEY";
            // 
            // TB_KEY
            // 
            this.TB_KEY.Location = new System.Drawing.Point(12, 25);
            this.TB_KEY.Name = "TB_KEY";
            this.TB_KEY.PasswordChar = '*';
            this.TB_KEY.Size = new System.Drawing.Size(492, 20);
            this.TB_KEY.TabIndex = 1;
            // 
            // BtnKeyConfirm
            // 
            this.BtnKeyConfirm.Location = new System.Drawing.Point(12, 51);
            this.BtnKeyConfirm.Name = "BtnKeyConfirm";
            this.BtnKeyConfirm.Size = new System.Drawing.Size(492, 23);
            this.BtnKeyConfirm.TabIndex = 2;
            this.BtnKeyConfirm.Text = "BTN_CONFIRM_KEY";
            this.BtnKeyConfirm.UseVisualStyleBackColor = true;
            this.BtnKeyConfirm.Click += new System.EventHandler(this.BtnKeyConfirm_Click);
            // 
            // Label_Message
            // 
            this.Label_Message.AutoSize = true;
            this.Label_Message.Location = new System.Drawing.Point(12, 77);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(113, 13);
            this.Label_Message.TabIndex = 3;
            this.Label_Message.Text = "LBL_MESSAGE_GOT";
            // 
            // TB_MSG_GOT
            // 
            this.TB_MSG_GOT.Location = new System.Drawing.Point(12, 93);
            this.TB_MSG_GOT.Name = "TB_MSG_GOT";
            this.TB_MSG_GOT.Size = new System.Drawing.Size(492, 20);
            this.TB_MSG_GOT.TabIndex = 4;
            // 
            // Btn_Decrypt
            // 
            this.Btn_Decrypt.Enabled = false;
            this.Btn_Decrypt.Location = new System.Drawing.Point(12, 119);
            this.Btn_Decrypt.Name = "Btn_Decrypt";
            this.Btn_Decrypt.Size = new System.Drawing.Size(243, 23);
            this.Btn_Decrypt.TabIndex = 5;
            this.Btn_Decrypt.Text = "BTN_DECRYPT_TEXT";
            this.Btn_Decrypt.UseVisualStyleBackColor = true;
            this.Btn_Decrypt.Click += new System.EventHandler(this.Btn_Decrypt_Click);
            // 
            // Btn_Encrypt
            // 
            this.Btn_Encrypt.Enabled = false;
            this.Btn_Encrypt.Location = new System.Drawing.Point(261, 119);
            this.Btn_Encrypt.Name = "Btn_Encrypt";
            this.Btn_Encrypt.Size = new System.Drawing.Size(243, 23);
            this.Btn_Encrypt.TabIndex = 6;
            this.Btn_Encrypt.Text = "BTN_ENCRYPT_TEXT";
            this.Btn_Encrypt.UseVisualStyleBackColor = true;
            this.Btn_Encrypt.Click += new System.EventHandler(this.Btn_Encrypt_Click);
            // 
            // Label_EncryptOut
            // 
            this.Label_EncryptOut.AutoSize = true;
            this.Label_EncryptOut.Location = new System.Drawing.Point(12, 145);
            this.Label_EncryptOut.Name = "Label_EncryptOut";
            this.Label_EncryptOut.Size = new System.Drawing.Size(153, 13);
            this.Label_EncryptOut.TabIndex = 7;
            this.Label_EncryptOut.Text = "LBL_ENCRYPTION_OUTPUT";
            // 
            // TB_ENC_OUT
            // 
            this.TB_ENC_OUT.Location = new System.Drawing.Point(12, 161);
            this.TB_ENC_OUT.Name = "TB_ENC_OUT";
            this.TB_ENC_OUT.ReadOnly = true;
            this.TB_ENC_OUT.Size = new System.Drawing.Size(492, 20);
            this.TB_ENC_OUT.TabIndex = 8;
            this.TB_ENC_OUT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_ENC_OUT_KeyDown);
            // 
            // EncryptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(516, 198);
            this.Controls.Add(this.TB_ENC_OUT);
            this.Controls.Add(this.Label_EncryptOut);
            this.Controls.Add(this.Btn_Encrypt);
            this.Controls.Add(this.Btn_Decrypt);
            this.Controls.Add(this.TB_MSG_GOT);
            this.Controls.Add(this.Label_Message);
            this.Controls.Add(this.BtnKeyConfirm);
            this.Controls.Add(this.TB_KEY);
            this.Controls.Add(this.Label_Key);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EncryptWindow";
            this.ShowIcon = false;
            this.Text = "Encryption interface window.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EncryptWindow_FormClosing);
            this.Load += new System.EventHandler(this.EncryptWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Key;
        private System.Windows.Forms.TextBox TB_KEY;
        private System.Windows.Forms.Button BtnKeyConfirm;
        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.TextBox TB_MSG_GOT;
        private System.Windows.Forms.Button Btn_Decrypt;
        private System.Windows.Forms.Button Btn_Encrypt;
        private System.Windows.Forms.Label Label_EncryptOut;
        private System.Windows.Forms.TextBox TB_ENC_OUT;
    }
}