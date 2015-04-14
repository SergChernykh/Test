using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

using CircuitCalculation.Elements;

namespace CircuitCalculation.Circuit
{
    /// <summary>
    /// Последовательное соединение.
    /// </summary>
    public class SeriesCircuit : ICircuit
    {
        //TODO: где xml-комментарий?
        public EventDrivenList<ICircuit> SubCircuits { get; set; }
        //TODO: где xml-комментарий?
        public ICircuit ParentCircuit { get; set; }
        //TODO: где xml-комментарий?
        public event EventHandler CircuitChanged;
        //TODO: где xml-комментарий?
        
        public SeriesCircuit(ICircuit parentCircuit)
        {
            SubCircuits = new EventDrivenList<ICircuit>();
            this.ParentCircuit = parentCircuit;
            SubCircuits.ItemAdded += SubCircuits_ItemChanged;
            SubCircuits.ItemRemoved += SubCircuits_ItemChanged;
        }

        private void SubCircuits_ItemChanged(object sender, EventArgs e)
        {
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);
            }
        }

        //TODO: где xml-комментарий?
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = 0;
            }

            foreach (ICircuit circuit in SubCircuits)
            {
                for (int i = 0; i < frequencies.Length; i++)
                {
                    z[i] += circuit.CalculateZ(frequencies)[i];
                }
            }
            return z;
        }

        public Image GetImage()
        {
            Image[] array = new Bitmap[SubCircuits.Count];
            int height = 0;
            int width = 0;
            for (int i = 0; i < SubCircuits.Count; i++)
            {
                array[i] = SubCircuits[i].GetImage();

                if (array[i].Height > height)
                {
                    height = array[i].Height;
                }
                width += array[i].Width + 50;
            }
            
            Bitmap image = new Bitmap(width, height);
            Graphics graphic = Graphics.FromImage(image);
            Point pointBegin = new Point(0, 0);

            foreach (var item in array)
            {
                graphic.DrawLine(Pens.Black, pointBegin.X, height / 2, pointBegin.X + 25, height / 2);
                pointBegin.X += 25;
                graphic.DrawImage(item, pointBegin.X, pointBegin.Y + (height - item.Height) / 2, item.Width, item.Height);
                pointBegin.X += item.Width;
                graphic.DrawLine(Pens.Black, pointBegin.X, height / 2, pointBegin.X + 25, height / 2);
                pointBegin.X += 25;
            }
            return image;
        }
    }    
}
