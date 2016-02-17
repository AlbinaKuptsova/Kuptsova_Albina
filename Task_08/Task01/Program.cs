using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public static class ArraySum
    {
        public static int SumArray(this int[] mass)
        {
            int sum = 0;
            foreach (var elem in mass)
            {
                sum += elem;
            }
            return sum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { -9, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sumArray = A.SumArray();
            Console.WriteLine(sumArray);
            Console.ReadKey();
        }
    }
}
