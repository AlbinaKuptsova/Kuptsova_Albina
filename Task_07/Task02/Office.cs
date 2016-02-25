using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    class Office
    {
        private List<Person> ListPerson = new List<Person>();
        public static MessageCome Greet;
        public static MessageLeave Part;
        public delegate void MessageCome(Person Name, TimeOfCame t);
        public delegate void MessageLeave(Person Name);

        public void ComePerson(Person p, TimeOfCame TimeCame)
        {
            Console.WriteLine("[{0} came to work]\n", p.Name);

            foreach (var elem in ListPerson)
            {
                MessageCome greet = new MessageCome(elem.Greeting);
                Greet += greet;
            }

            p.Came += CameHandler;
            p.OnCame(p, TimeCame);

            foreach (var elem in ListPerson)
            {
                MessageCome greet = new MessageCome(elem.Greeting);
                Greet -= greet;
            }

            ListPerson.Add(p);
        }

        public void LeavePerson(Person p)
        {
            Console.WriteLine("[{0} gone to home]\n", p.Name);
            ListPerson.Remove(p);
            foreach (var elem in ListPerson)
            {
                MessageLeave part = new MessageLeave(elem.Parting);
                Part += part;
            }
            p.Leave += LeaveHandler;
            p.OnLeave(p);
            foreach (var elem in ListPerson)
            {
                MessageLeave part = new MessageLeave(elem.Parting);
                Part -= part;
            }
        }

        static void CameHandler(Person p, TimeOfCame t)
        {
            if (Greet != null)
            {
                Greet(p, t);
            }
        }

        static void LeaveHandler(Person p)
        {
            if (Part != null)
            {
                Part(p);
            }
        }
    }
}
