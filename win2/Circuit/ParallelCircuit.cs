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
    /// Параллельное соединение.
    /// </summary>
    public class ParallelCircuit : ICircuit
    {
        /// <summary>
        /// Подсоединения.
        /// </summary>
        public EventDrivenList<ICircuit> SubCircuits { get; set; }
        
        /// <summary>
        /// Родительская цепь.
        /// </summary>
        public ICircuit ParentCircuit { get; set; }
        
        /// <summary>
        /// ЗАжигается при изменениях в цепи.
        /// </summary>
        public event EventHandler CircuitChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentCircuit">Родительская цепь.</param>
        public ParallelCircuit(ICircuit parentCircuit)
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
        
        /// <summary>
        /// Рассчитать импеданс.
        /// </summary>
        /// <param name="frequencies">Список частот.</param>
        /// <returns>Рассчитанный импеданс.</returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                z[i] = 0;
            }
            for (int i = 0; i < frequencies.Length; i++)
            {
                foreach (var circuit in SubCircuits)
                {
                    z[i] += 1 / circuit.CalculateZ(frequencies)[i];
                }
                z[i] = 1 / z[i];
            }
            return z;
        }

        /// <summary>
        /// Получить избражение.
        /// </summary>
        /// <returns>Изображение.</returns>
        public Image GetImage()
        {
            Image[] array = new Bitmap[SubCircuits.Count];
            int height = 0;
            int width = 0;
            for (int i = 0; i < SubCircuits.Count; i++)
            {
                array[i] = SubCircuits[i].GetImage();

                if (array[i] != null)
                {
                    if (array[i].Width > width)
                    {
                        width = array[i].Width + 50;
                    }
                    height += array[i].Height;
                }
            }

            if (height != 0 && width != 0)
            {
                Bitmap image = new Bitmap(width, height);
                Graphics graphic = Graphics.FromImage(image);
                Point pointBegin = new Point(0, 0);

                foreach (var item in array)
                {
                    if (item != null)
                    {
                        graphic.DrawLine(Pens.Black, pointBegin.X, pointBegin.Y + item.Height / 2, pointBegin.X + (width - item.Width) / 2, pointBegin.Y + item.Height / 2);
                        graphic.DrawImage(item, pointBegin.X + (width - item.Width) / 2, pointBegin.Y, item.Width, item.Height);
                        graphic.DrawLine(Pens.Black, pointBegin.X + (width + item.Width) / 2, pointBegin.Y + item.Height / 2, pointBegin.X + width, pointBegin.Y + item.Height / 2);
                        pointBegin.Y += item.Height; 
                    }
                }
                graphic.DrawLine(Pens.Black, pointBegin.X, pointBegin.Y - array[array.Length - 1].Height / 2, pointBegin.X, pointBegin.Y - height + array[0].Height / 2);
                graphic.DrawLine(Pens.Black, width - 1, pointBegin.Y - array[array.Length - 1].Height / 2, width - 1, pointBegin.Y - height + array[0].Height / 2);
                return image;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Текстовое описание.
        /// </summary>
        public string Description
        {
            get { return "Параллельное"; }
        }
    }
}
