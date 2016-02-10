using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IAStack<T>: IEnumerable<T>, ICloneable, IDisposable
    {
        void Push(T elem);
        T Pop();
    }
}
