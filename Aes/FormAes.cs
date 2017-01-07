using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aes
{
    public partial class FormAes : Form
    {
        public FormAes()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string result = Algorithm.EncryptMessage(tbPlain.Text, tbKey.Text);

            if (result != null)
            {
                textBoxResultE.Text = result;
            }
            else
            {
                ShowMessage("Wrong key format or empty message!");
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            string result = Algorithm.DecryptMessage(textCypher.Text, textBoxDKey.Text);

            if (result != null)
            {
                textBoxResultD.Text = result;
            }
            else
            {
                ShowMessage("Wrong key or cypher format!");
            }
        }
    }
}
