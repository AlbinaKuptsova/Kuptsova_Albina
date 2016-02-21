using System;

namespace Task01
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Выберете режим работы с папкой. Введите 0 для НАБЛЮДЕНИЕ. Введите 1 для ОТКАТ");
            int choise = int.Parse(Console.ReadLine());
            if (choise == 0)
            {
                Watcher w = new Watcher(args[0], args[1]);
            }
            else {
                Backuper b = new Backuper(args[0], args[1]);
            }

            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }
        

    }


}
