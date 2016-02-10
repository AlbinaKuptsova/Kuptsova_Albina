using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст на английском языке");
            var s1 = Console.ReadLine();

            string[] split = s1.Split(new Char[] { ' ', '.'}, StringSplitOptions.RemoveEmptyEntries);
            List<string> words = new List<string>();
            foreach (var elem in split)
            {
                words.Add(elem.ToLower());
            }
            while (words.Count > 0)
            {
                int k = 1;
                for (int i = 1; i < words.Count; i++)
                {
                    if (words[0].Equals(words[i]))
                    {
                        k += 1;
                    }
                }
                var str1 = words[0];
                for (int i = 1; i <= k; i++)
                {
                    words.Remove(str1);
                }
                Console.WriteLine(String.Format("Слово {0} встречается {1} раз", str1, k));
            }
            Console.ReadKey();
        }
    }
}
