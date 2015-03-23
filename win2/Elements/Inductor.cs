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
    public class Inductor : IElement, ICircuit
    {
        string _name;
        double _value;
        System.Drawing.Image _imageOfElement;

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
                    if (CircuitChanged != null)
                    {
                        CircuitChanged(this, null);
                    }
                }
                else
                {
                    throw new ArgumentException("Значение номинала должно быть положительным");
                }

            }
        }


        public Inductor(ICircuit circuit)
        {
            ParentCircuit = circuit;
            _imageOfElement = global::CircuitCalculation.Properties.Resources.Inductor;
        }
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(0, 2 * Math.PI * frequencies[i] * Value);
            }
            return z;
            
        }

        public ICircuit ParentCircuit { get; set; }

        public EventDrivenList<ICircuit> SubCircuits { get { return null; } }

        public event EventHandler CircuitChanged;


        public System.Drawing.Image GetImageOfElement()
        {
            return _imageOfElement;
        }
    }
}
