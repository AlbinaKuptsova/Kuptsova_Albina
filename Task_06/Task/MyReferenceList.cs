using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyReferenceList<T> : IAList<T>, IEnumerable<T>, ICloneable, IDisposable
    {
        public Cell<T> first;

        public T Get(int index)
        {
            var last = first;
            var i = 1;
            while (i != index)
            {
                i++;
                last = last.next;
            }
            return last.data;
        }

        public void Insert(T elem, int index)
        {
            var newCell = new Cell<T>();
            newCell.data = elem;

            var last = first;
            var i = 1;

            while (i != index - 1)
            {
                i++;
                last = last.next;
            }
            newCell.next = last.next;
            last.next = newCell;
        }

        public void Remove(int index)
        {
            if (index == 1)
            {
                first = first.next;
                return;
            }
            var last = first;
            var i = 1;

            while (i != index - 1)
            {
                i++;
                last = last.next;
            }
            last.next = last.next.next;
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
