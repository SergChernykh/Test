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
    /// Катушка индуктивности
    /// </summary>
    public class Inductor : Element
    {
        
        //TODO: где xml-комментарий?
        public Inductor(ICircuit parentCircuit)
        {
            ParentCircuit = parentCircuit;
            _image = global::CircuitCalculation.Properties.Resources.Inductor;
        }
        //TODO: где xml-комментарий?
        public override Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = new Complex(0, 2 * Math.PI * frequencies[i] * Value);
            }
            return z;
            
        }

        
    }
}
