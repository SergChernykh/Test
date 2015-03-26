using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using CircuitCalculation.Elements;
//TODO: Несовпадение пространства имен с реальным расположением файла в проекте
namespace CircuitCalculation
{
    //TODO: Точки в конце xml-комментариев
    /// <summary>
    /// Цепь элементов
    /// </summary>
    public interface ICircuit
    {
        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Родительская цепь
        /// </summary>
        ICircuit ParentCircuit { get; set; }

        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Соединения, входящие в текущую цепь
        /// </summary>
        EventDrivenList<ICircuit> SubCircuits { get; }

        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Расчитать импеданс цепи на заданных частотах
        /// </summary>
        /// <param name="frequencies">Список частот</param>
        /// <returns>Расчитанное значение импеданса</returns>
        Complex[] CalculateZ(double[] frequencies);

        //TODO: Точки в конце xml-комментариев
        /// <summary>
        /// Зажигается при измененииях в цепи
        /// </summary>
        event EventHandler CircuitChanged;
    }
}
