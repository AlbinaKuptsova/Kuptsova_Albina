using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    public class DynamicArray<T> : IEnumerable where T : IComparable<T>
    {
        int Max;
        T[] A;

        public DynamicArray()
        {
            A = new T[8];
            Max = 0;
        }

        public DynamicArray(int N)
        {
            A = new T[N];
            Max = 0;
        }

        public DynamicArray(IEnumerable<T> collect)
        {
            A = new T[collect.Count<T>()];
            int i = 0;
            foreach (var elem in collect)
            {
                A[i] = elem;
                i++;
            }
            Max = collect.Count<T>();
        }

        private void NewDynamicArray()
        {
            var Max1 = A.Length;
            T[] B = new T[Max1];
            for (int i = 0; i < Max1; i++)
            {
                B[i] = A[i];
            }

            A = new T[2 * Max1];
            for (int i = 0; i < Max1; i++)
            {
                A[i] = B[i];
            }
        }

        public void Add(T data)
        {
            if (Max != A.Length)
            {
                A[Max] = data;
                Max += 1;
            }
            else
            {
                NewDynamicArray();
                A[Max] = data;
                Max += 1;
            }
        }

        public void AddRange(IEnumerable<T> collect)
        {
            var p = collect.Count<T>();
            if (Max + p <= A.Length)
            {
                foreach (var elem in collect)
                {
                    A[Max] = elem;
                    Max += 1;
                }
            }
            else
            {
                while (Max + p > A.Length)
                {
                    NewDynamicArray();
                }
                foreach (var elem in collect)
                {
                    A[Max] = elem;
                    Max += 1;
                }
            }
        }

        public bool Remove(T data)
        {
            bool flag = true;
            bool exit = false;
            int k = 0;
            while (exit == false)
            {
                if (A[k].CompareTo(data) == 0)
                {
                    for (int i = k; i < Max; i++)
                    {
                        A[i] = A[i + 1];
                    }
                    flag = true;
                    exit = true;
                    Max -= 1;
                }
                else
                {
                    k += 1;
                }

                if (k > Max)
                {
                    exit = true;
                    flag = false;
                }
            }
            return flag;
        }

        public bool Insert(int ind, T data)
        {
            bool flag;
            if (ind < 0 && ind > A.Length)
            {
                throw new ArgumentOutOfRangeException("Выход индекса за пределы массива");
            }
            else
            {
                if (Max == A.Length)
                {
                    NewDynamicArray();
                }
                for (int i = Max + 1; i > ind; i--)
                {
                    A[i] = A[i - 1];
                }
                A[ind] = data;
                flag = true;
                return flag;
            }
        }

        public class DynamicArrayEnumerator : IEnumerator
        {
            int position = -1;
            public T[] mas;
            int M;

            public DynamicArrayEnumerator(T[] list, int Z)
            {
                mas = list;
                M = Z;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return mas[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }

            }
            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                position++;
                return (position < M);
            }

            public void Reset()
            {
                position = -1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new DynamicArrayEnumerator(A, Max);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public int Length
        {
            get { return Max; }
        }

        public int Capacity
        {
            get { return A.Length; }
        }

        public T this[int index]
        {
            get
            {
                return A[index];
            }
        }
    }
}
