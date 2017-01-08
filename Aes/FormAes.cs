using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aes
{
    public partial class FormAes : Form
    {
        private string _bitmapPath;

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

        private void buttonBitmap_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    _bitmapPath = dlg.FileName;
                    pictureBox.Image = new Bitmap(dlg.FileName);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    ShowMessage("Opening bitmap failed!");
                }
            }
        }

        private void buttonBitmapDecrypt_Click(object sender, EventArgs e)
        {
            Bitmap img = Algorithm.ProcessBitmap(_bitmapPath, textBoxDKey.Text, true);
            ShowResultPicture(img);
        }

        private void buttonEncryptBitmap_Click(object sender, EventArgs e)
        {
            Bitmap img = Algorithm.ProcessBitmap(_bitmapPath, textBoxDKey.Text);
            ShowResultPicture(img);
        }

        private void ShowResultPicture(Image img)
        {
            if (img != null)
            {
                pictureBoxResult.Image = img;
                pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                ShowMessage("Bad key or bitmap load failed!" +
                            " If using CFB IV also can be provided incorrect!");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            Image img = pictureBoxResult.Image;

            if (img != null)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    img.Save(dialog.FileName, ImageFormat.Bmp);
                }
            }
            else
            {
                ShowMessage("There's no result image yet!");
            }
        }

        private void buttonEncryptCFB_Click(object sender, EventArgs e)
        {
            Bitmap img = Algorithm.ProcessBitmapCFB(_bitmapPath, textBoxIV.Text, textBoxDKey.Text);
            ShowResultPicture(img);
        }

        private void buttonDecryptCFB_Click(object sender, EventArgs e)
        {
            Bitmap img = Algorithm.ProcessBitmapCFB(_bitmapPath, textBoxIV.Text, textBoxDKey.Text, true);
            ShowResultPicture(img);
        }
    }
}
