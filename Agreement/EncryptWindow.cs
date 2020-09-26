using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agreement
{
    public partial class EncryptWindow : Form
    {
        public static byte[] Key;
        public static AesCryptoServiceProvider AES;

        public static Random rng = new Random();

        public static AesCryptoServiceProvider CreateProvider(byte[] key)
        {
            return new AesCryptoServiceProvider
            {
                KeySize = 256,
                BlockSize = 128,
                Key = key,
                Padding = PaddingMode.None,
                Mode = CipherMode.ECB
            };
        }

        public EncryptWindow()
        {
            InitializeComponent();
        }

        private void EncryptWindow_Load(object sender, EventArgs e)
        {
            ApplyLocalization();
            if (Key != null)
            {
                TB_KEY.Text = Convert.ToBase64String(Key);

                TB_KEY.ReadOnly = true;
                BtnKeyConfirm.Enabled = false;
                Btn_Decrypt.Enabled = true;
                Btn_Encrypt.Enabled = true;

                AES = CreateProvider(Key);
            }
        }

        private void ApplyLocalization()
        {
            Label_Key.Text = Localization.GetLocal(Localization.LBL_YOUR_KEY);
            Label_Message.Text = Localization.GetLocal(Localization.LBL_MESSAGE_GOT);
            Label_EncryptOut.Text = Localization.GetLocal(Localization.LBL_ENCRYPTION_OUTPUT);

            Btn_Decrypt.Text = Localization.GetLocal(Localization.BTN_DECRYPT_TEXT);
            Btn_Encrypt.Text = Localization.GetLocal(Localization.BTN_ENCRYPT_TEXT);
            BtnKeyConfirm.Text = Localization.GetLocal(Localization.BTN_CONFIRM_KEY);
        }

        private void BtnKeyConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Key = Convert.FromBase64String(TB_KEY.Text);
                TB_KEY.ReadOnly = true;
                BtnKeyConfirm.Enabled = false;
                Btn_Decrypt.Enabled = true;
                Btn_Encrypt.Enabled = true;
                AES = CreateProvider(Key);
            } catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EncryptWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Btn_Encrypt_Click(object sender, EventArgs e)
        {
            string MSG = TB_MSG_GOT.Text;
            byte[] msgB = Encoding.UTF8.GetBytes(MSG);
            int PaddingLen = rng.Next(10, 80);
            byte[] ToEncrypt = new byte[4 + msgB.Length + PaddingLen];
            var ms = new MemoryStream(ToEncrypt);
            ms.Write(BitConverter.GetBytes(msgB.Length), 0, sizeof(int));
            ms.Write(msgB, 0, msgB.Length);
            byte[] padding = new byte[PaddingLen];
            for (int i = 0; i<PaddingLen; i++)
            {
                padding[i] = (byte)rng.Next(0, 256);
            }
            ms.Write(padding, 0, PaddingLen);

            byte[] outp = Encrypt(ToEncrypt);
            TB_ENC_OUT.Text = Convert.ToBase64String(outp);
        }

        private static byte[] Decrypt(byte[] toDecrypt)
        {
            var dec = AES.CreateDecryptor();
            byte[] resultArray = dec.TransformFinalBlock(toDecrypt, 0, toDecrypt.Length);
            return resultArray;
        }
        private static byte[] Encrypt(byte[] toEncrypt)
        {
            var enc = AES.CreateEncryptor();
            List<byte> te = toEncrypt.ToList();
            while (te.Count % 16 != 0) te.Add(0x00);
            toEncrypt = te.ToArray();
            byte[] resultArray = enc.TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);
            return resultArray;
        }

        private void TB_ENC_OUT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Clipboard.SetText(TB_ENC_OUT.Text);
                MessageBox.Show("Copied!", "Ok!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            string MSG = TB_MSG_GOT.Text;
            byte[] msgB = Convert.FromBase64String(MSG);
            byte[] Decrypted = Decrypt(msgB);
            var ms = new MemoryStream(Decrypted);
            int FinalLength = BitConverter.ToInt32(Decrypted, 0);
            ms.Position = 4;
            byte[] Original = new byte[FinalLength];
            ms.Read(Original, 0, FinalLength);
            TB_ENC_OUT.Text = Encoding.UTF8.GetString(Original);
        }
    }
}
