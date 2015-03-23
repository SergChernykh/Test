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
        private readonly Dictionary<PrefixType, string> Prefix;
        private readonly Dictionary<Type, string> TypeOfElement;

        private IElement Element;

        public EditOfElement(IElement element)
        {
            InitializeComponent();

            this.Element = element;
            Prefix = new Dictionary<PrefixType, string>();
            Prefix.Add(PrefixType.Giga, "Giga");
            Prefix.Add(PrefixType.Mega, "Mega");
            Prefix.Add(PrefixType.Kilo, "Kilo");
            Prefix.Add(PrefixType.Not, "Not");
            Prefix.Add(PrefixType.Mili, "Mili");
            Prefix.Add(PrefixType.Micro, "Micro");
            Prefix.Add(PrefixType.Nano, "Nano");

            TypeOfElement = new Dictionary<Type, string>();
            TypeOfElement.Add(typeof(Capacitor), "Конденсатор, Ф");
            TypeOfElement.Add(typeof(Resistor), "Резистор, Ом");
            TypeOfElement.Add(typeof(Inductor), "Катушка, Гн");

            foreach (string str in Prefix.Values)
            {
                this.comboBoxPrefix.Items.Add(str);
            }
        }

        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        
        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Element.Name = textBoxNameOfElement.Text;
                Element.Value = Convert.ToDouble(textBoxValueOfElement.Text) *
                    Multiplier.GetMultiPlier((PrefixType)Enum.Parse(typeof(PrefixType), this.comboBoxPrefix.Text));
            }
            catch (FormatException)
            {
                MessageBox.Show("Не введено значение номинала элемента");
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
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditOfElement_Load(object sender, EventArgs e)
        {
            this.Text = TypeOfElement[Element.GetType()];
            this.textBoxNameOfElement.Text = this.Element.Name;
            this.textBoxValueOfElement.Text = this.Element.Value.ToString();
            this.comboBoxPrefix.Text = this.Prefix[PrefixType.Not];
        }

        private void textBoxValueOfElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }
    }
   
}
