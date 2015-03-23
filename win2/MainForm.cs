
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

using CircuitCalculation.Elements;

namespace CircuitCalculation
{
    
    public partial class MainForm : Form
    {
        /// <summary>
        /// 0 - резистор, 1 - конденсатор, 2 - катушка
        /// </summary>
        readonly string[] Elements = { "Резистор",
                                  "Конденсатор",
                                  "Катушка"};

        /// <summary>
        /// 0 - последовательное, 1 - параллельное
        /// </summary>
        readonly string[] Circuits = { "Последовательное", 
                                  "Параллельное"};

        private readonly Dictionary<PrefixType, string> Prefix;

        private ICircuit Circuit;
        private ICircuit SelectedCircuit;
        private double[] frequencies;
        public MainForm()
        {
            InitializeComponent();
            Prefix = new Dictionary<PrefixType, string>();
            Prefix.Add(PrefixType.Giga, "Giga");
            Prefix.Add(PrefixType.Mega, "Mega");
            Prefix.Add(PrefixType.Kilo, "Kilo");
            Prefix.Add(PrefixType.Not, "Not");
            Prefix.Add(PrefixType.Mili, "Mili");
            Prefix.Add(PrefixType.Micro, "Micro");
            Prefix.Add(PrefixType.Nano, "Nano");
            foreach (string str in Prefix.Values)
            {
                this.ColumnPrefix.Items.Add(str);
            }
        }

        

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDownFrequencies_ValueChanged(object sender, EventArgs e)
        {
            int frequenciesCount = (int)numericUpDownFrequencies.Value;
            if (frequenciesCount > this.dataGridViewFreq.RowCount)
            {
                this.dataGridViewFreq.Rows.Add(frequenciesCount - this.dataGridViewFreq.RowCount);
            }
            else
            {
                for (int i = this.dataGridViewFreq.RowCount; i > frequenciesCount; i--)
                {
                   this.dataGridViewFreq.Rows.RemoveAt(i - 1);
                }

            }
        }

        
        private void Circuit_CircuitChanged(object sender, EventArgs e)
        {
            if (frequencies != null)
            {
                Calculate();
            }
            
        }

