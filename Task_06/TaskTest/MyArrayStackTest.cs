using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task;

namespace TaskTest
{
    [TestClass]
    public class MyArrayStackTest
    {
        [TestMethod]
        public void PushPopTest()
        {
            try
            {
				MyArrayStack<int> stack = new MyArrayStack<int>(10);
                
				stack.Push(5);
				stack.Push(10);

				int a = stack.Pop();
				int b = stack.Pop();

                Assert.AreEqual(a, 10);
                Assert.AreEqual(b, 5);				

			}
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    }
}
