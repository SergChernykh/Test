
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
        private readonly Dictionary<PrefixType, string> _prefix;

        //TODO: где xml-комментарий?
        
        private ICircuit _circuit;
        //TODO: где xml-комментарий?
        
        private ICircuit _selectedCircuit;
        //TODO: где xml-комментарий?
        
        private double[] _frequencies;
        public MainForm()
        {
            InitializeComponent();
            _prefix = new Dictionary<PrefixType, string>();
            _prefix.Add(PrefixType.Giga, PrefixType.Giga.ToString());
            _prefix.Add(PrefixType.Mega, PrefixType.Mega.ToString());
            _prefix.Add(PrefixType.Kilo, PrefixType.Kilo.ToString());
            _prefix.Add(PrefixType.Not, PrefixType.Not.ToString());
            _prefix.Add(PrefixType.Mili, PrefixType.Mili.ToString());
            _prefix.Add(PrefixType.Micro, PrefixType.Micro.ToString());
            _prefix.Add(PrefixType.Nano, PrefixType.Nano.ToString());
            foreach (string str in _prefix.Values)
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
            if (_frequencies != null)
            {
                Calculate();
            }
            this.pictureBoxCircuit.Invalidate();
        }

        /// <summary>
        /// Посчитать импеданс.
        /// </summary>
        private void Calculate()
        {
            var z = _circuit.CalculateZ(_frequencies);

            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                this.dataGridViewFreq[this.ColumnImpedance.Index, i].Value = z[i];
            }
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {       
            _frequencies = new double[this.dataGridViewFreq.RowCount];
            for (int i = 0; i < this.dataGridViewFreq.RowCount; i++)
            {
                try
                {
                    _frequencies[i] = Convert.ToDouble(this.dataGridViewFreq[this.ColumnFrequence.Index, i].Value)*
                        Multiplier.GetMultiplier((PrefixType)Enum.Parse(typeof(PrefixType), this.dataGridViewFreq[this.ColumnPrefix.Index, i].Value.ToString()));
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

            this._selectedCircuit = this._circuit;
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
                    _selectedCircuit = _selectedCircuit.SubCircuits[path[i]];
                }
            }  
        }

        //*********************************************************************************

        #region Создание новой цепи

        private void buttonNewParallelCircuit_Click(object sender, EventArgs e)
        {
            _circuit = new ParallelCircuit(null);
            NewCircuit(_circuit.Description);
        }
        private void buttonNewSeriesCircuit_Click(object sender, EventArgs e)
        {
            _circuit = new SeriesCircuit(null);
            NewCircuit(_circuit.Description);
        }
        private void NewCircuit(string description)
        {
            if (this.treeViewCircuit.Nodes.Count != 0)
            {
                this.treeViewCircuit.Nodes.Remove(this.treeViewCircuit.Nodes[0]);
            }
            TreeNode node = new TreeNode(description);
            node.ContextMenuStrip = this.contextMenuStripEditConnection;
            this.treeViewCircuit.Nodes.Add(node);

            _circuit.CircuitChanged += Circuit_CircuitChanged;
        }

        #endregion

        //***********************************************************************************

        #region - Редактирование цепи -
        private void ChangeToParallelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с нижним обработчиком
            //TODO: обращение по индексу не очевидно
            this.treeViewCircuit.SelectedNode.Text = Circuits[1];
            ParallelCircuit newCircuit;
            if (_selectedCircuit.ParentCircuit == null)
            {
                newCircuit = new ParallelCircuit(null);
            }
            else
            {
                newCircuit = new ParallelCircuit(_selectedCircuit.ParentCircuit);
                _selectedCircuit.ParentCircuit.SubCircuits.Add(newCircuit);
            }
            newCircuit.SubCircuits = _selectedCircuit.SubCircuits;
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            
            _selectedCircuit = newCircuit;
        }

        private void ChangeToSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: дублирование с верхним обработчиком
            //TODO: обращение по индексу не очевидно
            this.treeViewCircuit.SelectedNode.Text = Circuits[0];
            SeriesCircuit newCircuit;
            if (_selectedCircuit.ParentCircuit == null)
            {
                newCircuit = new SeriesCircuit(null);
            }
            else
            {
                newCircuit = new SeriesCircuit(_selectedCircuit.ParentCircuit);
                _selectedCircuit.ParentCircuit.SubCircuits.Add(newCircuit);
            }
            newCircuit.SubCircuits = _selectedCircuit.SubCircuits;
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            
            _selectedCircuit = newCircuit;     
        }
        
        private void DeleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.treeViewCircuit.SelectedNode.Parent != null)
            {
                this._selectedCircuit.ParentCircuit.SubCircuits.Remove(_selectedCircuit);
                this.treeViewCircuit.SelectedNode.Remove();
            }         
        }

        private void EditOfElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditElementForm edit = new EditElementForm((Element)_selectedCircuit);
            edit.ShowDialog();
        }

        private void AddSeriesCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeriesCircuit newCircuit = new SeriesCircuit(_selectedCircuit);
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            _selectedCircuit.SubCircuits.Add(newCircuit);
            AddCircuit(0);
        }

        private void AddParallelCircuitToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ParallelCircuit newCircuit = new ParallelCircuit(_selectedCircuit);
            newCircuit.CircuitChanged += Circuit_CircuitChanged;
            _selectedCircuit.SubCircuits.Add(newCircuit);
            AddCircuit(1);
        }

        private void AddCircuit(int i)
        {
            TreeNode node = new TreeNode();
            node.Text = Circuits[i];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);
        }

        private void AddResistorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resistor newElement = new Resistor(_selectedCircuit);
            newElement.CircuitChanged += Circuit_CircuitChanged;
            _selectedCircuit.SubCircuits.Add(newElement);
            AddElement(0);
        }

        private void AddCapacitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Capacitor newElement = new Capacitor(_selectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            _selectedCircuit.SubCircuits.Add(newElement);
            AddElement(1);
        }

        private void AddInductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inductor newElement = new Inductor(_selectedCircuit);
            newElement.CircuitChanged += new EventHandler(Circuit_CircuitChanged);
            _selectedCircuit.SubCircuits.Add(newElement);
            AddElement(2);
        }

        private void AddElement(int i)
        {
            TreeNode node = new TreeNode();
            node.Text = Elements[i];
            node.ContextMenuStrip = contextMenuStripEditConnection;
            this.treeViewCircuit.SelectedNode.Nodes.Add(node);
        }

        #endregion - Редактирование цепи -

        //***********************************************************************************

        #region - Отрисовка цепи -

        private void pictureBoxCircuit_Paint(object sender, PaintEventArgs e)
        {
            if (this._circuit != null)
            {
                Point pointBegin = new Point(0, this._circuit.GetImage().Height / 2);
                e.Graphics.DrawImage(this._circuit.GetImage(), pointBegin);
            }
        }

        #endregion - Отрисовка цепи -

        //************************************************************************************

        #region - Программно генерируемые цепи -

        private void buttonCircuitOne_Click(object sender, EventArgs e)
        {
            _circuit = new SeriesCircuit(null);
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.SubCircuits.Add(new Resistor(_circuit));
            _circuit.SubCircuits.Add(new Capacitor(_circuit));
            _circuit.SubCircuits.Add(new Inductor(_circuit));
        }

        private void buttonCircuitTwo_Click(object sender, EventArgs e)
        {
            _circuit = new ParallelCircuit(null);
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.SubCircuits.Add(new Resistor(_circuit));
            _circuit.SubCircuits.Add(new Capacitor(_circuit));
            _circuit.SubCircuits.Add(new Inductor(_circuit));
        }

        private void buttonCircuitThree_Click(object sender, EventArgs e)
        {
            _circuit = new SeriesCircuit(null);
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.SubCircuits.Add(new SeriesCircuit(_circuit));
            _circuit.SubCircuits[0].SubCircuits.Add(new Resistor(_circuit.SubCircuits[0]));
            _circuit.SubCircuits[0].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[0]));
            _circuit.SubCircuits[0].SubCircuits.Add(new Inductor(_circuit.SubCircuits[0]));

            _circuit.SubCircuits.Add(new ParallelCircuit(_circuit));
            _circuit.SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Inductor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[1]));
        }

        private void buttonCircuitFour_Click(object sender, EventArgs e)
        {
            _circuit = new ParallelCircuit(null);
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.SubCircuits.Add(new SeriesCircuit(_circuit));
            _circuit.SubCircuits[0].SubCircuits.Add(new Resistor(_circuit.SubCircuits[0]));
            _circuit.SubCircuits[0].SubCircuits.Add(new ParallelCircuit(_circuit.SubCircuits[0]));
            _circuit.SubCircuits[0].SubCircuits[1].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[0].SubCircuits[1]));
            _circuit.SubCircuits[0].SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[0].SubCircuits[1]));
            _circuit.SubCircuits[0].SubCircuits[1].SubCircuits.Add(new Inductor(_circuit.SubCircuits[0].SubCircuits[1]));

            _circuit.SubCircuits.Add(new SeriesCircuit(_circuit));
            _circuit.SubCircuits[1].SubCircuits.Add(new ParallelCircuit(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits[0].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1].SubCircuits[0]));
            _circuit.SubCircuits[1].SubCircuits[0].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1].SubCircuits[0]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Inductor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[1]));
        }

        private void buttonCircuitFive_Click(object sender, EventArgs e)
        {
            _circuit = new SeriesCircuit(null);
            _circuit.CircuitChanged += Circuit_CircuitChanged;
            _circuit.SubCircuits.Add(new ParallelCircuit(_circuit));
            _circuit.SubCircuits[0].SubCircuits.Add(new Resistor(_circuit.SubCircuits[0]));
            _circuit.SubCircuits[0].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[0]));

            _circuit.SubCircuits.Add(new ParallelCircuit(_circuit));
            _circuit.SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Inductor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits.Add(new SeriesCircuit(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[1].SubCircuits[3].SubCircuits.Add(new Resistor(_circuit.SubCircuits[1].SubCircuits[3]));
            _circuit.SubCircuits[1].SubCircuits[3].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[1].SubCircuits[3]));

            _circuit.SubCircuits.Add(new ParallelCircuit(_circuit));
            _circuit.SubCircuits[2].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[2].SubCircuits.Add(new SeriesCircuit(_circuit.SubCircuits[1]));
            _circuit.SubCircuits[2].SubCircuits[1].SubCircuits.Add(new Resistor(_circuit.SubCircuits[2].SubCircuits[1]));
            _circuit.SubCircuits[2].SubCircuits[1].SubCircuits.Add(new ParallelCircuit(_circuit.SubCircuits[2].SubCircuits[1]));
            _circuit.SubCircuits[2].SubCircuits[1].SubCircuits[1].SubCircuits.Add(new Capacitor(_circuit.SubCircuits[2].SubCircuits[1].SubCircuits[1]));
            _circuit.SubCircuits[2].SubCircuits[1].SubCircuits[1].SubCircuits.Add(new Inductor(_circuit.SubCircuits[2].SubCircuits[1].SubCircuits[1]));
        }

        #endregion //- Программно генерируемые цепи -

        private void editElementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteElementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
