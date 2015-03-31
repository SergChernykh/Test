using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using CircuitCalculation.Elements;

namespace CircuitCalculation.Circuit
{
    using System.Drawing;

    
    /// <summary>
    /// Цепь элементов.
    /// </summary>
    public interface ICircuit
    {
        
        /// <summary>
        /// Родительская цепь.
        /// </summary>
        ICircuit ParentCircuit { get; set; }

        
        /// <summary>
        /// Соединения, входящие в текущую цепь.
        /// </summary>
        EventDrivenList<ICircuit> SubCircuits { get; }

        
        /// <summary>
        /// Расчитать импеданс цепи на заданных частотах.
        /// </summary>
        /// <param name="frequencies">Список частот</param>
        /// <returns>Расчитанное значение импеданса</returns>
        Complex[] CalculateZ(double[] frequencies);

        
        /// <summary>
        /// Зажигается при измененииях в цепи.
        /// </summary>
        event EventHandler CircuitChanged;


        void Paint(Graphics graphic, Point pointBegin, Point pointEnd);
    }
}
