using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitCalculation.Elements
{
    //TODO: Точки в конце xml-комментариев
    /// <summary>
    /// Катушка индуктивности
    /// </summary>
    public class Inductor : IElement, ICircuit
    {
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        string _name;
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        double _value;
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        //TODO: System.Drawing лучше перенести в using, а здесь оставить просто Image
        System.Drawing.Image _imageOfElement;
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
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
        //TODO: где xml-комментарий?
        public Inductor(ICircuit circuit)
        {
            ParentCircuit = circuit;
            _imageOfElement = global::CircuitCalculation.Properties.Resources.Inductor;
        }
        //TODO: где xml-комментарий?
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(0, 2 * Math.PI * frequencies[i] * Value);
            }
            return z;
            
        }
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        public ICircuit ParentCircuit { get; set; }
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        public EventDrivenList<ICircuit> SubCircuits { get { return null; } }
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        public event EventHandler CircuitChanged;
        //TODO: где xml-комментарий?
        //TODO: общая логика для всех элементов. Может быть, нужен базовый класс?
        public System.Drawing.Image GetImageOfElement()
        {
            return _imageOfElement;
        }
    }
}
