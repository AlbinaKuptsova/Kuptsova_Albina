using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_03;

namespace Task03Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                DynamicArray<int> arr1 = new DynamicArray<int>();
                DynamicArray<int> arr2 = new DynamicArray<int>(20);

                int[] arr3 = new[] { 1, 2, 3, 4, 5 };
                DynamicArray<int> arr4 = new DynamicArray<int>(arr3);

                var a = arr4.Length;
                Assert.AreEqual(a, 5);
                var b = arr4.Capacity;
                Assert.AreEqual(b, 5);

                arr4.Add(6);
                var a1 = arr4.Length;
                Assert.AreEqual(a1, 6);
                var b1 = arr4.Capacity;
                Assert.AreEqual(b1, 10);

                int[] arr31 = new[] { 7, 8, 9, 10, 11, 12 };
                arr4.AddRange(arr31);
                var a3 = arr4.Length;
                Assert.AreEqual(a3, 12);
                var b3 = arr4.Capacity;
                Assert.AreEqual(b3, 20);

                var flag1 = arr4.Remove(7);
                var a4 = arr4.Length;
                Assert.AreEqual(a4, 11);
                Assert.AreEqual(flag1, true);

                arr4.Insert(6, 7);
                var b4 = arr4[6];
                Assert.AreEqual(b4, 7);

                int k = 1;
                foreach (var elem in arr4)
                {
                    var a5 = elem;
                    Assert.AreEqual(a5, k);
                    k++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.AreEqual(0, 1);
            }
        }
    }
}
