using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    /// <summary>
    /// Generic interface for Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAQueue<T>: IEnumerable<T>, ICloneable, IDisposable
    {
        void Enqueue(T data);
        T Dequeue();
    }
}
