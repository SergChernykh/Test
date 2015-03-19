using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace CircuitCalculation.Elements
{
    
    /// <summary>
    /// Перечисление типов соединений
    /// </summary>
    public enum ConnectionType { Parallel, Series}
    
    
    /// <summary>
    /// Цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Список элементов
        /// </summary>
        public List<IElement> Elements;
        
        /// <summary>
        /// Тип соединения
        /// </summary>
        public ConnectionType ConnectionType;

        /// <summary>
        /// Зажигается при изменении элементов в цепи
        /// </summary>
        public event EventHandler CircuitChanged;

        public Circuit() 
        {
            Elements = new List<IElement>();
        }

        /// <summary>
        /// Добавить элемент по указанному индексу
        /// </summary>
        /// <param name="element">Элемент схемы</param>
        /// <param name="index">Индекс</param>
        public void AddElement(IElement element, int index)
        {
            try
            {
                Elements.RemoveAt(index);
                Elements.Insert(index, element);
            }
            catch (ArgumentOutOfRangeException)
            {
                Elements.Add(element);
                
            }
            finally
            {
                Elements[index].ValueChanged += new EventHandler(Element_ValueChanged);
                if (CircuitChanged != null)
                {
                    CircuitChanged(this, null);   //при добавлении элемента зажигается событие 
                }
            }
            
        }

        /// <summary>
        /// Удалить элемент по заданному индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        public void RemoveElement(int index)
        {
            this.Elements.RemoveAt(index);
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);
            }
        }
        /// <summary>
        /// Расчитать импеданс цепи на заданных частотах
        /// </summary>
        /// <param name="frequencies">Список частот</param>
        /// <returns>Расчитанное значение импеданса</returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            Complex[] Z = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                Z[i] = 0;
                foreach  (IElement element in Elements)
                {
                    if (ConnectionType == ConnectionType.Series)
                    {
                        Z[i] += element.CalculateZ(frequencies[i]);
                    }
                    else
                    {
                        Z[i] += 1 / element.CalculateZ(frequencies[i]);
                    }
                    
                }
                if (ConnectionType == ConnectionType.Parallel)
                {
                    Z[i] = 1 / Z[i];
                }
            }
            return Z;
        }
        private void Element_ValueChanged(object sender, EventArgs e)
        {
            if (CircuitChanged != null)
            {
                CircuitChanged(this, null);   //при изменении элемента зажигается событие 
            }
        }
        
    }
}
