namespace CircuitCalculation
{
    using System;

    /// <summary>
    /// Множитель величины.
    /// </summary>
    static public class Multiplier
    {
        /// <summary>
        /// Получить множитель по заднному префиксу.
        /// </summary>
        /// <param name="prefix">Префикс</param>
        /// <returns>Множитель</returns>
        static public double GetMultiplier(PrefixType prefix)
        {
            return Math.Pow(10, (int)prefix);
        }
    }
}
