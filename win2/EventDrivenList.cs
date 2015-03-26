using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CircuitCalculation
{
    //TODO: где xml-комментарий?
    public class EventDrivenList<T> : List<T>
    {
        //TODO: где xml-комментарий?
        public event EventHandler ItemAdded;
        //TODO: где xml-комментарий?
        public event EventHandler ItemRemoved;
        //TODO: где xml-комментарий?
        public new void Add(T item)
        {
            base.Add(item);
            if (ItemAdded != null)
            {
                ItemAdded(this, null);
            }
        }
        //TODO: где xml-комментарий?
        public new bool Remove(T item)
        {
            if (ItemRemoved != null)
            {
                ItemRemoved(this, null);
            }
            return base.Remove(item);
        }
        //TODO: где xml-комментарий?
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
