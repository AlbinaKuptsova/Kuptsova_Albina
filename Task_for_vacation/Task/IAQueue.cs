using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IAQueue<T>: IEnumerable<T>, ICloneable, IDisposable
    {
        void Enqueue(T data);
        T Dequeue();
    }
}
