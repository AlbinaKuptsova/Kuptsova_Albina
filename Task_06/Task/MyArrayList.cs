using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyArrayList<T> : IAList<T>
    {
        int current;
        int Max;
        T[] A;

        public MyArrayList(int N)
        {
            Max = N;
            A = new T[Max];
            current = 0;
        }

        public void Insert(T elem, int index)
        {

            if (index < 0)
                throw new Exception("Индекс должен быть положительным числом");

            if (index >= Max)
                throw new Exception("Индекс больше или равен максимуму");

            for (int i = current; i > index; i--)
            {
                A[i] = A[i - 1];
            }
            A[index] = elem;
            current += 1;
       }

        public void Remove(int index)
        {
            if (index < 0)
                throw new Exception("Индекс должен быть положительным числом");

            if (index >= Max)
                throw new Exception("Индекс больше или равен максимуму");


            for (int i = index; i < current; i++)
            {
                A[i] = A[i + 1];
                current -= 1;
            }
        }

        public T Get(int index)
        {
            if (index < 0)
                throw new Exception("Индекс должен быть положительным числом");

            if (index >= Max)
                throw new Exception("Индекс больше или равен максимуму");

            return A[index];
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
