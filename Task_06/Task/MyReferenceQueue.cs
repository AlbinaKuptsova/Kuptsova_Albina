using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyReferenceQueue<T> : IAQueue<T>, IEnumerable<T>, ICloneable, IDisposable
    {
        private Cell<T> last = null;

        public T Dequeue()
        {
            if (last.next == null)
                return last.data;
            
            var current = last;
            while (current.next.next != null)
            {
                current = current.next;
            }
            
            var T = current.next.data;
            current.next = null;
            return T;
        }

        public void Enqueue(T data)
        {
            var newCell = new Cell<T>();
            newCell.data = data;

            if (last == null)
            {
                last = newCell;
                last.next = null;
            }
            else
            {
                newCell.next = last;
                last = newCell;
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
