using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCalculation
{
    /// <summary>
    /// Множитель величины
    /// </summary>
    public class Multiplier
    {

        /// <summary>
        /// Получить множитель по заднному префиксу
        /// </summary>
        /// <param name="prefix">Префикс</param>
        /// <returns>Множитель</returns>
        static public double GetMultiPlier(PrefixType prefix)
        {
            return Math.Pow(10, (int)prefix);
        }

    }
}
