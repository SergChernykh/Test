﻿namespace CircuitCalculation
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripEditConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangeConectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeToParallelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeToSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteConectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddConectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddParallelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSeriesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewFreq = new System.Windows.Forms.DataGridView();
            this.ColumnFrequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImpedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownFrequencies = new System.Windows.Forms.NumericUpDown();
            this.labelError = new System.Windows.Forms.Label();
            this.pictureBoxCircuit = new System.Windows.Forms.PictureBox();
            this.treeViewCircuit = new System.Windows.Forms.TreeView();
            this.buttonNewSeriesCircuit = new System.Windows.Forms.Button();
            this.buttonNewParallelCircuit = new System.Windows.Forms.Button();
            this.contextMenuStripEditConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuit)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripEditConnection
            // 
            this.contextMenuStripEditConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeConectionToolStripMenuItem,
            this.DeleteConectionToolStripMenuItem,
            this.AddElementsToolStripMenuItem,
            this.AddConectionToolStripMenuItem});
            this.contextMenuStripEditConnection.Name = "contextMenuStrip1";
            this.contextMenuStripEditConnection.Size = new System.Drawing.Size(234, 114);
            // 
            // ChangeConectionToolStripMenuItem
            // 
            this.ChangeConectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangeToParallelToolStripMenuItem,
            this.ChangeToSeriesToolStripMenuItem});
            this.ChangeConectionToolStripMenuItem.Enabled = false;
            this.ChangeConectionToolStripMenuItem.Name = "ChangeConectionToolStripMenuItem";
            this.ChangeConectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.ChangeConectionToolStripMenuItem.Text = "Изменить на";
            // 
            // ChangeToParallelToolStripMenuItem
            // 
            this.ChangeToParallelToolStripMenuItem.Name = "ChangeToParallelToolStripMenuItem";
            this.ChangeToParallelToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ChangeToParallelToolStripMenuItem.Text = "Параллельное";
            this.ChangeToParallelToolStripMenuItem.Click += new System.EventHandler(this.ChangeToParallelToolStripMenuItem_Click);
            // 
            // ChangeToSeriesToolStripMenuItem
            // 
            this.ChangeToSeriesToolStripMenuItem.Name = "ChangeToSeriesToolStripMenuItem";
            this.ChangeToSeriesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.ChangeToSeriesToolStripMenuItem.Text = "Последовательное";
            this.ChangeToSeriesToolStripMenuItem.Click += new System.EventHandler(this.ChangeToSeriesToolStripMenuItem_Click);
            // 
            // DeleteConectionToolStripMenuItem
            // 
            this.DeleteConectionToolStripMenuItem.Name = "DeleteConectionToolStripMenuItem";
            this.DeleteConectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.DeleteConectionToolStripMenuItem.Text = "Удалить соединение";
            this.DeleteConectionToolStripMenuItem.Click += new System.EventHandler(this.DeleteConectionToolStripMenuItem_Click);
            // 
            // AddElementsToolStripMenuItem
            // 
            this.AddElementsToolStripMenuItem.Name = "AddElementsToolStripMenuItem";
            this.AddElementsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.AddElementsToolStripMenuItem.Text = "Добавить/Удалить элементы";
            this.AddElementsToolStripMenuItem.Click += new System.EventHandler(this.AddElementsToolStripMenuItem_Click);
            // 
            // AddConectionToolStripMenuItem
            // 
            this.AddConectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddParallelToolStripMenuItem1,
            this.AddSeriesToolStripMenuItem1});
            this.AddConectionToolStripMenuItem.Name = "AddConectionToolStripMenuItem";
            this.AddConectionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.AddConectionToolStripMenuItem.Text = "Добавить соединение";
            // 
            // AddParallelToolStripMenuItem1
            // 
            this.AddParallelToolStripMenuItem1.Name = "AddParallelToolStripMenuItem1";
            this.AddParallelToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.AddParallelToolStripMenuItem1.Text = "Параллельное";
            this.AddParallelToolStripMenuItem1.Click += new System.EventHandler(this.AddParallelToolStripMenuItem1_Click);
            // 
            // AddSeriesToolStripMenuItem1
            // 
            this.AddSeriesToolStripMenuItem1.Name = "AddSeriesToolStripMenuItem1";
            this.AddSeriesToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
            this.AddSeriesToolStripMenuItem1.Text = "Последовательное";
            this.AddSeriesToolStripMenuItem1.Click += new System.EventHandler(this.AddSeriesToolStripMenuItem1_Click);
            // 
            // dataGridViewFreq
            // 
            this.dataGridViewFreq.AllowUserToAddRows = false;
            this.dataGridViewFreq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFreq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFrequence,
            this.ColumnImpedance});
            this.dataGridViewFreq.Location = new System.Drawing.Point(32, 308);
            this.dataGridViewFreq.Name = "dataGridViewFreq";
            this.dataGridViewFreq.RowHeadersVisible = false;
            this.dataGridViewFreq.Size = new System.Drawing.Size(265, 247);
            this.dataGridViewFreq.TabIndex = 3;
            // 
            // ColumnFrequence
            // 
            this.ColumnFrequence.HeaderText = "Частота, кГц";
            this.ColumnFrequence.Name = "ColumnFrequence";
            // 
            // ColumnImpedance
            // 
            this.ColumnImpedance.HeaderText = "Импеданс";
            this.ColumnImpedance.Name = "ColumnImpedance";
            this.ColumnImpedance.ReadOnly = true;
            this.ColumnImpedance.Width = 120;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(316, 513);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "Расчет";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(429, 513);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Соединения, составляющие цепь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Количество частот";
            // 
            // numericUpDownFrequencies
            // 
            this.numericUpDownFrequencies.Location = new System.Drawing.Point(208, 264);
            this.numericUpDownFrequencies.Name = "numericUpDownFrequencies";
            this.numericUpDownFrequencies.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownFrequencies.TabIndex = 12;
            this.numericUpDownFrequencies.ValueChanged += new System.EventHandler(this.numericUpDownFrequencies_ValueChanged);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(52, 327);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 13);
            this.labelError.TabIndex = 13;
            // 
            // pictureBoxCircuit
            // 
            this.pictureBoxCircuit.BackColor = System.Drawing.Color.White;
            this.pictureBoxCircuit.InitialImage = null;
            this.pictureBoxCircuit.Location = new System.Drawing.Point(316, 51);
            this.pictureBoxCircuit.Name = "pictureBoxCircuit";
            this.pictureBoxCircuit.Size = new System.Drawing.Size(670, 437);
            this.pictureBoxCircuit.TabIndex = 14;
            this.pictureBoxCircuit.TabStop = false;
            this.pictureBoxCircuit.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCircuit_Paint);
            // 
            // treeViewCircuit
            // 
            this.treeViewCircuit.Location = new System.Drawing.Point(26, 90);
            this.treeViewCircuit.Name = "treeViewCircuit";
            this.treeViewCircuit.Size = new System.Drawing.Size(275, 136);
            this.treeViewCircuit.TabIndex = 19;
            this.treeViewCircuit.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewCircuit_AfterSelect);
            // 
            // buttonNewSeriesCircuit
            // 
            this.buttonNewSeriesCircuit.Location = new System.Drawing.Point(26, 24);
            this.buttonNewSeriesCircuit.Name = "buttonNewSeriesCircuit";
            this.buttonNewSeriesCircuit.Size = new System.Drawing.Size(142, 23);
            this.buttonNewSeriesCircuit.TabIndex = 20;
            this.buttonNewSeriesCircuit.Text = "Последовательная цепь";
            this.buttonNewSeriesCircuit.UseVisualStyleBackColor = true;
            this.buttonNewSeriesCircuit.Click += new System.EventHandler(this.buttonNewCircuit_Click);
            // 
            // buttonNewParallelCircuit
            // 
            this.buttonNewParallelCircuit.Location = new System.Drawing.Point(180, 24);
            this.buttonNewParallelCircuit.Name = "buttonNewParallelCircuit";
            this.buttonNewParallelCircuit.Size = new System.Drawing.Size(121, 23);
            this.buttonNewParallelCircuit.TabIndex = 21;
            this.buttonNewParallelCircuit.Text = "Параллельная цепь";
            this.buttonNewParallelCircuit.UseVisualStyleBackColor = true;
            this.buttonNewParallelCircuit.Click += new System.EventHandler(this.buttonNewParallelCircuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 567);
            this.Controls.Add(this.buttonNewParallelCircuit);
            this.Controls.Add(this.buttonNewSeriesCircuit);
            this.Controls.Add(this.treeViewCircuit);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.numericUpDownFrequencies);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dataGridViewFreq);
            this.Controls.Add(this.pictureBoxCircuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Расчет импеданса цепи";
            this.contextMenuStripEditConnection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFreq;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownFrequencies;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImpedance;
        private System.Windows.Forms.PictureBox pictureBoxCircuit;
        private System.Windows.Forms.TreeView treeViewCircuit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditConnection;
        private System.Windows.Forms.ToolStripMenuItem ChangeConectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteConectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeToParallelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeToSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddConectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddParallelToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AddSeriesToolStripMenuItem1;
        private System.Windows.Forms.Button buttonNewSeriesCircuit;
        private System.Windows.Forms.Button buttonNewParallelCircuit;



    }
}

