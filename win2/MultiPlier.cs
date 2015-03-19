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
    class MultiPlier
    {

        public enum PrefixType
        {
            Nano,
            Micro,
            Mili,
            Not,
            Kilo,
            Mega,
            Giga
        }

        /// <summary>
        /// Получить множитель по заднному префиксу
        /// </summary>
        /// <param name="prefix">Префикс</param>
        /// <returns>Множитель</returns>
        static public double GetMultiPlier(PrefixType prefix)
        {
            double multiPlier;
            switch (prefix)
            {
                case PrefixType.Nano:
                    multiPlier = Math.Pow(10, -9);
                    break;
                case PrefixType.Micro:
                    multiPlier = Math.Pow(10, -6);
                    break;
                case PrefixType.Mili:
                    multiPlier = Math.Pow(10, -3);
                    break;
                case PrefixType.Not:
                    multiPlier = 1;
                    break;
                case PrefixType.Kilo:
                    multiPlier = Math.Pow(10, 3);
                    break;
                case PrefixType.Mega:
                    multiPlier = Math.Pow(10, 6);
                    break;
                case PrefixType.Giga:
                    multiPlier = Math.Pow(10, 9);
                    break;
                default:
                    throw new ArgumentException();
            }
            return multiPlier;
        }

    }
}
