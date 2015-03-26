using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CircuitCalculation
{
    //TODO: Точки в конце xml-комментариев
    /// <summary>
    /// Элемент схемы
    /// </summary>
    public interface IElement
    {
        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Имя элемента
        /// </summary>
        string Name { get; set; }

        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Номинал элемента в СИ
        /// </summary>
        double Value { get; set; }

        //TODO: именование! Событие именуется CircuitChanged, однако в интерфейсе нет ни одного свойства с именем Circuit
        event EventHandler CircuitChanged;

        //TODO: именование! Интерфейс и так называется Element, в названии метода его уже упоминать не надо
        //TODO: именование! Иначе получается обращение element.GetImageOfElement() - дублирование очевидного
        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Получить изображение элемента
        /// </summary>
        /// <returns>Изображение элемента</returns>
        Image GetImageOfElement();
    }
}
