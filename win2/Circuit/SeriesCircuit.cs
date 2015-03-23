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
        public EventDrivenList<ICircuit> SubCircuits { get; set; }

        public ICircuit ParentCircuit { get; set; }

        public event EventHandler CircuitChanged;

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
