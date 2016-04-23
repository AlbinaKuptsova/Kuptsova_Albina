using System;
using System.Collections.Generic;

namespace Northwind.DAL
{
    interface IOrdersDAL
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(int id);
        int CreateNewOrder(Order order);
        bool TakeOrder(int id, DateTime date);
        bool MakeComplete(int id, DateTime date);
    }
}
