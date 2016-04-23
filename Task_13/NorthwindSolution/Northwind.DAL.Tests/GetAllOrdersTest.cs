using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Northwind.DAL.Tests
{
    [TestClass]
    public class GetAllOrdersTest
    {
        [TestMethod]
        public void GetOrders()
        {            
                var order1 = new OrdersDAL();
                Assert.IsTrue(order1.GetAllOrders().Count > 0);           
        }

        [TestMethod]
        public void CreateOrder()
        {
            var order = new Order();
            order.CustomerID = "VINET";
            order.EmployeeID = 5;
            order.OrderDate = DateTime.Now;
            order.ShipVia = 1;
            order.Freight = 10.05m;
            order.ShipName = "Toms Spezialitäten";
            order.ShipAddress = "Luisenstr. 48";
            order.ShipCity = "Münster";
            order.ShipPostalCode = "44087";
            order.ShipCountry = "Germany";

            var dal = new OrdersDAL();
            dal.CreateNewOrder(order);
        }

        [TestMethod]
        public void GetOrderDetail()
        {
            var dal = new OrdersDAL();
            var order = dal.GetOrderDetails(11082);
        }

        [TestMethod]
        public void MakeComplete()
        {
            var dal = new OrdersDAL();
            dal.MakeComplete(11082, DateTime.Now);
        }

        [TestMethod]
        public void TakeOrder()
        {
            var dal = new OrdersDAL();
            dal.TakeOrder(11082, DateTime.Now);
        }
    }
}
