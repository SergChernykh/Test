using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitCalculation.Elements
{
    using System.Drawing;

    using CircuitCalculation.Circuit;
    //TODO: Точки в конце xml-комментариев
    /// <summary>
    /// Конденсатор
    /// </summary>
    public class Capacitor : Element
    {
        
        //TODO: где xml-комментарий?
        public Capacitor(ICircuit parentCircuit)
        {
            ParentCircuit = parentCircuit;
            //TODO: странно, что рисунок конденсатора единственный в jpg, остальные в png
            _image = global::CircuitCalculation.Properties.Resources.Capacitor;
        }
        //TODO: где xml-комментарий?
        public override Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(0, (-1) / (2 * Math.PI * frequencies[i] * Value));
            }
            return z;
        }

        
       
    }
}
