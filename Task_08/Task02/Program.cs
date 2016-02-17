using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public static class StringToIntPositive
    {
        public static bool IsPositiveElement(this string str)
        {
            string[] A = str.Split(new Char[] { '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var elem in A)
            {
                char[] CharArray = elem.ToCharArray();
                foreach (var charElem in CharArray)
                {
                    if (Char.IsDigit(charElem) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для проверки: ");
            var str = Console.ReadLine();
            bool flag = str.IsPositiveElement();
            if (flag)
            {
                Console.WriteLine("Число положительное");
            }
            else
            {
                Console.WriteLine("Число не положительное, либо было введено не число! ");
            }
            Console.ReadLine();
        }
    }
}