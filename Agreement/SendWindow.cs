using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agreement
{
    public partial class SendWindow : Form
    {
        public static RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
        public static Random r = new Random();
        public static byte[] PrivateKey = new byte[256];
        public static byte[] Public1 = new byte[256];
        public static byte[] Public2 = new byte[256];
        public static byte[] GeneratedKey;
        public SendWindow()
        {
            InitializeComponent();
        }

        private void SendWindow_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
            RNG.GetBytes(PrivateKey);
            RNG.GetBytes(Public1);
            RNG.GetBytes(Public2);
            //BigInteger prime = GetPrime();
            //Public2 = prime.ToByteArray();
            TB_PUBLIC1.Text = Convert.ToBase64String(Public1);
            TB_PUBLIC2.Text = Convert.ToBase64String(Public2);

            BigInteger Public = BigInteger.Abs(new BigInteger(Public1));
            BigInteger Generator = BigInteger.Abs(new BigInteger(Public2));
            BigInteger Private = BigInteger.Abs(new BigInteger(PrivateKey));

            BigInteger MIXsent = BigInteger.ModPow(Generator, Private, Public);
            TB_SENDMIX.Text = Convert.ToBase64String(MIXsent.ToByteArray());
        }

        private BigInteger GetPrime()
        {
            PrimesGenerator.StartFrom = r.Next(1000000000, 2000000000);
            var a = PrimesGenerator.GetPrimes().Take(100000).ToArray();

            return new BigInteger(a[r.Next(0, 100000)]);
        }

        private void ApplyLocalization()
        {
            Label_Public1.Text = Localization.GetLocal(Localization.LBL_PUBLIC1_SEND);
            Label_Public2.Text = Localization.GetLocal(Localization.LBL_PUBLIC2_SEND);
            Label_MixSend.Text = Localization.GetLocal(Localization.LBL_SEND_THIS);
            Label_MixReceive.Text = Localization.GetLocal(Localization.LBL_RECEIVE_THIS);
            BtnProcess.Text = Localization.GetLocal(Localization.BTN_CONFIRM);
            Label_Output.Text = Localization.GetLocal(Localization.LBL_OUTPUT_KEY);
            Label_Checksum.Text = Localization.GetLocal(Localization.LBL_CHECKSUM);
            Label_Trackbar.Text = Localization.GetLocal(Localization.LBL_KEYLENGTH_BAR);
            BtnEncrypt.Text = Localization.GetLocal(Localization.BTN_GO_ENCRYPT);
        }

        private void SendWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (TB_RECVMIX.TextLength == 0)
            {
                return;
            }
            byte[] Public = Convert.FromBase64String(TB_PUBLIC1.Text);
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

                TB_RECVMIX.ReadOnly = true;
                BtnProcess.Enabled = false;
                BtnEncrypt.Enabled = true;
            }
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            EncryptWindow.Key = GeneratedKey;
            var EW = new EncryptWindow();
            EW.Show();
            this.Hide();
        }

        private void TB_PUBLIC1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Clipboard.SetText(TB_PUBLIC1.Text);
                MessageBox.Show("Copied!", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TB_PUBLIC2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Clipboard.SetText(TB_PUBLIC2.Text);
                MessageBox.Show("Copied!", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void TRACK_Keylength_Scroll(object sender, EventArgs e)
        {
            int bytes = (int)Math.Pow(2, 5 + TRACK_Keylength.Value);
            PrivateKey = new byte[bytes];
            Public1 = new byte[bytes];
            Public2 = new byte[bytes];
            RNG.GetBytes(PrivateKey);
            RNG.GetBytes(Public1);
            RNG.GetBytes(Public2);
            TB_PUBLIC1.Text = Convert.ToBase64String(Public1);
            TB_PUBLIC2.Text = Convert.ToBase64String(Public2);
            BigInteger Public = BigInteger.Abs(new BigInteger(Public1));
            BigInteger Generator = BigInteger.Abs(new BigInteger(Public2));
            BigInteger Private = BigInteger.Abs(new BigInteger(PrivateKey));
            BigInteger MIXsent = BigInteger.ModPow(Generator, Private, Public);
            TB_SENDMIX.Text = Convert.ToBase64String(MIXsent.ToByteArray());
        }
    }
    static class PrimesGenerator
    {
        public static int StartFrom = 2;

        public static IEnumerable<int> GetPrimes()
        {
            var number = StartFrom;
            var dividers = new List<int>();
            while (true)
            {
                if (!IsDividedBy(number, dividers))
                {
                    yield return number;
                    dividers.Add(number);
                }
                number++;
            }

            bool IsDividedBy(int inputValue, IEnumerable<int> increasingSeriesOfDividers)
            {
                foreach (var divider in increasingSeriesOfDividers)
                {
                    if (divider * divider > inputValue)
                        return false;
                    if (inputValue % divider == 0)
                        return true;
                }

                return false;
            }
        }
    }
}
