namespace Aes
{
    partial class FormAes
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
            this.tbPlain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxResultE = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxResultD = new System.Windows.Forms.TextBox();
            this.textCypher = new System.Windows.Forms.TextBox();
            this.textBoxDKey = new System.Windows.Forms.TextBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.textBoxKeyBitmap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonBitmapDecrypt = new System.Windows.Forms.Button();
            this.buttonEncryptBitmap = new System.Windows.Forms.Button();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonBitmap = new System.Windows.Forms.Button();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.buttonEncryptCFB = new System.Windows.Forms.Button();
            this.buttonDecryptCFB = new System.Windows.Forms.Button();
            this.labelIV = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPlain
            // 
            this.tbPlain.Location = new System.Drawing.Point(163, 43);
            this.tbPlain.Name = "tbPlain";
            this.tbPlain.Size = new System.Drawing.Size(757, 20);
            this.tbPlain.TabIndex = 0;
            this.tbPlain.Text = "12345789abcdexyz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Key (128/192/256 bit in HEX):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Message:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonEncrypt.Location = new System.Drawing.Point(6, 74);
            this.buttonEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(103, 42);
            this.buttonEncrypt.TabIndex = 14;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = false;
            this.buttonEncrypt.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(163, 11);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(757, 20);
            this.tbKey.TabIndex = 1;
            this.tbKey.Text = "112233445566778899aabbccddeeff00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Key (128/192/256 bit in HEX):";
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.textBoxResultE);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonEncrypt);
            this.panel1.Controls.Add(this.tbKey);
            this.panel1.Controls.Add(this.tbPlain);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 125);
            this.panel1.TabIndex = 17;
            // 
            // textBoxResultE
            // 
            this.textBoxResultE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxResultE.Location = new System.Drawing.Point(163, 86);
            this.textBoxResultE.Name = "textBoxResultE";
            this.textBoxResultE.Size = new System.Drawing.Size(757, 20);
            this.textBoxResultE.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxResultD);
            this.panel2.Controls.Add(this.textCypher);
            this.panel2.Controls.Add(this.textBoxDKey);
            this.panel2.Controls.Add(this.buttonDecrypt);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 126);
            this.panel2.TabIndex = 18;
            // 
            // textBoxResultD
            // 
            this.textBoxResultD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxResultD.Location = new System.Drawing.Point(162, 83);
            this.textBoxResultD.Name = "textBoxResultD";
            this.textBoxResultD.Size = new System.Drawing.Size(757, 20);
            this.textBoxResultD.TabIndex = 16;
            // 
            // textCypher
            // 
            this.textCypher.Location = new System.Drawing.Point(163, 40);
            this.textCypher.Name = "textCypher";
            this.textCypher.Size = new System.Drawing.Size(756, 20);
            this.textCypher.TabIndex = 16;
            this.textCypher.Text = "6A19566351E9F22CB4508563C59073A7";
            // 
            // textBoxDKey
            // 
            this.textBoxDKey.Location = new System.Drawing.Point(163, 11);
            this.textBoxDKey.Name = "textBoxDKey";
            this.textBoxDKey.Size = new System.Drawing.Size(756, 20);
            this.textBoxDKey.TabIndex = 16;
            this.textBoxDKey.Text = "112233445566778899aabbccddeeff00";
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDecrypt.Location = new System.Drawing.Point(6, 71);
            this.buttonDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(103, 42);
            this.buttonDecrypt.TabIndex = 16;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = false;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Cypher (in HEX):";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.labelIV);
            this.panel3.Controls.Add(this.buttonDecryptCFB);
            this.panel3.Controls.Add(this.buttonEncryptCFB);
            this.panel3.Controls.Add(this.textBoxIV);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.labelResult);
            this.panel3.Controls.Add(this.labelSource);
            this.panel3.Controls.Add(this.textBoxKeyBitmap);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.buttonBitmapDecrypt);
            this.panel3.Controls.Add(this.buttonEncryptBitmap);
            this.panel3.Controls.Add(this.pictureBoxResult);
            this.panel3.Controls.Add(this.pictureBox);
            this.panel3.Controls.Add(this.buttonBitmap);
            this.panel3.Location = new System.Drawing.Point(13, 275);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 202);
            this.panel3.TabIndex = 19;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 152);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save result";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(293, 38);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(40, 13);
            this.labelResult.TabIndex = 21;
            this.labelResult.Text = "Result:";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(163, 38);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 20;
            this.labelSource.Text = "Source:";
            // 
            // textBoxKeyBitmap
            // 
            this.textBoxKeyBitmap.Location = new System.Drawing.Point(162, 3);
            this.textBoxKeyBitmap.Name = "textBoxKeyBitmap";
            this.textBoxKeyBitmap.Size = new System.Drawing.Size(756, 20);
            this.textBoxKeyBitmap.TabIndex = 18;
            this.textBoxKeyBitmap.Text = "112233445566778899aabbccddeeff00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Key (128/192/256 bit in HEX):";
            // 
            // buttonBitmapDecrypt
            // 
            this.buttonBitmapDecrypt.Location = new System.Drawing.Point(3, 122);
            this.buttonBitmapDecrypt.Name = "buttonBitmapDecrypt";
            this.buttonBitmapDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonBitmapDecrypt.TabIndex = 4;
            this.buttonBitmapDecrypt.Text = "Decrypt";
            this.buttonBitmapDecrypt.UseVisualStyleBackColor = true;
            this.buttonBitmapDecrypt.Click += new System.EventHandler(this.buttonBitmapDecrypt_Click);
            // 
            // buttonEncryptBitmap
            // 
            this.buttonEncryptBitmap.Location = new System.Drawing.Point(3, 93);
            this.buttonEncryptBitmap.Name = "buttonEncryptBitmap";
            this.buttonEncryptBitmap.Size = new System.Drawing.Size(75, 23);
            this.buttonEncryptBitmap.TabIndex = 3;
            this.buttonEncryptBitmap.Text = "Encrypt";
            this.buttonEncryptBitmap.UseVisualStyleBackColor = true;
            this.buttonEncryptBitmap.Click += new System.EventHandler(this.buttonEncryptBitmap_Click);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(293, 64);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(125, 125);
            this.pictureBoxResult.TabIndex = 2;
            this.pictureBoxResult.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(162, 64);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(125, 125);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // buttonBitmap
            // 
            this.buttonBitmap.Location = new System.Drawing.Point(3, 64);
            this.buttonBitmap.Name = "buttonBitmap";
            this.buttonBitmap.Size = new System.Drawing.Size(75, 23);
            this.buttonBitmap.TabIndex = 0;
            this.buttonBitmap.Text = "Open bitmap";
            this.buttonBitmap.UseVisualStyleBackColor = true;
            this.buttonBitmap.Click += new System.EventHandler(this.buttonBitmap_Click);
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(468, 64);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(450, 20);
            this.textBoxIV.TabIndex = 23;
            // 
            // buttonEncryptCFB
            // 
            this.buttonEncryptCFB.Location = new System.Drawing.Point(468, 93);
            this.buttonEncryptCFB.Name = "buttonEncryptCFB";
            this.buttonEncryptCFB.Size = new System.Drawing.Size(75, 23);
            this.buttonEncryptCFB.TabIndex = 24;
            this.buttonEncryptCFB.Text = "Encrypt CFB";
            this.buttonEncryptCFB.UseVisualStyleBackColor = true;
            this.buttonEncryptCFB.Click += new System.EventHandler(this.buttonEncryptCFB_Click);
            // 
            // buttonDecryptCFB
            // 
            this.buttonDecryptCFB.Location = new System.Drawing.Point(468, 122);
            this.buttonDecryptCFB.Name = "buttonDecryptCFB";
            this.buttonDecryptCFB.Size = new System.Drawing.Size(75, 23);
            this.buttonDecryptCFB.TabIndex = 25;
            this.buttonDecryptCFB.Text = "Decrypt CFB";
            this.buttonDecryptCFB.UseVisualStyleBackColor = true;
            this.buttonDecryptCFB.Click += new System.EventHandler(this.buttonDecryptCFB_Click);
            // 
            // labelIV
            // 
            this.labelIV.AutoSize = true;
            this.labelIV.Location = new System.Drawing.Point(465, 38);
            this.labelIV.Name = "labelIV";
            this.labelIV.Size = new System.Drawing.Size(20, 13);
            this.labelIV.TabIndex = 26;
            this.labelIV.Text = "IV:";
            // 
            // FormAes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 481);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAes";
            this.Text = "Cryptography AES";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textCypher;
        private System.Windows.Forms.TextBox textBoxDKey;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxResultE;
        private System.Windows.Forms.TextBox textBoxResultD;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonBitmap;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonEncryptBitmap;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonBitmapDecrypt;
        private System.Windows.Forms.TextBox textBoxKeyBitmap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelIV;
        private System.Windows.Forms.Button buttonDecryptCFB;
        private System.Windows.Forms.Button buttonEncryptCFB;
        private System.Windows.Forms.TextBox textBoxIV;
    }
}

