using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task;

namespace TaskTest
{
    [TestClass]
    public class MyStackTest
    {
        [TestMethod]
        public void MyStackArrayTest()
        {
            StackTest(CollectionType.Array);
        }

        [TestMethod]
        public void MyStackRefTest()
        {
            StackTest(CollectionType.References);
        }           

        [TestMethod]
        public void StackTest(CollectionType collectionType)
        {
            try
            {
				var stack = CollectionFactory.CreateAStack<int>(collectionType,10);
                
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
