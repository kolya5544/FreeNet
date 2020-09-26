using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agreement
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (!File.Exists("config.txt"))
            {
                CallLanguageDialog();
            } else
            {
                if (!int.TryParse(File.ReadAllText("config.txt"), out Localization.Language))
                {
                    throw new Exception("Unable to read the config file.");
                }
            }

            ApplyLocalization();
        }

        private void ApplyLocalization()
        {
            ReceiveBTN.Text = Localization.GetLocal(Localization.BTN_RCV_SIDE);
            EncryptBTN.Text = Localization.GetLocal(Localization.BTN_JUST_ENCRYPT);
            SendingBTN.Text = Localization.GetLocal(Localization.BTN_SEND_SIDE);
            SRCBTN.Text = Localization.GetLocal(Localization.BTN_SOURCE);
        }

        public void CallLanguageDialog()
        {
            LanguagePicker LPdialog = new LanguagePicker();
            LPdialog.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CallLanguageDialog();
            MainMenu_Load(null, null);
        }

        private void ReceiveBTN_Click(object sender, EventArgs e)
        {
            var RW = new ReceiveWindow();
            this.Hide();
            RW.Show();
        }

        private void SendingBTN_Click(object sender, EventArgs e)
        {
            var SW = new SendWindow();
            this.Hide();
            SW.Show();
        }

        private void EncryptBTN_Click(object sender, EventArgs e)
        {
            var EW = new EncryptWindow();
            this.Hide();
            EW.Show();
        }

        private void SRCBTN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kolya5544/FreeNet/tree/master/Agreement");
        }
    }
}
