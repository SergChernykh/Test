using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CircuitCalculation
{
    /// <summary>
    /// Элемент схемы
    /// </summary>
    public interface IElement
    {
        /// <summary>
        /// Имя элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Номинал элемента в СИ
        /// </summary>
        double Value { get; set; }

        event EventHandler CircuitChanged;

        /// <summary>
        /// Получить изображение элемента
        /// </summary>
        /// <returns>Изображение элемента</returns>
        Image GetImageOfElement();
    }
}
