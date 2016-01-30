﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class MyArrayQueue<T>: IAQueue<T>, IEnumerable<T>, ICloneable, IDisposable
    {
        T[] queue;
        int N;
        int start, cursor;
        
        public MyArrayQueue(int Max)
        {
            N = Max;
            queue = new T[N];
            start = -1;
            cursor = 0;
        }

        public void Enqueue(T data)
        {
            if (start == -1)
            {
                queue[0] = data;
                start = 0;
                cursor = 1;
            }
            else if (start % N != cursor % N)
            {
                queue[cursor % N] = data;
                cursor += 1;
            }
            else
            {
                return;
            }
        }

        public T Dequeue()
        {
            start += 1;
            return queue[start - 1];
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        object ICloneable.Clone()
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
    }
}
