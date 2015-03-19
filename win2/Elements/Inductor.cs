using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitCalculation.Elements
{
    /// <summary>
    /// Катушка индуктивности
    /// </summary>
    public class Inductor : IElement
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
                        ValueChanged(this, null);
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
            return new Complex(0, 2 * 3.14 * frequency * Value * Math.Pow(10, -3));
        }
        public event EventHandler ValueChanged;


        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(0, 2 * Math.PI * frequencies[i] * Value * Math.Pow(10, -3));
            }
            return z;
            
        }

        
    }
}
