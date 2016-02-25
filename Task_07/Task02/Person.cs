using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_02;

namespace Task_02
{
    class Person
    {
        public string Name { get; set; }

        public void Greeting(Person anotherPerson, TimeOfCame t)
        {
            if (t.TimeCame.Hour < 12)
            {
                Console.WriteLine("Good morning, {0}! - said {1}", anotherPerson.Name, Name);
            }
            else if (t.TimeCame.Hour > 17)
            {
                Console.WriteLine("Good evening, {0}! - said {1}", anotherPerson.Name, Name);
            }
            else
            {
                Console.WriteLine("Good afternoon, {0}! - said {1}", anotherPerson.Name, Name);
            }
        }

        public void Parting(Person anotherPerson)
        {
            Console.WriteLine("Good bye, {0}! - said {1}", anotherPerson.Name, Name);
        }

        public delegate void MessageCome(Person Name, TimeOfCame t);
        public delegate void MessageLeave(Person Name);
        public event MessageCome Came;
        public event MessageLeave Leave;

        public virtual void OnCame(Person p, TimeOfCame t)
        {
            if (p.Came != null)
            {
                p.Came(p, t);
            }
        }

        public virtual void OnLeave(Person p)
        {
            if (p.Leave != null)
            {
                p.Leave(p);
            }
        }
    }
}
