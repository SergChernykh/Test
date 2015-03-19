using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitCalculation.Elements
{
    /// <summary>
    /// Резистор
    /// </summary>
    public class Resistor : IElement
    {
        string _name;
        double _value;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Value
        {
            get { return _value; }
            set
            {
                if (value > 0)
                {
                    _value = value;
                    if (ValueChanged != null)
                    {
                        ValueChanged(this, null);  //при изменении значения значения зажигается событие
                    }
                }
                else
                {
                    throw new ArgumentException("Значение номинала должно быть положительным");
                }


            }
        }
        public Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }
        public event EventHandler ValueChanged;


        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(Value, 0);
            }
            return z;
        }

        
    }
}
