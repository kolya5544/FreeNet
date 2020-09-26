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
    public partial class LanguagePicker : Form
    {
        public LanguagePicker()
        {
            InitializeComponent();
        }

        private void English_Lang_Click(object sender, EventArgs e)
        {
            Localization.Language = 0;
            SaveLocalization();
            this.Close();
        }

        private void Russian_Lang_Click(object sender, EventArgs e)
        {
            Localization.Language = 1;
            SaveLocalization();
            this.Close();
        }

        private void SaveLocalization()
        {
            File.WriteAllText("config.txt", Localization.Language.ToString());
        }
    }
}
