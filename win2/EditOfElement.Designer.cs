namespace CircuitCalculation
{
    partial class EditOfElement
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxNameOfElement = new System.Windows.Forms.TextBox();
            this.textBoxValueOfElement = new System.Windows.Forms.TextBox();
            this.comboBoxPrefix = new System.Windows.Forms.ComboBox();
            this.labelNameOfElement = new System.Windows.Forms.Label();
            this.labelValueOfElement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(383, 14);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(383, 56);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxNameOfElement
            // 
            this.textBoxNameOfElement.Location = new System.Drawing.Point(143, 17);
            this.textBoxNameOfElement.Name = "textBoxNameOfElement";
            this.textBoxNameOfElement.Size = new System.Drawing.Size(118, 20);
            this.textBoxNameOfElement.TabIndex = 10;
            // 
            // textBoxValueOfElement
            // 
            this.textBoxValueOfElement.Location = new System.Drawing.Point(143, 59);
            this.textBoxValueOfElement.Name = "textBoxValueOfElement";
            this.textBoxValueOfElement.Size = new System.Drawing.Size(118, 20);
            this.textBoxValueOfElement.TabIndex = 11;
            this.textBoxValueOfElement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValueOfElement_KeyPress);
            // 
            // comboBoxPrefix
            // 
            this.comboBoxPrefix.FormattingEnabled = true;
            this.comboBoxPrefix.Location = new System.Drawing.Point(285, 59);
            this.comboBoxPrefix.Name = "comboBoxPrefix";
            this.comboBoxPrefix.Size = new System.Drawing.Size(64, 21);
            this.comboBoxPrefix.TabIndex = 12;
            // 
            // labelNameOfElement
            // 
            this.labelNameOfElement.AutoSize = true;
            this.labelNameOfElement.Location = new System.Drawing.Point(22, 20);
            this.labelNameOfElement.Name = "labelNameOfElement";
            this.labelNameOfElement.Size = new System.Drawing.Size(81, 13);
            this.labelNameOfElement.TabIndex = 14;
            this.labelNameOfElement.Text = "Имя элемента";
            // 
            // labelValueOfElement
            // 
            this.labelValueOfElement.AutoSize = true;
            this.labelValueOfElement.Location = new System.Drawing.Point(22, 62);
            this.labelValueOfElement.Name = "labelValueOfElement";
            this.labelValueOfElement.Size = new System.Drawing.Size(105, 13);
            this.labelValueOfElement.TabIndex = 15;
            this.labelValueOfElement.Text = "Номинал элемента";
            // 
            // EditOfElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 100);
            this.Controls.Add(this.labelValueOfElement);
            this.Controls.Add(this.labelNameOfElement);
            this.Controls.Add(this.comboBoxPrefix);
            this.Controls.Add(this.textBoxValueOfElement);
            this.Controls.Add(this.textBoxNameOfElement);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditOfElement";
            this.Text = "Элемент";
            this.Load += new System.EventHandler(this.EditOfElement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxNameOfElement;
        private System.Windows.Forms.TextBox textBoxValueOfElement;
        private System.Windows.Forms.ComboBox comboBoxPrefix;
        private System.Windows.Forms.Label labelNameOfElement;
        private System.Windows.Forms.Label labelValueOfElement;

    }
}