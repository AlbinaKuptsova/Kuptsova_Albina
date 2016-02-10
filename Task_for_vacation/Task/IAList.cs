using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public interface IAList<T>: IEnumerable<T>, ICloneable, IDisposable
    {
        void Insert(T elem, int index);
        void Remove(int index);
        T Get(int index);
    }
}
