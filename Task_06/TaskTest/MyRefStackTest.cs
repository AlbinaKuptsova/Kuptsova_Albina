using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task;

namespace TaskTest
{
    [TestClass]
    public class MyRefStackTest
    {
        [TestMethod]
        public void PushPopRefTest()
        {
            try
            {
                MyReferenceStack<int> stack = new MyReferenceStack<int>();

                stack.Push(5);
                stack.Push(10);
                stack.Push(15);

                int a = stack.Pop();
                int b = stack.Pop();
                int c = stack.Pop();
             //   int d = stack.Pop(); Exception (stack is empty)

                Assert.AreEqual(a, 15);
                Assert.AreEqual(b, 10);
                Assert.AreEqual(c, 5);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    }
}
