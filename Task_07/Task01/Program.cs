using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку: ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку: ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Введите третью строку: ");
            string s3 = Console.ReadLine();
            Console.WriteLine("Введите четвертую строку: ");
            string s4 = Console.ReadLine();
            Console.WriteLine("Введите пятую строку: ");
            string s5 = Console.ReadLine();

            string[] s = { s1, s2, s3, s4, s5 };
            AlphabetArraySort SortArray = new AlphabetArraySort(AlphLengthSortString);
            string[] ss = MethodStringSort(s, SortArray);

            Console.WriteLine("Отсортированный массив:");
            foreach (var elem in ss)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();


        }

        public delegate int AlphabetArraySort(string s1, string s2);

        public static string[] MethodStringSort(string[] s, AlphabetArraySort sort)
        {
            string[] s2 = s;
            for (int i = 0; i < s2.Length - 1; i++)
            {
                for (int j = i + 1; j < s2.Length; j++)
                {
                    if (sort(s2[j], s2[i]) == 1)
                    {
                        var temp = s2[i];
                        s2[i] = s2[j];
                        s2[j] = temp;
                    }
                }
            }
            return s2;
        }

        static int AlphLengthSortString(string str1, string str2)
        {
            if (str1.Length < str2.Length)
            {
                return 1;
            }
            else if (str1.Length > str2.Length)
            {
                return -1;
            }
            else if (str2.CompareTo(str1) < 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }

        }
    }
}
