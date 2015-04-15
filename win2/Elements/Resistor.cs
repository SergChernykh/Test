namespace CircuitCalculation.Elements
{
    using System.Numerics;

    using CircuitCalculation.Circuit;
    
    /// <summary>
    /// Резистор.
    /// </summary>
    public class Resistor : Element
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCircuit">Родительская цепь.</param>
        public Resistor(ICircuit parentCircuit)
        {
            this.ParentCircuit = parentCircuit;
            _image = global::CircuitCalculation.Properties.Resources.Resistor;
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
                z[i] = new Complex(Value, 0);
            }
            return z;
        }

        /// <summary>
        /// Текстовое описание.
        /// </summary>
        public override string Description
        {
            get { return "Резистор"; }
        }
    }
}
