namespace CircuitCalculation
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
            this.dataGridViewFreq = new System.Windows.Forms.DataGridView();
            this.ColumnFrequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrefix = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ColumnImpedance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownFrequencies = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxCircuit = new System.Windows.Forms.PictureBox();
            this.treeViewCircuit = new System.Windows.Forms.TreeView();
            this.buttonNewSeriesCircuit = new System.Windows.Forms.Button();
            this.buttonNewParallelCircuit = new System.Windows.Forms.Button();
            this.buttonCircuitOne = new System.Windows.Forms.Button();
            this.buttonCircuitTwo = new System.Windows.Forms.Button();
            this.buttonCircuitThree = new System.Windows.Forms.Button();
            this.buttonCircuitFour = new System.Windows.Forms.Button();
            this.buttonCircuitFive = new System.Windows.Forms.Button();
            this.contextMenuStripEditElement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteConectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSeriesCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddParallelCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddResistorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddCapacitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddInductorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEditConnection = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequencies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuit)).BeginInit();
            this.contextMenuStripEditElement.SuspendLayout();
            this.contextMenuStripEditConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewFreq
            // 
            this.dataGridViewFreq.AllowUserToAddRows = false;
            this.dataGridViewFreq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFreq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFrequence,
            this.ColumnPrefix,
            this.ColumnImpedance});
            this.dataGridViewFreq.Location = new System.Drawing.Point(26, 308);
            this.dataGridViewFreq.Name = "dataGridViewFreq";
            this.dataGridViewFreq.RowHeadersVisible = false;
            this.dataGridViewFreq.Size = new System.Drawing.Size(284, 247);
            this.dataGridViewFreq.TabIndex = 3;
            // 
            // ColumnFrequence
            // 
            this.ColumnFrequence.HeaderText = "Частота";
            this.ColumnFrequence.Name = "ColumnFrequence";
            // 
            // ColumnPrefix
            // 
            this.ColumnPrefix.HeaderText = "";
            this.ColumnPrefix.Name = "ColumnPrefix";
            this.ColumnPrefix.Width = 60;
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
            this.buttonOK.Location = new System.Drawing.Point(26, 575);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "Расчет";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(235, 575);
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
            // pictureBoxCircuit
            // 
            this.pictureBoxCircuit.BackColor = System.Drawing.Color.White;
            this.pictureBoxCircuit.InitialImage = null;
            this.pictureBoxCircuit.Location = new System.Drawing.Point(327, 57);
            this.pictureBoxCircuit.Name = "pictureBoxCircuit";
            this.pictureBoxCircuit.Size = new System.Drawing.Size(988, 550);
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
            this.buttonNewSeriesCircuit.Click += new System.EventHandler(this.buttonNewSeriesCircuit_Click);
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
            // buttonCircuitOne
            // 
            this.buttonCircuitOne.Location = new System.Drawing.Point(345, 12);
            this.buttonCircuitOne.Name = "buttonCircuitOne";
            this.buttonCircuitOne.Size = new System.Drawing.Size(75, 23);
            this.buttonCircuitOne.TabIndex = 22;
            this.buttonCircuitOne.Text = "Цепь 1";
            this.buttonCircuitOne.UseVisualStyleBackColor = true;
            this.buttonCircuitOne.Click += new System.EventHandler(this.buttonCircuitOne_Click);
            // 
            // buttonCircuitTwo
            // 
            this.buttonCircuitTwo.Location = new System.Drawing.Point(450, 12);
            this.buttonCircuitTwo.Name = "buttonCircuitTwo";
            this.buttonCircuitTwo.Size = new System.Drawing.Size(75, 23);
            this.buttonCircuitTwo.TabIndex = 23;
            this.buttonCircuitTwo.Text = "Цепь 2";
            this.buttonCircuitTwo.UseVisualStyleBackColor = true;
            this.buttonCircuitTwo.Click += new System.EventHandler(this.buttonCircuitTwo_Click);
            // 
            // buttonCircuitThree
            // 
            this.buttonCircuitThree.Location = new System.Drawing.Point(551, 12);
            this.buttonCircuitThree.Name = "buttonCircuitThree";
            this.buttonCircuitThree.Size = new System.Drawing.Size(75, 23);
            this.buttonCircuitThree.TabIndex = 24;
            this.buttonCircuitThree.Text = "Цепь 3";
            this.buttonCircuitThree.UseVisualStyleBackColor = true;
            this.buttonCircuitThree.Click += new System.EventHandler(this.buttonCircuitThree_Click);
            // 
            // buttonCircuitFour
            // 
            this.buttonCircuitFour.Location = new System.Drawing.Point(652, 12);
            this.buttonCircuitFour.Name = "buttonCircuitFour";
            this.buttonCircuitFour.Size = new System.Drawing.Size(75, 23);
            this.buttonCircuitFour.TabIndex = 25;
            this.buttonCircuitFour.Text = "Цепь 4";
            this.buttonCircuitFour.UseVisualStyleBackColor = true;
            this.buttonCircuitFour.Click += new System.EventHandler(this.buttonCircuitFour_Click);
            // 
            // buttonCircuitFive
            // 
            this.buttonCircuitFive.Location = new System.Drawing.Point(757, 12);
            this.buttonCircuitFive.Name = "buttonCircuitFive";
            this.buttonCircuitFive.Size = new System.Drawing.Size(75, 23);
            this.buttonCircuitFive.TabIndex = 26;
            this.buttonCircuitFive.Text = "Цепь 5";
            this.buttonCircuitFive.UseVisualStyleBackColor = true;
            this.buttonCircuitFive.Click += new System.EventHandler(this.buttonCircuitFive_Click);
            // 
            // contextMenuStripEditElement
            // 
            this.contextMenuStripEditElement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editElementToolStripMenuItem,
            this.deleteElementToolStripMenuItem});
            this.contextMenuStripEditElement.Name = "contextMenuStripEditElement";
            this.contextMenuStripEditElement.Size = new System.Drawing.Size(204, 70);
            // 
            // editElementToolStripMenuItem
            // 
            this.editElementToolStripMenuItem.Name = "editElementToolStripMenuItem";
            this.editElementToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.editElementToolStripMenuItem.Text = "Редактировать элемент";
            this.editElementToolStripMenuItem.Click += new System.EventHandler(this.editElementToolStripMenuItem_Click);
            // 
            // deleteElementToolStripMenuItem
            // 
            this.deleteElementToolStripMenuItem.Name = "deleteElementToolStripMenuItem";
            this.deleteElementToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteElementToolStripMenuItem.Text = "Удалить элемент";
            this.deleteElementToolStripMenuItem.Click += new System.EventHandler(this.deleteElementToolStripMenuItem_Click);
            // 
            // DeleteConectionToolStripMenuItem
            // 
            this.DeleteConectionToolStripMenuItem.Name = "DeleteConectionToolStripMenuItem";
            this.DeleteConectionToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.DeleteConectionToolStripMenuItem.Text = "Удалить соединение/элемент";
            this.DeleteConectionToolStripMenuItem.Click += new System.EventHandler(this.DeleteConnectionToolStripMenuItem_Click);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCircuitToolStripMenuItem,
            this.AddElementToolStripMenuItem});
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.AddToolStripMenuItem.Text = "Добавить";
            // 
            // AddCircuitToolStripMenuItem
            // 
            this.AddCircuitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSeriesCircuitToolStripMenuItem,
            this.AddParallelCircuitToolStripMenuItem});
            this.AddCircuitToolStripMenuItem.Name = "AddCircuitToolStripMenuItem";
            this.AddCircuitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddCircuitToolStripMenuItem.Text = "Соединение";
            // 
            // AddSeriesCircuitToolStripMenuItem
            // 
            this.AddSeriesCircuitToolStripMenuItem.Name = "AddSeriesCircuitToolStripMenuItem";
            this.AddSeriesCircuitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.AddSeriesCircuitToolStripMenuItem.Text = "Последовательное";
            this.AddSeriesCircuitToolStripMenuItem.Click += new System.EventHandler(this.AddSeriesCircuitToolStripMenuItem_Click);
            // 
            // AddParallelCircuitToolStripMenuItem
            // 
            this.AddParallelCircuitToolStripMenuItem.Name = "AddParallelCircuitToolStripMenuItem";
            this.AddParallelCircuitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.AddParallelCircuitToolStripMenuItem.Text = "Параллельное";
            this.AddParallelCircuitToolStripMenuItem.Click += new System.EventHandler(this.AddParallelCircuitToolStripMenuItem_Click);
            // 
            // AddElementToolStripMenuItem
            // 
            this.AddElementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddResistorToolStripMenuItem,
            this.AddCapacitorToolStripMenuItem,
            this.AddInductorToolStripMenuItem});
            this.AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem";
            this.AddElementToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddElementToolStripMenuItem.Text = "Элемент";
            // 
            // AddResistorToolStripMenuItem
            // 
            this.AddResistorToolStripMenuItem.Name = "AddResistorToolStripMenuItem";
            this.AddResistorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddResistorToolStripMenuItem.Text = "Резистор";
            this.AddResistorToolStripMenuItem.Click += new System.EventHandler(this.AddResistorToolStripMenuItem_Click);
            // 
            // AddCapacitorToolStripMenuItem
            // 
            this.AddCapacitorToolStripMenuItem.Name = "AddCapacitorToolStripMenuItem";
            this.AddCapacitorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddCapacitorToolStripMenuItem.Text = "Конденсатор";
            this.AddCapacitorToolStripMenuItem.Click += new System.EventHandler(this.AddCapacitorToolStripMenuItem_Click);
            // 
            // AddInductorToolStripMenuItem
            // 
            this.AddInductorToolStripMenuItem.Name = "AddInductorToolStripMenuItem";
            this.AddInductorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddInductorToolStripMenuItem.Text = "Катушка";
            this.AddInductorToolStripMenuItem.Click += new System.EventHandler(this.AddInductorToolStripMenuItem_Click);
            // 
            // contextMenuStripEditConnection
            // 
            this.contextMenuStripEditConnection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DeleteConectionToolStripMenuItem});
            this.contextMenuStripEditConnection.Name = "contextMenuStrip1";
            this.contextMenuStripEditConnection.Size = new System.Drawing.Size(238, 48);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 619);
            this.Controls.Add(this.buttonCircuitFive);
            this.Controls.Add(this.buttonCircuitFour);
            this.Controls.Add(this.buttonCircuitThree);
            this.Controls.Add(this.buttonCircuitTwo);
            this.Controls.Add(this.buttonCircuitOne);
            this.Controls.Add(this.buttonNewParallelCircuit);
            this.Controls.Add(this.buttonNewSeriesCircuit);
            this.Controls.Add(this.treeViewCircuit);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrequencies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCircuit)).EndInit();
            this.contextMenuStripEditElement.ResumeLayout(false);
            this.contextMenuStripEditConnection.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox pictureBoxCircuit;
        private System.Windows.Forms.TreeView treeViewCircuit;
        private System.Windows.Forms.Button buttonNewSeriesCircuit;
        private System.Windows.Forms.Button buttonNewParallelCircuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrequence;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImpedance;
        private System.Windows.Forms.Button buttonCircuitOne;
        private System.Windows.Forms.Button buttonCircuitTwo;
        private System.Windows.Forms.Button buttonCircuitThree;
        private System.Windows.Forms.Button buttonCircuitFour;
        private System.Windows.Forms.Button buttonCircuitFive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditElement;
        private System.Windows.Forms.ToolStripMenuItem editElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteConectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddSeriesCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddParallelCircuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddResistorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddCapacitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddInductorToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripEditConnection;



    }
}

