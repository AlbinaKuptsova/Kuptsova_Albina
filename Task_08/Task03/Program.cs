using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов массива:");
            int N = int.Parse(Console.ReadLine());
            Random r = new Random();
            int[] a;
            a = new int[N];
            for (int i = 0; i < N; i++)
            {
                a[i] = r.Next(-50, 50);
                Console.Write(a[i] + " ");
            }

            //Прямой метод
            List<TimeSpan> WatchList1 = new List<TimeSpan>();
            for(int i = 1; i<15; i++)
            {
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                PryamoyMethod(a);
                sw1.Stop();
                WatchList1.Add(sw1.Elapsed);
            }
            WatchList1.Sort();
            Console.WriteLine("\nЗатраченное время на вычисление прямым методом: {0}", WatchList1[7]);

            //Делегат
            List<TimeSpan> WatchList2 = new List<TimeSpan>();
            for (int i = 1; i < 15; i++)
            {
                DelegateMethod method1 = new DelegateMethod(MethodOfDelegate);
                Stopwatch sw2 = new Stopwatch(); 
                sw2.Start();
                MethodDelegate(a, method1);
                sw2.Stop();
                WatchList2.Add(sw2.Elapsed);
            }
            WatchList1.Sort();
            Console.WriteLine("Затраченное время на вычисление через делегат: {0}", WatchList2[7]);

            //Анонимный делегат
            DelegateMethod AnonimusPositiveElement = delegate (int elem)
            {
                if (elem > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            List<TimeSpan> WatchList3 = new List<TimeSpan>();
            for (int i = 1; i < 15; i++)
            {
               
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                MethodDelegate(a, AnonimusPositiveElement);
                sw3.Stop();
                WatchList3.Add(sw3.Elapsed);
            }
            WatchList3.Sort();
            Console.WriteLine("Затраченное время на вычисление через анонимный делегат: {0}", WatchList3[7]);

            //Лямбда-выражение
            DelegateMethod LambdaPositiveElement = (int elem) => elem > 0 ? true : false;

            List<TimeSpan> WatchList4 = new List<TimeSpan>();
            for (int i = 1; i < 15; i++)
            {

                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                MethodDelegate(a, LambdaPositiveElement);
                sw4.Stop();
                WatchList4.Add(sw4.Elapsed);
            }
            WatchList3.Sort();
            Console.WriteLine("Затраченное время на вычисление через лямбда-выражение: {0}", WatchList4[7]);

            //LINQ-выражение
            List<TimeSpan> WatchList5 = new List<TimeSpan>();
            for (int i = 1; i < 15; i++)
            {

                Stopwatch sw5 = new Stopwatch();
                sw5.Start();
                Positive(a);
                sw5.Stop();
                WatchList5.Add(sw5.Elapsed);
            }
            WatchList3.Sort();
            Console.WriteLine("Затраченное время на вычисление через LINQ-выражение: {0}", WatchList5[7]);

            Console.ReadKey();
        }

        public static IEnumerable<int> PryamoyMethod(int[] mass)
        {
            List <int> poselem = new List<int>();
            for (var i = 0; i < mass.Length; i++)
            {
                if (mass[i] > 0)
                {
                    poselem.Add(mass[i]);
                }
            }
            return poselem;
        }

        //Делегат
        public delegate bool DelegateMethod(int elem);
        public static bool MethodOfDelegate(int elem)
        {
            if (elem > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static IEnumerable<int> MethodDelegate(int[] mass, DelegateMethod delmeth)
        {
            List<int> poselem = new List<int>();
            foreach (var elem in mass)
            {
                if (delmeth(elem))
                {
                    poselem.Add(elem);
                }
            }
            return poselem;
        }

        //LINQ - выражение
        static List<int> Positive(int[] mass)
        {
            var result = from elem in mass
                         where elem > 0
                         select elem;
            return result.ToList<int>();
        }



    }
}
