using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using CircuitCalculation.Elements;

namespace CircuitCalculation
{
    //TODO: Точки в конце xml-комментариев
    /// <summary>
    /// Последовательное соединение
    /// </summary>
    class SeriesCircuit : ICircuit
    {
        //TODO: где xml-комментарий?
        public EventDrivenList<ICircuit> SubCircuits { get; set; }
        //TODO: где xml-комментарий?
        public ICircuit ParentCircuit { get; set; }
        //TODO: где xml-комментарий?
        public event EventHandler CircuitChanged;
        //TODO: где xml-комментарий?
        //TODO: именование переменных! Входная переменная должна быть parentCircuit, а не просто circuit!
        public SeriesCircuit(ICircuit circuit)
        {
            SubCircuits = new EventDrivenList<ICircuit>();
            SubCircuits.ItemAdded += SubCircuits_ItemChanged;
            SubCircuits.ItemRemoved += SubCircuits_ItemChanged;
            ParentCircuit = circuit;
        }

        private void SubCircuits_ItemChanged(object sender, EventArgs e)
        {
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);
            }
        }

        //TODO: где xml-комментарий?
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = 0;
            }

            foreach (ICircuit circuit in SubCircuits)
            {
                for (int i = 0; i < frequencies.Length; i++)
                {
                    z[i] += circuit.CalculateZ(frequencies)[i];
                }
            }
            return z;
        }
    }
        
}
