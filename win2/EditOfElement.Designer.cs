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
            this.dataGridViewElements = new System.Windows.Forms.DataGridView();
            this.ColumnTypeElement = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAllDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.numericUpDownSelection = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelection)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewElements
            // 
            this.dataGridViewElements.AllowUserToAddRows = false;
            this.dataGridViewElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTypeElement,
            this.ColumnName,
            this.ColumnValue});
            this.dataGridViewElements.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewElements.Name = "dataGridViewElements";
            this.dataGridViewElements.RowHeadersVisible = false;
            this.dataGridViewElements.Size = new System.Drawing.Size(324, 210);
            this.dataGridViewElements.TabIndex = 0;
            // 
            // ColumnTypeElement
            // 
            this.ColumnTypeElement.HeaderText = "Тип элемента";
            this.ColumnTypeElement.Items.AddRange(new object[] {
            "Конденсатор, нФ",
            "Катушка, мкГн",
            "Резистор, Ом"});
            this.ColumnTypeElement.Name = "ColumnTypeElement";
            this.ColumnTypeElement.Width = 120;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Имя элемента";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Номинал элемента";
            this.ColumnValue.Name = "ColumnValue";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(391, 157);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(391, 199);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonAllDelete
            // 
            this.buttonAllDelete.Location = new System.Drawing.Point(370, 117);
            this.buttonAllDelete.Name = "buttonAllDelete";
            this.buttonAllDelete.Size = new System.Drawing.Size(118, 23);
            this.buttonAllDelete.TabIndex = 5;
            this.buttonAllDelete.Text = "Очистить список";
            this.buttonAllDelete.UseVisualStyleBackColor = true;
            this.buttonAllDelete.Click += new System.EventHandler(this.buttonAllDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(370, 27);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Добавить элемент";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(370, 68);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(118, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Удалить элемент";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // numericUpDownSelection
            // 
            this.numericUpDownSelection.Location = new System.Drawing.Point(498, 71);
            this.numericUpDownSelection.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSelection.Name = "numericUpDownSelection";
            this.numericUpDownSelection.Size = new System.Drawing.Size(35, 20);
            this.numericUpDownSelection.TabIndex = 8;
            // 
            // EditOfElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 244);
            this.Controls.Add(this.numericUpDownSelection);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonAllDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridViewElements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditOfElement";
            this.Text = "Список элементов";
            this.Load += new System.EventHandler(this.EditOfElement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewElements;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAllDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown numericUpDownSelection;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnTypeElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;

    }
}