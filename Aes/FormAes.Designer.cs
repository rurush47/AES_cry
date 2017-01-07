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
            this.panel2 = new System.Windows.Forms.Panel();
            this.textCypher = new System.Windows.Forms.TextBox();
            this.textBoxDKey = new System.Windows.Forms.TextBox();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxResultE = new System.Windows.Forms.TextBox();
            this.textBoxResultD = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // textBoxResultE
            // 
            this.textBoxResultE.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxResultE.Location = new System.Drawing.Point(163, 86);
            this.textBoxResultE.Name = "textBoxResultE";
            this.textBoxResultE.Size = new System.Drawing.Size(757, 20);
            this.textBoxResultE.TabIndex = 15;
            // 
            // textBoxResultD
            // 
            this.textBoxResultD.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxResultD.Location = new System.Drawing.Point(162, 83);
            this.textBoxResultD.Name = "textBoxResultD";
            this.textBoxResultD.Size = new System.Drawing.Size(757, 20);
            this.textBoxResultD.TabIndex = 16;
            // 
            // FormAes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 281);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormAes";
            this.Text = "Cryptography AES";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
    }
}

