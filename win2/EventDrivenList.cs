namespace CircuitCalculation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Представляет список объектов, доступных по индексу. Поддерживает события.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventDrivenList<T> : List<T>
    {
        /// <summary>
        /// Зажигается при добавлении элемента.
        /// </summary>
        public event EventHandler ItemAdded;
        
        /// <summary>
        /// Зажигается при удалении элемента.
        /// </summary>
        public event EventHandler ItemRemoved;
        
        /// <summary>
        /// Добавляет элемент в конец списка.
        /// </summary>
        /// <param name="item">Объект для добавления в список.</param>
        public new void Add(T item)
        {
            base.Add(item);
            if (ItemAdded != null)
            {
                ItemAdded(this, null);
            }
        }
        
        /// <summary>
        /// Удаляет первое вхождение элемента из списка.
        /// </summary>
        /// <param name="item">Элемент, который требуется удалить.</param>
        /// <returns>Результат удаления.</returns>
        public new bool Remove(T item)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, null);
            }
            return base.Remove(item);
        }
        
        /// <summary>
        /// Удаляет элемент списка с указанным индексом. 
        /// </summary>
        /// <param name="index">Индекс</param>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            if (ItemRemoved != null)
            {
                ItemRemoved(this, null);
            }
        }
    }
}
