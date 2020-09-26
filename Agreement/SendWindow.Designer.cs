namespace Agreement
{
    partial class SendWindow
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
            this.BtnEncrypt = new System.Windows.Forms.Button();
            this.TB_CHECKSUM = new System.Windows.Forms.TextBox();
            this.Label_Checksum = new System.Windows.Forms.Label();
            this.TB_OUTPUTKEY = new System.Windows.Forms.TextBox();
            this.Label_Output = new System.Windows.Forms.Label();
            this.BtnProcess = new System.Windows.Forms.Button();
            this.TB_RECVMIX = new System.Windows.Forms.TextBox();
            this.Label_MixReceive = new System.Windows.Forms.Label();
            this.TB_SENDMIX = new System.Windows.Forms.TextBox();
            this.Label_MixSend = new System.Windows.Forms.Label();
            this.TB_PUBLIC2 = new System.Windows.Forms.TextBox();
            this.Label_Public2 = new System.Windows.Forms.Label();
            this.TB_PUBLIC1 = new System.Windows.Forms.TextBox();
            this.Label_Public1 = new System.Windows.Forms.Label();
            this.TRACK_Keylength = new System.Windows.Forms.TrackBar();
            this.Label_Trackbar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_Keylength)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEncrypt
            // 
            this.BtnEncrypt.Enabled = false;
            this.BtnEncrypt.Location = new System.Drawing.Point(9, 381);
            this.BtnEncrypt.Name = "BtnEncrypt";
            this.BtnEncrypt.Size = new System.Drawing.Size(606, 23);
            this.BtnEncrypt.TabIndex = 27;
            this.BtnEncrypt.Text = "BTN_GO_ENCRYPT";
            this.BtnEncrypt.UseVisualStyleBackColor = true;
            this.BtnEncrypt.Click += new System.EventHandler(this.BtnEncrypt_Click);
            // 
            // TB_CHECKSUM
            // 
            this.TB_CHECKSUM.Location = new System.Drawing.Point(9, 355);
            this.TB_CHECKSUM.Name = "TB_CHECKSUM";
            this.TB_CHECKSUM.ReadOnly = true;
            this.TB_CHECKSUM.Size = new System.Drawing.Size(606, 20);
            this.TB_CHECKSUM.TabIndex = 26;
            this.TB_CHECKSUM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_CHECKSUM_KeyDown);
            // 
            // Label_Checksum
            // 
            this.Label_Checksum.AutoSize = true;
            this.Label_Checksum.Location = new System.Drawing.Point(9, 339);
            this.Label_Checksum.Name = "Label_Checksum";
            this.Label_Checksum.Size = new System.Drawing.Size(92, 13);
            this.Label_Checksum.TabIndex = 25;
            this.Label_Checksum.Text = "LBL_CHECKSUM";
            // 
            // TB_OUTPUTKEY
            // 
            this.TB_OUTPUTKEY.Location = new System.Drawing.Point(9, 309);
            this.TB_OUTPUTKEY.Name = "TB_OUTPUTKEY";
            this.TB_OUTPUTKEY.ReadOnly = true;
            this.TB_OUTPUTKEY.Size = new System.Drawing.Size(606, 20);
            this.TB_OUTPUTKEY.TabIndex = 24;
            // 
            // Label_Output
            // 
            this.Label_Output.AutoSize = true;
            this.Label_Output.Location = new System.Drawing.Point(9, 293);
            this.Label_Output.Name = "Label_Output";
            this.Label_Output.Size = new System.Drawing.Size(104, 13);
            this.Label_Output.TabIndex = 23;
            this.Label_Output.Text = "LBL_OUTPUT_KEY";
            // 
            // BtnProcess
            // 
            this.BtnProcess.Location = new System.Drawing.Point(9, 253);
            this.BtnProcess.Name = "BtnProcess";
            this.BtnProcess.Size = new System.Drawing.Size(606, 37);
            this.BtnProcess.TabIndex = 22;
            this.BtnProcess.Text = "BTN_CONFIRM";
            this.BtnProcess.UseVisualStyleBackColor = true;
            this.BtnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // TB_RECVMIX
            // 
            this.TB_RECVMIX.Location = new System.Drawing.Point(9, 227);
            this.TB_RECVMIX.Name = "TB_RECVMIX";
            this.TB_RECVMIX.Size = new System.Drawing.Size(606, 20);
            this.TB_RECVMIX.TabIndex = 21;
            // 
            // Label_MixReceive
            // 
            this.Label_MixReceive.AutoSize = true;
            this.Label_MixReceive.Location = new System.Drawing.Point(9, 211);
            this.Label_MixReceive.Name = "Label_MixReceive";
            this.Label_MixReceive.Size = new System.Drawing.Size(109, 13);
            this.Label_MixReceive.TabIndex = 20;
            this.Label_MixReceive.Text = "LBL_RECEIVE_THIS";
            // 
            // TB_SENDMIX
            // 
            this.TB_SENDMIX.Location = new System.Drawing.Point(9, 185);
            this.TB_SENDMIX.Name = "TB_SENDMIX";
            this.TB_SENDMIX.ReadOnly = true;
            this.TB_SENDMIX.Size = new System.Drawing.Size(606, 20);
            this.TB_SENDMIX.TabIndex = 19;
            this.TB_SENDMIX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_SENDMIX_KeyDown);
            // 
            // Label_MixSend
            // 
            this.Label_MixSend.AutoSize = true;
            this.Label_MixSend.Location = new System.Drawing.Point(9, 169);
            this.Label_MixSend.Name = "Label_MixSend";
            this.Label_MixSend.Size = new System.Drawing.Size(93, 13);
            this.Label_MixSend.TabIndex = 18;
            this.Label_MixSend.Text = "LBL_SEND_THIS";
            // 
            // TB_PUBLIC2
            // 
            this.TB_PUBLIC2.Location = new System.Drawing.Point(9, 142);
            this.TB_PUBLIC2.Name = "TB_PUBLIC2";
            this.TB_PUBLIC2.ReadOnly = true;
            this.TB_PUBLIC2.Size = new System.Drawing.Size(606, 20);
            this.TB_PUBLIC2.TabIndex = 17;
            this.TB_PUBLIC2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_PUBLIC2_KeyDown);
            // 
            // Label_Public2
            // 
            this.Label_Public2.AutoSize = true;
            this.Label_Public2.Location = new System.Drawing.Point(9, 126);
            this.Label_Public2.Name = "Label_Public2";
            this.Label_Public2.Size = new System.Drawing.Size(112, 13);
            this.Label_Public2.TabIndex = 16;
            this.Label_Public2.Text = "LBL_PUBLIC2_SEND";
            // 
            // TB_PUBLIC1
            // 
            this.TB_PUBLIC1.Location = new System.Drawing.Point(9, 101);
            this.TB_PUBLIC1.Name = "TB_PUBLIC1";
            this.TB_PUBLIC1.ReadOnly = true;
            this.TB_PUBLIC1.Size = new System.Drawing.Size(606, 20);
            this.TB_PUBLIC1.TabIndex = 15;
            this.TB_PUBLIC1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_PUBLIC1_KeyDown);
            // 
            // Label_Public1
            // 
            this.Label_Public1.AutoSize = true;
            this.Label_Public1.Location = new System.Drawing.Point(9, 87);
            this.Label_Public1.Name = "Label_Public1";
            this.Label_Public1.Size = new System.Drawing.Size(112, 13);
            this.Label_Public1.TabIndex = 14;
            this.Label_Public1.Text = "LBL_PUBLIC1_SEND";
            // 
            // TRACK_Keylength
            // 
            this.TRACK_Keylength.Location = new System.Drawing.Point(9, 39);
            this.TRACK_Keylength.Maximum = 3;
            this.TRACK_Keylength.Name = "TRACK_Keylength";
            this.TRACK_Keylength.Size = new System.Drawing.Size(606, 45);
            this.TRACK_Keylength.TabIndex = 28;
            this.TRACK_Keylength.Value = 3;
            this.TRACK_Keylength.Scroll += new System.EventHandler(this.TRACK_Keylength_Scroll);
            // 
            // Label_Trackbar
            // 
            this.Label_Trackbar.AutoSize = true;
            this.Label_Trackbar.Location = new System.Drawing.Point(12, 9);
            this.Label_Trackbar.Name = "Label_Trackbar";
            this.Label_Trackbar.Size = new System.Drawing.Size(125, 13);
            this.Label_Trackbar.TabIndex = 29;
            this.Label_Trackbar.Text = "LBL_KEYLENGTH_BAR";
            // 
            // SendWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(630, 414);
            this.Controls.Add(this.Label_Trackbar);
            this.Controls.Add(this.TRACK_Keylength);
            this.Controls.Add(this.BtnEncrypt);
            this.Controls.Add(this.TB_CHECKSUM);
            this.Controls.Add(this.Label_Checksum);
            this.Controls.Add(this.TB_OUTPUTKEY);
            this.Controls.Add(this.Label_Output);
            this.Controls.Add(this.BtnProcess);
            this.Controls.Add(this.TB_RECVMIX);
            this.Controls.Add(this.Label_MixReceive);
            this.Controls.Add(this.TB_SENDMIX);
            this.Controls.Add(this.Label_MixSend);
            this.Controls.Add(this.TB_PUBLIC2);
            this.Controls.Add(this.Label_Public2);
            this.Controls.Add(this.TB_PUBLIC1);
            this.Controls.Add(this.Label_Public1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SendWindow";
            this.ShowIcon = false;
            this.Text = "Sending side window.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SendWindow_FormClosing);
            this.Load += new System.EventHandler(this.SendWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TRACK_Keylength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEncrypt;
        private System.Windows.Forms.TextBox TB_CHECKSUM;
        private System.Windows.Forms.Label Label_Checksum;
        private System.Windows.Forms.TextBox TB_OUTPUTKEY;
        private System.Windows.Forms.Label Label_Output;
        private System.Windows.Forms.Button BtnProcess;
        private System.Windows.Forms.TextBox TB_RECVMIX;
        private System.Windows.Forms.Label Label_MixReceive;
        private System.Windows.Forms.TextBox TB_SENDMIX;
        private System.Windows.Forms.Label Label_MixSend;
        private System.Windows.Forms.TextBox TB_PUBLIC2;
        private System.Windows.Forms.Label Label_Public2;
        private System.Windows.Forms.TextBox TB_PUBLIC1;
        private System.Windows.Forms.Label Label_Public1;
        private System.Windows.Forms.TrackBar TRACK_Keylength;
        private System.Windows.Forms.Label Label_Trackbar;
    }
}