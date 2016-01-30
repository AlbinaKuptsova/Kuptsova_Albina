using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyReferenceStack<T> : IAStack<T>, IEnumerable<T>, ICloneable, IDisposable
    {
        private Cell<T> first = null; 
        
        public T Pop()
        {
            if (first == null)
                throw new Exception("Стек пуст");

            var cell = first.data;
            first = first.last;
            return cell;
        }

        public void Push(T elem)
        {
            var newCell = new Cell<T>();
            newCell.data = elem;

            if (first == null)
            {
                first = newCell;
                newCell.last = null;
            }
            else
            {
                newCell.last = first;
                first = newCell;
            }
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
