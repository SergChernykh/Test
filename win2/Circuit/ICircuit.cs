namespace CircuitCalculation.Circuit
{
    using System;
    using System.Numerics;
    using System.Drawing;
    using System.Collections;

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

        /// <summary>
        /// Отрисовать цепь.
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="pointBegin"></param>
        /// <param name="pointEnd"></param>
        void Paint(Graphics graphic, Point pointBegin, ref Point pointEnd);
    }
}
