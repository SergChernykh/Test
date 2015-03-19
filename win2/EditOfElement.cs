using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CircuitCalculation.Elements;


namespace CircuitCalculation
{
    public partial class EditOfElement : Form
    {
        private Dictionary<MultiPlier.PrefixType, string> Prefix;
        private ICircuit Circuit;
        public EditOfElement(ICircuit Circuit)
        {
            this.Circuit = Circuit;
            Prefix = new Dictionary<MultiPlier.PrefixType, string>();
            Prefix.Add(MultiPlier.PrefixType.Giga, "Гига");
            Prefix.Add(MultiPlier.PrefixType.Mega, "Мега");
            Prefix.Add(MultiPlier.PrefixType.Kilo, "Кило");
            Prefix.Add(MultiPlier.PrefixType.Not, "Нет");
            Prefix.Add(MultiPlier.PrefixType.Mili, "Мили");
            Prefix.Add(MultiPlier.PrefixType.Micro, "Микро");
            Prefix.Add(MultiPlier.PrefixType.Nano, "Нано");
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) //добавление строки/элемента
        {
            this.dataGridViewElements.Rows.Add();
            for (int i = 0; i < dataGridViewElements.ColumnCount; i++)
            {
                dataGridViewElements.Rows[dataGridViewElements.RowCount - 1].Cells[i].Value = "";
            }
            this.numericUpDownSelection.Maximum++;
            this.numericUpDownSelection.Value = this.dataGridViewElements.RowCount;
        }

        private void buttonAllDelete_Click(object sender, EventArgs e) //очистка всех полей
        {
            for (int i = 0; i < this.dataGridViewElements.RowCount; i++)
            {
                for (int j = 0; j < this.dataGridViewElements.ColumnCount; j++)
                {
                    this.dataGridViewElements.Rows[i].Cells[j].Value = "";
                }
            }
        }
        

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        private void buttonDelete_Click(object sender, EventArgs e) //удаление любой указанной строки
        {
            try
            {
                this.dataGridViewElements.Rows.RemoveAt((int)this.numericUpDownSelection.Value - 1);
                Circuit.RemoveElement((int)this.numericUpDownSelection.Value - 1); //удаление из цепи
                this.numericUpDownSelection.Maximum--;
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dataGridViewElements.RowCount; i++)
            {
                IElement element;
                switch (this.ColumnTypeElement.Items.IndexOf(dataGridViewElements.Rows[i].Cells[0].Value.ToString()))
                {

                    case 0:         
                        element = new Capacitor();
                        break;
                    case 1:
                        element = new Inductor();
                        break;
                    case 2:
                        element = new Resistor();
                        break;
                    default:
                        throw new ArgumentException();
                }
                try
                {
                    element.Name = dataGridViewElements.Rows[i].Cells[1].Value.ToString();
                    element.Value = Convert.ToDouble(dataGridViewElements.Rows[i].Cells[2].Value);
                    Circuit.AddElement(element, i);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Значение должно быть вещественным числом!");
                    return;
                }
                catch (ArgumentException exp)
                {
                    MessageBox.Show(exp.Message);
                    return;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Не введено имя элемента");
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditOfElement_Load(object sender, EventArgs e)
        {
            if (Circuit.Elements.Count > 0)
            {
                dataGridViewElements.Rows.Add(Circuit.Elements.Count);
                this.numericUpDownSelection.Maximum = this.dataGridViewElements.RowCount;
                for (int i = 0; i < dataGridViewElements.RowCount; i++)
                {
                    IElement element = Circuit.Elements[i];

                    if (element is Capacitor)
                    {
                        dataGridViewElements.Rows[i].Cells[0].Value = this.ColumnTypeElement.Items[0].ToString();
                    }
                    else if (element is Resistor)
                    {
                        dataGridViewElements.Rows[i].Cells[0].Value = this.ColumnTypeElement.Items[2].ToString();
                    }
                    else if (element is Inductor)
                    {
                        dataGridViewElements.Rows[i].Cells[0].Value = this.ColumnTypeElement.Items[1].ToString();
                    }
                    dataGridViewElements.Rows[i].Cells[1].Value = element.Name;
                    dataGridViewElements.Rows[i].Cells[2].Value = element.Value;
                }
            }
           
        }
    }
   
}
