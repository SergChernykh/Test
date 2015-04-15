using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CircuitCalculation.Elements;


namespace CircuitCalculation
{
    /// <summary>
    /// Форма редактироваия элемента.
    /// </summary>
    public partial class EditElementForm : Form
    {
        /// <summary>
        /// Приставка.
        /// </summary>
        private readonly Dictionary<PrefixType, string> Prefix;
        
        /// <summary>
        /// Элемент.
        /// </summary>
        private Element _element;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element">Элемент для редактирования.</param>
        public EditElementForm(Element element)
        {
            InitializeComponent();

            this._element = element;
            //TODO: Enum.GetValues?
            Prefix = new Dictionary<PrefixType, string>();
            Prefix.Add(PrefixType.Giga, PrefixType.Giga.ToString());
            Prefix.Add(PrefixType.Mega, PrefixType.Mega.ToString());
            Prefix.Add(PrefixType.Kilo, PrefixType.Kilo.ToString());
            Prefix.Add(PrefixType.Not, PrefixType.Not.ToString());
            Prefix.Add(PrefixType.Mili, PrefixType.Mili.ToString());
            Prefix.Add(PrefixType.Micro, PrefixType.Micro.ToString());
            Prefix.Add(PrefixType.Nano, PrefixType.Nano.ToString());

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
                _element.Name = textBoxNameOfElement.Text;
                _element.Value = Convert.ToDouble(textBoxValueOfElement.Text) *
                    Multiplier.GetMultiplier((PrefixType)Enum.Parse(typeof(PrefixType), this.comboBoxPrefix.Text));
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
            this.Text = _element.Description;
            this.textBoxNameOfElement.Text = this._element.Name;
            this.textBoxValueOfElement.Text = this._element.Value.ToString();
            this.comboBoxPrefix.Text = this.Prefix[PrefixType.Not];
        }

        private void textBoxValueOfElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled  = (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8 && e.KeyChar != '.';
        }
    }
}
