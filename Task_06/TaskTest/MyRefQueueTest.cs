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
    public class MyRefQueueTest
    {
        [TestMethod]
        public void QueueRefTest()
        {
            try
            {
                MyReferenceQueue<int> queue = new MyReferenceQueue<int>();

                queue.Enqueue(5);
                queue.Enqueue(10);
                queue.Enqueue(15);

                int a = queue.Dequeue();
                int b = queue.Dequeue();
                int c = queue.Dequeue();

                Assert.AreEqual(a, 5);
                Assert.AreEqual(b, 10);
                Assert.AreEqual(c, 15);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    }
}
