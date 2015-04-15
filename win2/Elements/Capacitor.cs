namespace CircuitCalculation.Elements
{
    using System;
    using System.Numerics;

    using CircuitCalculation.Circuit;
    
    /// <summary>
    /// Конденсатор.
    /// </summary>
    public class Capacitor : Element
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCircuit">Родительская цепь.</param>
        public Capacitor(ICircuit parentCircuit)
        {
            this.ParentCircuit = parentCircuit;
            _image = global::CircuitCalculation.Properties.Resources.Capacitor;
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
                z[i] = new Complex(0, (-1) / (2 * Math.PI * frequencies[i] * Value));
            }
            return z;
        }

        /// <summary>
        /// Текстовое описание.
        /// </summary>
        public override string Description
        {
            get { return "Конденсатор"; }
        }
    }
}
