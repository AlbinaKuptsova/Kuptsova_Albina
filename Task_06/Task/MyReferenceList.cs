using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyReferenceList<T> : IAList<T>
    {
        private Cell<T> first;

        public void Insert(T elem, int ind)
        {
            var newCell = new Cell<T>();
            newCell.data = elem;
            if (ind == 0)
            {
                newCell.next = first;
                first = newCell;
            }
            else
            {
                var last = first;
                var i = 0;

                while (i != ind - 1)
                {
                    i++;
                    last = last.next;
                }
                newCell.next = last.next;
                last.next = newCell;
            }
        }

        public void Remove(int ind)
        {
            if (ind == 0)
            {
                first = first.next;
                return;
            }

            var last = first;
            var i = 0;

            while (i != ind - 1)
            {
                i++;
                last = last.next;
            }
            last.next = last.next.next;
        }

        public T Get(int ind)
        {
            var last = first;
            var i = 0;
            while (i != ind)
            {
                i++;
                last = last.next;
            }
            return last.data;
        }


        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
