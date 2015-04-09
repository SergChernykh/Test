using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

using CircuitCalculation.Elements;


namespace CircuitCalculation.Circuit
{
    /// <summary>
    /// Параллельное соединение.
    /// </summary>
    public class ParallelCircuit : ICircuit
    {
        /// <summary>
        /// 
        /// </summary>
        public EventDrivenList<ICircuit> SubCircuits { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public ICircuit ParentCircuit { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CircuitChanged;

        public ParallelCircuit(ICircuit parentCircuit)
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
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
                    z[i] += 1 / circuit.CalculateZ(frequencies)[i];
                }
            }
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] /= 1;
            }
            return z;
        }

        public void Paint(Graphics graphic, Point pointBegin, ref Point pointEnd)
        {
            pointBegin.Y -= 25 * (SubCircuits.Count - 1);
            
            if (this.ParentCircuit != null)
            {
                //pointBegin.Y += 25 * (SubCircuits.Count - 1);
            }
            foreach (var subCircuit in SubCircuits)
            {
                pointEnd = pointBegin;
                subCircuit.Paint(graphic, pointBegin, ref pointEnd);
                pointBegin.Y += 50;

                graphic.DrawLine(Pens.Black, pointBegin.X, pointBegin.Y, pointBegin.X, pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(subCircuit)));
                graphic.DrawLine(Pens.Black, pointEnd.X, pointEnd.Y, pointEnd.X, pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(subCircuit)));
            }
            //for (int i = 0; i < SubCircuits.Count; i++)
            //{
            //    pointEnd = pointBegin;
            //    SubCircuits[i].Paint(graphic, pointBegin, ref pointEnd);
            //    pointBegin.Y += 50;

            //    graphic.DrawLine(Pens.Black, pointBegin.X, pointBegin.Y, pointBegin.X, pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(SubCircuits[i])));
            //    if (i != 0)
            //    {
            //        if (SubCircuits[i].SubCircuits.Count > SubCircuits[i - 1].SubCircuits.Count)
            //        {
            //            graphic.DrawLine(Pens.Black, pointEnd.X, pointEnd.Y, pointEnd.X, pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(SubCircuits[i])));
            //            graphic.DrawLine(Pens.Black, pointEnd.X, pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(SubCircuits[i])), pointEnd.X - 100 * (SubCircuits[i].SubCircuits.Count - SubCircuits[i - 1].SubCircuits.Count), pointBegin.Y - 50 * (int)Math.Pow(-1, SubCircuits.IndexOf(SubCircuits[i])));
            //        }
            //    }
            //}
        }
    }
}
