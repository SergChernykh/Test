namespace CircuitCalculation.Elements
{
    using System;
    using System.Drawing;
    using System.Numerics;

    using CircuitCalculation.Circuit;

    public class Element : ICircuit
    {
        string _name;

        double _value;

        protected Image _image;
       
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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
                        //TODO: это загорелось событие серкита или элемента?
                        CircuitChanged(this, null);
                    }
                }
                else
                {
                    throw new ArgumentException("Значение номинала должно быть положительным");
                }
            }
        }


        //TODO: где xml-комментарий?
        
        public ICircuit ParentCircuit { get; set; }
        //TODO: где xml-комментарий?
        
        public EventDrivenList<ICircuit> SubCircuits { get { return null; } }
        //TODO: где xml-комментарий?
        
        //TODO: Такое событие есть и в ICircuit, и в IElement. Это относится к какому?
        public event EventHandler CircuitChanged;
        


        public virtual Complex[] CalculateZ(double[] frequencies)
        {
            throw new NotImplementedException();
        }

        public void Paint(Graphics graphic, Point pointBegin, Point pointEnd)
        {
            graphic.DrawImage(_image, pointBegin.X, pointBegin.Y - 25, 50, 50);
        }
    }
}
