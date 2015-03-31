using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

using CircuitCalculation.Elements;

namespace CircuitCalculation.Circuit
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
        
        public SeriesCircuit(ICircuit parentCircuit)
        {
            SubCircuits = new EventDrivenList<ICircuit>();
            SubCircuits.ItemAdded += SubCircuits_ItemChanged;
            SubCircuits.ItemRemoved += SubCircuits_ItemChanged;
            ParentCircuit = parentCircuit;
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


        public void Paint(Graphics graphic, Point pointBegin, Point pointEnd)
        {
            foreach (ICircuit subCircuit in SubCircuits)
            {
                Paint(graphic, pointBegin, pointEnd);
                pointBegin.X += 100;
                pointEnd.X += 50;
                graphic.DrawLine(Pens.Black, pointBegin, pointEnd);
                pointEnd = pointBegin;
            }
        }
    }
        
}
