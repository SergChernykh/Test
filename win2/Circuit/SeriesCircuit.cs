using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using CircuitCalculation.Elements;

namespace CircuitCalculation
{
    /// <summary>
    /// Последовательное соединение
    /// </summary>
    class SeriesCircuit : ICircuit
    {
        public List<IElement> Elements {get; set;}

        public List<ICircuit> SubCircuits {get; set;}

        public ICircuit ParentCircuit { get; set; }

        public event EventHandler CircuitChanged;

        public SeriesCircuit(ICircuit circuit)
        {
            Elements = new List<IElement>();
            SubCircuits = new List<ICircuit>();
            ParentCircuit = circuit;
        }

        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];


            Complex[] zSub = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = 0;
                foreach (IElement element in Elements)
                {
                    z[i] += element.CalculateZ(frequencies[i]);
                }
            }

            foreach (ICircuit circuit in SubCircuits)
            {
                zSub = circuit.CalculateZ(frequencies);
                for (int i = 0; i < frequencies.Length; i++)
                {
                    z[i] += zSub[i];
                }
            }

            return z;
        }

        public void AddElement(IElement element, int index)
        {
            try
            {
                Elements.RemoveAt(index);
                Elements.Insert(index, element);
            }
            catch (ArgumentOutOfRangeException)
            {
                Elements.Add(element);

            }

            Elements[index].ValueChanged += new EventHandler(Element_ValueChanged);
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);   //при добавлении элемента зажигается событие 
            }
        }

        public void RemoveElement(int index)
        {
            this.Elements.RemoveAt(index);
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);
            }
        }


        

        private void Element_ValueChanged(object sender, EventArgs e)
        {
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);   //при изменении элемента зажигается событие 
            }
        }
    }
}
