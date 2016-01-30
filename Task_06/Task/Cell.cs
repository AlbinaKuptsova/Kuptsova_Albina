using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Cell<T>
    {
        public T data;
        public Cell<T> next;
        public Cell<T> last;
    }
}