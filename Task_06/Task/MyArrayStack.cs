using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyArrayStack<T> : IAStack<T>, IEnumerable<T>, ICloneable, IDisposable

    {
        int current;
        int Max;
        T[] A;

        public MyArrayStack(int N)
        {
            Max = N;
            A = new T[Max];
            current = 0;
        }

        public T Pop()
        {
            current -= 1;
            return A[current];
        }

        public void Push(T elem)
        {
            A[current] = elem;
            current += 1;
        }

        void IAStack<T>.Push(T elem)
        {
            throw new NotImplementedException();
        }

        T IAStack<T>.Pop()
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
