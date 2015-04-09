namespace CircuitCalculation.Elements
{
    using System;
    using System.Drawing;
    using System.Numerics;

    using CircuitCalculation.Circuit;

    /// <summary>
    /// Элемент схемы.
    /// </summary>
    public abstract class Element : ICircuit
    {
        /// <summary>
        /// Имя.
        /// </summary>
        string _name;

        /// <summary>
        /// Номинал.
        /// </summary>
        double _value;

        /// <summary>
        /// Изображение.
        /// </summary>
        protected Image _image;
        
        /// <summary>
        /// Имя элемента.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Номинал элемента.
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (value > 0)
                {
                    _value = value;
                    if (CircuitChanged != null)
                    {
                        CircuitChanged(this, null);
                    }
                }
                else
                {
                    throw new ArgumentException("Значение номинала должно быть положительным");
                }
            }
        }

        /// <summary>
        /// Родительская цепь.
        /// </summary>
        public ICircuit ParentCircuit { get; set; }
        
        /// <summary>
        /// Подсоединения.
        /// </summary>
        public EventDrivenList<ICircuit> SubCircuits { get { return null; } }
        
        /// <summary>
        /// Зажигается при изменениях в цепи.
        /// </summary>
        public event EventHandler CircuitChanged;
        
        /// <summary>
        /// Вычислить импеданс.
        /// </summary>
        /// <param name="frequencies">Расчетные частоты.</param>
        /// <returns>Рассчитанный импеданс.</returns>
        public abstract Complex[] CalculateZ(double[] frequencies);
        
  
        public void Paint(Graphics graphic, Point pointBegin, ref Point pointEnd)
        {
            graphic.DrawLine(Pens.Black, pointBegin.X, pointBegin.Y, pointBegin.X + 25, pointBegin.Y);
            graphic.DrawImage(_image, pointBegin.X + 25, pointBegin.Y - 25, 50, 50);
            graphic.DrawLine(Pens.Black, pointBegin.X + 75, pointBegin.Y, pointBegin.X + 100, pointBegin.Y);
            pointEnd.X += 100;
        }
    }
}
