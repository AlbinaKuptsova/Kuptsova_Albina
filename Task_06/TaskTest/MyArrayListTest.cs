using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Task;

namespace TaskTest
{
    [TestClass]
    public class MyListTest
    {
        [TestMethod]
        public void ArrayInsertTest()
        {
            InsertTest(CollectionType.Array);
        }

        [TestMethod]
        public void RefInsertTest()
        {
            InsertTest(CollectionType.References);
        }

        private void InsertTest(CollectionType collectionType)
        {
            try
            {
                var ma = CollectionFactory.CreateAList<int>(collectionType, 10);
                ma.Insert(5, 0);

                int a = ma.Get(0);

                Assert.AreEqual(a, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    }
}
