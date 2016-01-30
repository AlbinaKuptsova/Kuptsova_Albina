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
    public class MyQueueTest
    {
        [TestMethod]
        public void MyQueueArrayTest()
        {
            QueueTest(CollectionType.Array);
        }

        [TestMethod]
        public void MyQueueRefTest()
        {
            QueueTest(CollectionType.References);
        }


        [TestMethod]
        public void QueueTest(CollectionType collectionType){
            try
            {
                var queue = CollectionFactory.CreateAQueue<int>(collectionType,10);

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
