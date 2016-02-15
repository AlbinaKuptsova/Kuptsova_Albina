using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
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
            StrSort sort1 = new StrSort(MethodStringSort);
            string[] ss = sort1(s);

            foreach(var elem in ss)
            {
                Console.WriteLine(elem);
            }
            Console.ReadKey();

        }

            public delegate string[] StrSort(string []s);

            static string[] MethodStringSort(string []s)
            {
            string[] s2 = s;
            //сортировка строк по длине
            for (int i = 0; i < s2.Length - 1; i++)
            {
                for (int j = i + 1; j < s2.Length; j++)
                {
                    if (s2[j].Length < s2[i].Length)
                    {
                        var temp = s2[i];
                        s2[i] = s2[j];
                        s2[j] = temp;
                    }
                    //поиск одинаковых строк и упорядочивание их по алфавиту
                    if (s2[j].Length == s2[i].Length  && s2[j].CompareTo(s2[i])<0)
                    {
                        var temp = s2[i];
                        s2[i] = s2[j];
                        s2[j] = temp;
                    }
                }
            }
            return s2;
        }
    }
}
