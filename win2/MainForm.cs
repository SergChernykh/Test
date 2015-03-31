
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

using CircuitCalculation.Elements;
using CircuitCalculation.Circuit;

namespace CircuitCalculation
{
    //TODO: несколько готовых программных серкитов для быстрого удобного тестирования!!!
    public partial class MainForm : Form
    {
        /// <summary>
        /// 0 - резистор, 1 - конденсатор, 2 - катушка
        /// </summary>
        readonly string[] Elements = { "Резистор",
                                  "Конденсатор",
                                  "Катушка"};

        //TODO: может, сделать поле Description в Circuit?
        /// <summary>
        /// 0 - последовательное, 1 - параллельное
        /// </summary>
        readonly string[] Circuits = { "Последовательное", 
                                  "Параллельное"};

        //TODO: где xml-комментарий?
        private readonly Dictionary<PrefixType, string> Prefix;

        //TODO: где xml-комментарий?
        //TODO: именование!
        private ICircuit Circuit;
        //TODO: где xml-комментарий?
        //TODO: именование!
        private ICircuit SelectedCircuit;
        //TODO: где xml-комментарий?
        //TODO: именование!
        private double[] frequencies;
        public MainForm()
        {
            InitializeComponent();
            Prefix = new Dictionary<PrefixType, string>();
            Prefix.Add(PrefixType.Giga, PrefixType.Giga.ToString());
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

        //TODO: зачем столько пустых строк!
        private void Circuit_CircuitChanged(object sender, EventArgs e)
        {
            if (frequencies != null)
            {
                Calculate();
            }
            this.pictureBoxCircuit.Invalidate();
            
        }

        //TODO: где xml-комментарий?
        //TODO: посчитать что? Импеданс или отрисовку?
        private void Calculate()
        {
            //TODO: лучше var
            //TODO: зачем выделять память под объект, если ниже тут же присваивается другой?
            //Complex[] z = new Complex[frequencies.Length];

            var z = Circuit.CalculateZ(frequencies);

            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                this.dataGridViewFreq[2, i].Value = z[i];
            }
        }

        //TODO: зачем столько пустых строк!
        private void buttonOK_Click(object sender, EventArgs e)
        {       
            frequencies = new double[this.dataGridViewFreq.RowCount];
            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                try
                {
                    frequencies[i] = Convert.ToDouble(this.dataGridViewFreq[0, i].Value)*
                        Multiplier.GetMultiplier((PrefixType)Enum.Parse(typeof(PrefixType), this.dataGridViewFreq[1, i].Value.ToString()));
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
            //TODO: сделать проще без дублирования
            if (SelectedCircuit is Element)
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

        //TODO: зачем столько пустых строк!
        //TODO: зачем столько пустых строк!
        #region Создание новой цепи
        private void buttonNewParallelCircuit_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с нижним обработчиком
            if (this.treeViewCircuit.Nodes.Count != 0)
            {
                this.treeViewCircuit.Nodes.Remove(this.treeViewCircuit.Nodes[0]);
            }
            TreeNode node = new TreeNode(Circuits[1]);
            node.ContextMenuStrip = this.contextMenuStripEditConnection;
            this.treeViewCircuit.Nodes.Add(node);

            Circuit = new ParallelCircuit(null);
            Circuit.CircuitChanged += Circuit_CircuitChanged;
        }

        //TODO: именование обработчика и кнопки. Есть NewCircuit, а выше NewParallelCircuit
        private void buttonNewCircuit_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с верхним обработчиком
            if (this.treeViewCircuit.Nodes.Count != 0)
            {
                this.treeViewCircuit.Nodes.Remove(this.treeViewCircuit.Nodes[0]);
            }
            TreeNode node = new TreeNode(Circuits[0]);
            node.ContextMenuStrip = this.contextMenuStripEditConnection;
            this.treeViewCircuit.Nodes.Add(node);

            Circuit = new SeriesCircuit(null);
            Circuit.CircuitChanged += Circuit_CircuitChanged;
        }
        #endregion

        //TODO: где //***********************************************************************************?

