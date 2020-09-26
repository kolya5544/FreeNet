using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Numerics;

namespace Agreement
{
    public partial class ReceiveWindow : Form
    {
        public static RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
        public static byte[] PrivateKey = new byte[256];
        public static byte[] GeneratedKey;

        public ReceiveWindow()
        {
            InitializeComponent();
        }

        private void ReceiveWindow_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
            RNG.GetBytes(PrivateKey);
        }

        private void ApplyLocalization()
        {
            Label_Public1.Text = Localization.GetLocal(Localization.LBL_PUBLIC1_RECV);
            Label_Public2.Text = Localization.GetLocal(Localization.LBL_PUBLIC2_RECV);
            Label_MixSend.Text = Localization.GetLocal(Localization.LBL_SEND_THIS);
            Label_MixReceive.Text = Localization.GetLocal(Localization.LBL_RECEIVE_THIS);
            BtnProcess.Text = Localization.GetLocal(Localization.BTN_CONFIRM);
            Label_Output.Text = Localization.GetLocal(Localization.LBL_OUTPUT_KEY);
            Label_Checksum.Text = Localization.GetLocal(Localization.LBL_CHECKSUM);
            BtnEncrypt.Text = Localization.GetLocal(Localization.BTN_GO_ENCRYPT);
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (TB_PUBLIC1.TextLength == 0 ||
                TB_PUBLIC2.TextLength == 0 ||
                TB_SENDMIX.TextLength == 0 ||
                TB_RECVMIX.TextLength == 0)
            {
                return;
            }
            byte[] Public = Convert.FromBase64String(TB_PUBLIC1.Text);
            byte[] Generator = Convert.FromBase64String(TB_PUBLIC2.Text);
            byte[] MixSent = Convert.FromBase64String(TB_SENDMIX.Text);
            byte[] MixRecv = Convert.FromBase64String(TB_RECVMIX.Text);

            BigInteger PuBI = BigInteger.Abs(new BigInteger(Public));
            BigInteger PrBI = BigInteger.Abs(new BigInteger(PrivateKey));
            BigInteger MRBI = BigInteger.Abs(new BigInteger(MixRecv));
            using (SHA256 sha256 = SHA256.Create())
            {
                GeneratedKey = sha256.ComputeHash(BigInteger.ModPow(MRBI, PrBI, PuBI).ToByteArray());
                TB_OUTPUTKEY.Text = Convert.ToBase64String(GeneratedKey);
                TB_CHECKSUM.Text = BitConverter.ToString(sha256.ComputeHash(GeneratedKey)).Replace("-", "");

                TB_PUBLIC1.ReadOnly = true;
                TB_PUBLIC2.ReadOnly = true;
                TB_SENDMIX.ReadOnly = true;
                TB_RECVMIX.ReadOnly = true;
                BtnProcess.Enabled = false;
                BtnEncrypt.Enabled = true;
            }

        }

        private void TB_PUBLIC2_TextChanged(object sender, EventArgs e)
        {
            if (TB_PUBLIC1.TextLength > 16 && TB_PUBLIC2.TextLength > 16)
            {
                try
                {
                    BigInteger Public = BigInteger.Abs(new BigInteger(Convert.FromBase64String(TB_PUBLIC1.Text)));
                    BigInteger Generator = BigInteger.Abs(new BigInteger(Convert.FromBase64String(TB_PUBLIC2.Text)));
                    BigInteger Private = BigInteger.Abs(new BigInteger(PrivateKey));

                    BigInteger MIXsent = BigInteger.ModPow(Generator, Private, Public);
                    TB_SENDMIX.Text = Convert.ToBase64String(MIXsent.ToByteArray());
                }
                catch (Exception err)
                {
                    ErrorHandler(err);
                }
            }
        }

        public static void ErrorHandler(Exception err)
        {
            MessageBox.Show("Unknown error appeared: " + err.Message + ". Cannot continue", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReceiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptWindow.Key = GeneratedKey;
            var EW = new EncryptWindow();
            EW.Show();
            this.Hide();
        }

        private void TB_SENDMIX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Clipboard.SetText(TB_SENDMIX.Text);
                MessageBox.Show("Copied!", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TB_CHECKSUM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Clipboard.SetText(TB_CHECKSUM.Text);
                MessageBox.Show("Copied!", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
