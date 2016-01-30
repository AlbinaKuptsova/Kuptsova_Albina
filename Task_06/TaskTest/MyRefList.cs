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
    public class MyRefList
    {
        [TestMethod]
        public void InsertGetRefTest()
        {
            try
            {
                MyReferenceList<int> mr = new MyReferenceList<int>();

                mr.Insert(5, 0);
                int a = mr.Get(0);
                Assert.AreEqual(5, a);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }


        }
    }
}