        private void Calculate()
        {
            Complex[] z = new Complex[frequencies.Length];

            z = Circuit.CalculateZ(frequencies);

            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                this.dataGridViewFreq[2, i].Value = z[i];
            }
        }

        
        private void buttonOK_Click(object sender, EventArgs e)
        {       
            frequencies = new double[this.dataGridViewFreq.RowCount];
            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                try
                {
                    frequencies[i] = Convert.ToDouble(this.dataGridViewFreq[0, i].Value) *
                        Multiplier.GetMultiPlier((PrefixType)Enum.Parse(typeof(PrefixType), this.dataGridViewFreq[1, i].Value.ToString()));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Не все поля заполнены корректно");
                }
                
            }
            Calculate();
        }

        
        private void treeViewCircuit_AfterSelect(object sender, TreeViewEventArgs e)
        {

            this.SelectedCircuit = this.Circuit;
            if (e.Node.Level > 0)
            {
                int[] path = new int[e.Node.Level];
                TreeNode currentNode = e.Node;
                for (int i = e.Node.Level - 1; i > -1; i--)
                {
                    path[i] = currentNode.Index;
                    currentNode = currentNode.Parent;
                }
                for (int i = 0; i < e.Node.Level; i++)
                {
                    SelectedCircuit = SelectedCircuit.SubCircuits[path[i]];
                }
            }
            if (SelectedCircuit is IElement)
            {
                this.EditOfElementToolStripMenuItem.Enabled = true;
                this.AddToolStripMenuItem.Enabled = false;
                this.ChangeConectionToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.EditOfElementToolStripMenuItem.Enabled = false;
                this.AddToolStripMenuItem.Enabled = true;
                this.ChangeConectionToolStripMenuItem.Enabled = true;
            }
            
        }

        

        #region Создание новой цепи
        private void buttonNewParallelCircuit_Click(object sender, EventArgs e)
        {
            if (this.treeViewCircuit.Nodes.Count != 0)
            {
                this.treeViewCircuit.Nodes.Remove(this.treeViewCircuit.Nodes[0]);
            }
            TreeNode node = new TreeNode(Circuits[1]);
            node.ContextMenuStrip = this.contextMenuStripEditConnection;
            this.treeViewCircuit.Nodes.Add(node);

            Circuit = new ParallelCircuit(null);
            Circuit.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
        }

        private void buttonNewCircuit_Click(object sender, EventArgs e)
        {
            if (this.treeViewCircuit.Nodes.Count != 0)
            {
                this.treeViewCircuit.Nodes.Remove(this.treeViewCircuit.Nodes[0]);
            }
            TreeNode node = new TreeNode(Circuits[0]);
            node.ContextMenuStrip = this.contextMenuStripEditConnection;
            this.treeViewCircuit.Nodes.Add(node);

            Circuit = new SeriesCircuit(null);
            Circuit.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
        }
        #endregion

        #region Редактирование цепи
        private void ChangeToParallelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeViewCircuit.SelectedNode.Text = Circuits[1];
            ParallelCircuit newCircuit;
            if (SelectedCircuit.ParentCircuit == null)
            {
                newCircuit = new ParallelCircuit(null);
            }
            else
            {
                newCircuit = new ParallelCircuit(SelectedCircuit.ParentCircuit);
                SelectedCircuit.ParentCircuit.SubCircuits.Add(newCircuit);
            }
            newCircuit.SubCircuits = SelectedCircuit.SubCircuits;
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            
            SelectedCircuit = newCircuit;
        }

        private void ChangeToSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeViewCircuit.SelectedNode.Text = Circuits[0];
            SeriesCircuit newCircuit;
            if (SelectedCircuit.ParentCircuit == null)
            {
                newCircuit = new SeriesCircuit(null);
            }
            else
            {
                newCircuit = new SeriesCircuit(SelectedCircuit.ParentCircuit);
                SelectedCircuit.ParentCircuit.SubCircuits.Add(newCircuit);
            }
            newCircuit.SubCircuits = SelectedCircuit.SubCircuits;
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            
            SelectedCircuit = newCircuit;
            
            
        }

        private void DeleteConectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeViewCircuit.SelectedNode.Parent != null)
            {
                this.SelectedCircuit.ParentCircuit.SubCircuits.Remove(SelectedCircuit);
                this.treeViewCircuit.SelectedNode.Remove(); 
            }
            
        }

        private void EditOfElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditOfElement edit = new EditOfElement((IElement)SelectedCircuit);
            edit.ShowDialog();
        }

        private void AddSeriesCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = Circuits[0];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            SeriesCircuit newCircuit = new SeriesCircuit(SelectedCircuit);
            newCircuit.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newCircuit);
        }

        private void AddParallelCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = Circuits[1];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            ParallelCircuit newCircuit = new ParallelCircuit(SelectedCircuit);
            newCircuit.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newCircuit);
        }

        private void AddResistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = Elements[0];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Resistor newElement = new Resistor(SelectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        private void AddCapacitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = Elements[1];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Capacitor newElement = new Capacitor(SelectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        private void AddInductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            node.Text = Elements[2];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Inductor newElement = new Inductor(SelectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        #endregion

        #region Отрисовка цепи
        private void pictureBoxCircuit_Paint(object sender, PaintEventArgs e)
        {
            
            //if (this.Circuit.Elements.Count != 0)
            //{
            //    Point pointBegin = new Point(0, this.pictureBoxCircuit.Height / 2);
            //    Point pointEnd = new Point(pointBegin.X + 50, pointBegin.Y);
            //    foreach (var circuit in this.Circuits)
            //    {
            //        if (circuit.ConnectionType == ConnectionType.Series)
            //        {
            //            foreach (var element in circuit.Elements)
            //            {
            //                e.Graphics.DrawImage(GetImageElement(element), pointBegin.X, pointBegin.Y, 50, 50);
            //                pointBegin.X = pointBegin.X + 100;
            //                e.Graphics.DrawLine(Pens.Black, pointEnd.X, pointEnd.Y + 25, pointBegin.X, pointBegin.Y + 25);
            //                pointEnd.X = pointEnd.X + 100;
            //            }
            //        }
            //        else
            //        {
            //            Point X = new Point(pointBegin.X, pointBegin.Y);
            //            Point Y = new Point(pointEnd.X, pointEnd.Y);
            //            foreach (var element in circuit.Elements)
            //            {

            //                e.Graphics.DrawImage(GetImageElement(element), pointBegin.X, pointBegin.Y, 50, 50);
            //                if (element != circuit.Elements[0])
            //                {
            //                    e.Graphics.DrawLine(Pens.Black, pointBegin.X - 2, pointBegin.Y + 25, pointBegin.X - 2, pointBegin.Y - 25);
            //                    e.Graphics.DrawLine(Pens.Black, pointEnd.X + 2, pointEnd.Y + 25, pointEnd.X + 2, pointEnd.Y - 25);
            //                }

            //                pointBegin.Y = pointBegin.Y + 50;
            //                pointEnd.Y = pointEnd.Y + 50;

            //            }
            //            pointBegin = X;
            //            pointEnd = Y;
            //            pointBegin.X = pointBegin.X + 100;
            //            e.Graphics.DrawLine(Pens.Black, pointEnd.X, pointEnd.Y + 25, pointBegin.X, pointBegin.Y + 25);

            //        }
            //    }
            //}

        }
        #endregion

        

        
        

    }
}
