using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Program
    {
        static void HandlerGreet(Person p, TimeOfCame t)
        {
            if (Greet != null)
            {
                Console.WriteLine("[{0} came to work]\n", p.Name);
                Greet(p, p.TimeCame);
            }
            else
            {
                Console.WriteLine("[{0} came to work]\n", p.Name);
            }
        }
        static void HandlerPart(Person p)
        {
            if (Part != null)
            {
                Console.WriteLine("[{0} gone to home]\n", p.Name);
                Part(p);
            }
            else
            {
                Console.WriteLine("[{0} gone to home]\n", p.Name);
            }
        }
        static void Main(string[] args)
        {
            TimeOfCame t1 = new TimeOfCame { TimeCame = DateTime.Parse("9:00") };
            TimeOfCame t2 = new TimeOfCame { TimeCame = DateTime.Parse("11:00") };
            TimeOfCame t3 = new TimeOfCame { TimeCame = DateTime.Parse("15:00") };
            TimeOfCame t4 = new TimeOfCame { TimeCame = DateTime.Parse("21:00") };

            Person john = new Person { Name = "John", TimeCame = t1 };
            Person bill = new Person { Name = "Bill", TimeCame = t2 };
            Person hugo = new Person { Name = "Hugo", TimeCame = t3 };
            Person jack = new Person { Name = "jack", TimeCame = t4 };

            bill.Came += HandlerGreet;
            bill.MethodCame();
            jack.Came += HandlerGreet;
            jack.MethodCame();
            hugo.Came += HandlerGreet;
            hugo.MethodCame();

            jack.Leave += HandlerPart;
            jack.MethodLeave();
            john.Came += HandlerGreet;
            john.MethodCame();
            hugo.Leave += HandlerPart;
            hugo.MethodLeave();
            john.Leave += HandlerPart;
            john.MethodLeave();
            bill.Leave += HandlerPart;
            bill.MethodLeave();

            Console.ReadKey();



        }
        public static MessageCame Greet;
        public static MessageLeave Part;
        public delegate void MessageCame(Person Name, TimeOfCame t);
        public delegate void MessageLeave(Person Name);
        public class Person
        {
            public string Name { get; set; }
            public TimeOfCame TimeCame;

            public void Greeting(Person anotherPerson, TimeOfCame t)
            {
                if (t.TimeCame.Hour < 12)
                {
                    Console.WriteLine("Good Morning, {0}! - said {1}", anotherPerson.Name, Name);
                }
                else if (t.TimeCame.Hour > 17)
                {
                    Console.WriteLine("Good Evening, {0}! - said {1}", anotherPerson.Name, Name);
                }
                else
                {
                    Console.WriteLine("Good Afternoon, {0}! - said {1}", anotherPerson.Name, Name);
                }
            }

            public void Parting(Person anotherPerson)
            {
                Console.WriteLine("Good Bye, {0}! - said {1}", anotherPerson.Name, Name);
            }


            public event MessageCame Came;
            public event MessageLeave Leave;
            protected virtual void OnCame()
            {
                if (Came != null)
                {
                    Came(this, TimeCame);
                }
            }
            protected virtual void OnLeave()
            {
                if (Leave != null)
                {
                    Leave(this);
                }
            }

            public void MethodCame()
            {
                OnCame();
                MessageCame greet = new MessageCame(this.Greeting);
                Greet += greet;
                MessageLeave part = new MessageLeave(this.Parting);
                Part += part;
            }

            public void MethodLeave()
            {

                MessageCame greet = new MessageCame(this.Greeting);
                Greet -= greet;
                MessageLeave part = new MessageLeave(this.Parting);
                Part -= part;
                OnLeave();
            }

        }
        public class TimeOfCame : EventArgs
        {
            public DateTime TimeCame;
        }

    }

}
