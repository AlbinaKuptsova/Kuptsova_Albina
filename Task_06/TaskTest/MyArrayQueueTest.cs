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
    public class MyArrayQueueTest
    {
        [TestMethod]
        public void QueueTest(){
            try
            {
                MyArrayQueue<int> queue = new MyArrayQueue<int>(10);

                queue.Enqueue(5);
                queue.Enqueue(10);

                int a = queue.Dequeue();
                int b = queue.Dequeue();

                Assert.AreEqual(a, 5);
                Assert.AreEqual(b, 10);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    
    }
}
