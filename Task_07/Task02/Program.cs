using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeOfCame t1 = new TimeOfCame { TimeCame = DateTime.Parse("9:00") };
            TimeOfCame t2 = new TimeOfCame { TimeCame = DateTime.Parse("11:00") };
            TimeOfCame t3 = new TimeOfCame { TimeCame = DateTime.Parse("15:00") };
            TimeOfCame t4 = new TimeOfCame { TimeCame = DateTime.Parse("21:00") };

            Office Office1 = new Office();

            Person john = new Person { Name = "John" };
            Person bill = new Person { Name = "Bill" };
            Person hugo = new Person { Name = "Hugo" };
            Person jack = new Person { Name = "Jack" };

            Office1.ComePerson(john, t1);
            Office1.ComePerson(bill, t2);
            Office1.ComePerson(hugo, t3);
            Office1.LeavePerson(bill);
            Office1.ComePerson(jack, t4);
            Office1.LeavePerson(hugo);
            Office1.LeavePerson(jack);
            Office1.LeavePerson(john);

            Console.ReadKey();



        }
    }

}
