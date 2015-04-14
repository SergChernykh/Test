namespace CircuitCalculation.Elements
{
    using System;
    using System.Numerics;

    using CircuitCalculation.Circuit;

    /// <summary>
    /// Катушка индуктивности.
    /// </summary>
    public class Inductor : Element
    {
        /// <summary>
        /// Конструктор элемента.
        /// </summary>
        public Inductor(ICircuit parentCircuit)
        {
            this.ParentCircuit = parentCircuit;
            _image = global::CircuitCalculation.Properties.Resources.Inductor;
        }
        
        /// <summary>
        /// Вычислить импеданс.
        /// </summary>
        /// <param name="frequencies">Расчетные частоты.</param>
        /// <returns>Рассчитанный импеданс.</returns>
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