        #region - Редактирование цепи -
        private void ChangeToParallelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с нижним обработчиком
            //TODO: обращение по индексу не очевидно
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
            //TODO: дублирование с верхним обработчиком
            //TODO: обращение по индексу не очевидно
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

        
        private void DeleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeViewCircuit.SelectedNode.Parent != null)
            {
                this.SelectedCircuit.ParentCircuit.SubCircuits.Remove(SelectedCircuit);
                this.treeViewCircuit.SelectedNode.Remove(); 
            }
            
        }

        private void EditOfElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditElementForm edit = new EditElementForm((Element)SelectedCircuit);
            edit.ShowDialog();
        }

        private void AddSeriesCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с нижним обработчиком
            TreeNode node = new TreeNode();
            //TODO: обращение по индексу не очевидно
            node.Text = Circuits[0];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            SeriesCircuit newCircuit = new SeriesCircuit(SelectedCircuit);
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            SelectedCircuit.SubCircuits.Add(newCircuit);
        }

        private void AddParallelCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с верхним обработчиком
            TreeNode node = new TreeNode();
            //TODO: обращение по индексу не очевидно
            node.Text = Circuits[1];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);
            
            ParallelCircuit newCircuit = new ParallelCircuit(SelectedCircuit);
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            SelectedCircuit.SubCircuits.Add(newCircuit);
        }

        private void AddResistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с нижним обработчиком
            TreeNode node = new TreeNode();
            //TODO: обращение по индексу не очевидно
            node.Text = Elements[0];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Resistor newElement = new Resistor(SelectedCircuit);
            newElement.CircuitChanged += Circuit_CircuitChanged;
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        private void AddCapacitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с верхним обработчиком
            TreeNode node = new TreeNode();
            //TODO: обращение по индексу не очевидно
            node.Text = Elements[1];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Capacitor newElement = new Capacitor(SelectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        private void AddInductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с верхним обработчиком
            TreeNode node = new TreeNode();
            //TODO: обращение по индексу не очевидно
            node.Text = Elements[2];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);

            Inductor newElement = new Inductor(SelectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            SelectedCircuit.SubCircuits.Add(newElement);
        }

        #endregion - Редактирование цепи -

        //TODO: где //***********************************************************************************?

        #region Отрисовка цепи
        private void pictureBoxCircuit_Paint(object sender, PaintEventArgs e)
        {
            Point pointBegin = new Point(0, this.pictureBoxCircuit.Height / 2);
            Point pointEnd = new Point(pointBegin.X + 50, pointBegin.Y);
            e.Graphics.DrawLine(Pens.Black, pointBegin, pointEnd);
            pointBegin = pointEnd;
            if (this.Circuit != null)
            {
                this.Circuit.Paint(e.Graphics, pointBegin, pointEnd);
            }
            
            //PaintCircuit(pointBegin, ref pointEnd, this.Circuit, e);
        }

        //TODO: xml-комментарий?
        //TODO: почитать паттерны GRASP и "Информационный эксперт" в частности
        private void PaintCircuit(Point pointBegin, ref Point pointEnd, ICircuit circuit, PaintEventArgs e)
        {
            if (circuit is Element)
            {
                Element element = (Element)circuit;
                element.Paint(e.Graphics, pointBegin, pointEnd);
                //e.Graphics.DrawImage(element.GetImageOfElement(), pointBegin.X, pointBegin.Y - 25, 50, 50);
            }
            else if (circuit is ICircuit)
            {
                if (circuit is SeriesCircuit)
                {
                    
                    foreach (ICircuit subCircuit in circuit.SubCircuits)
                    {
                        PaintCircuit(pointBegin, ref pointEnd, subCircuit, e);
                        pointBegin.X += 100;
                        pointEnd.X += 50;
                        e.Graphics.DrawLine(Pens.Black, pointBegin, pointEnd);
                        pointEnd = pointBegin;
                    }
                }
                else if (circuit is ParallelCircuit)
                {
                    
                    foreach (ICircuit subCircuit in circuit.SubCircuits)
                    {
                        
                        if (subCircuit != circuit.SubCircuits[0])
                        {
                            //pointEnd.X += 50;
                            pointBegin.Y -= 50;
                            pointEnd.Y -= 50;
                            PaintCircuit(pointBegin, ref pointEnd, subCircuit, e);
                            e.Graphics.DrawLine(Pens.Black, pointBegin.X - 2, pointBegin.Y, pointBegin.X - 2, pointBegin.Y + 50);
                            e.Graphics.DrawLine(Pens.Black, pointEnd.X + 2, pointEnd.Y, pointEnd.X + 2, pointEnd.Y + 50);
                        }
                        else
                        {
                            PaintCircuit(pointBegin, ref pointEnd, subCircuit, e);
                        }
                        pointEnd = pointBegin;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                //TODO: исключение?
                return;
            }
        }//TODO: где пустая строка!
        #endregion

        //TODO: зачем столько пустых строк!
        //TODO: зачем столько пустых строк!
        //TODO: зачем столько пустых строк!
        //TODO: зачем столько пустых строк!
        //TODO: зачем столько пустых строк!
    }
}
