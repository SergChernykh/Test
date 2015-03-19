using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace CircuitCalculation.Elements
{
    /// <summary>
    /// Элемент эквивалентной схемы.
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Имя элемента.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Номинал элемента.
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Рассчитать значение импеданса для элемента на заданной частоте.
        /// </summary>
        /// <param name="frequency">Расчетная частота.</param>
        /// <returns>Расситанное значение импеданса.</returns>
        Complex CalculateZ(double frequency);

        /// <summary>
        /// Событие, срабатывающее при изменении элемента
        /// </summary>
        event EventHandler ValueChanged;
    }
}
