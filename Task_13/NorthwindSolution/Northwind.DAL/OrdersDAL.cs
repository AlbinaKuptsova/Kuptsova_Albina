using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Northwind.DAL
{
    public class OrdersDAL : IOrdersDAL
    {
        public string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NorthwindDBConnection"].ConnectionString;
            }
        }

        public int CreateNewOrder(Order order)
        {
            string queryString = @"insert into Northwind.Orders(CustomerID, EmployeeID, OrderDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry) OUTPUT Inserted.OrderID values (@CustomerID, @EmployeeID, @OrderDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipPostalCode, @ShipCountry);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandText = queryString;
                    command.Parameters.Add(new SqlParameter("@CustomerID", order.CustomerID));
                    command.Parameters.Add(new SqlParameter("@EmployeeID", order.EmployeeID));
                    command.Parameters.Add(new SqlParameter("@OrderDate", order.OrderDate));
                    command.Parameters.Add(new SqlParameter("@ShipVia", order.ShipVia));
                    command.Parameters.Add(new SqlParameter("@Freight", order.Freight));
                    command.Parameters.Add(new SqlParameter("@ShipName", order.ShipName));
                    command.Parameters.Add(new SqlParameter("@ShipAddress", order.ShipAddress));
                    command.Parameters.Add(new SqlParameter("@ShipCity", order.ShipCity));
                    command.Parameters.Add(new SqlParameter("@ShipPostalCode", order.ShipPostalCode));
                    command.Parameters.Add(new SqlParameter("@ShipCountry", order.ShipCountry));

                    order.OrderID = (int)command.ExecuteScalar();
                }
            }
            return order.OrderID;
        }

        public List<Order> GetAllOrders()
        {
            var result = new List<Order>();
            string queryString = "select * from Northwind.Orders;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        var order = new Order();

                        order.OrderID = Convert.ToInt32(reader["OrderID"]);
                        order.CustomerID = Convert.ToString(reader["CustomerID"]);
                        order.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        order.OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]);
                        order.RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) ? (DateTime?)null : Convert.ToDateTime(reader["RequiredDate"]);
                        order.ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? (DateTime?)null : Convert.ToDateTime(reader["ShippedDate"]);
                        order.ShipVia = Convert.ToInt32(reader["ShipVia"]);
                        order.Freight = Convert.ToDecimal(reader["Freight"]);
                        order.ShipName = Convert.ToString(reader["ShipName"]);
                        order.ShipAddress = Convert.ToString(reader["ShipAddress"]);
                        order.ShipCity = Convert.ToString(reader["ShipCity"]);
                        order.ShipRegion = Convert.ToString(reader["ShipRegion"]);
                        order.ShipPostalCode = Convert.ToString(reader["ShipPostalCode"]);
                        order.ShipCountry = Convert.ToString(reader["ShipCountry"]);

                        result.Add(order);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return result;
        }

        public Order GetOrderDetails(int id)
        {
            var order = new Order();
            string queryString = "select * from Northwind.Orders where OrderID = @OrderID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@OrderID", id));

                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        order.OrderID = Convert.ToInt32(reader["OrderID"]);
                        order.CustomerID = Convert.ToString(reader["CustomerID"]);
                        order.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        order.OrderDate = reader.IsDBNull(reader.GetOrdinal("OrderDate")) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]);
                        order.RequiredDate = reader.IsDBNull(reader.GetOrdinal("RequiredDate")) ? (DateTime?)null : Convert.ToDateTime(reader["RequiredDate"]);
                        order.ShippedDate = reader.IsDBNull(reader.GetOrdinal("ShippedDate")) ? (DateTime?)null : Convert.ToDateTime(reader["ShippedDate"]);
                        order.ShipVia = Convert.ToInt32(reader["ShipVia"]);
                        order.Freight = Convert.ToDecimal(reader["Freight"]);
                        order.ShipName = Convert.ToString(reader["ShipName"]);
                        order.ShipAddress = Convert.ToString(reader["ShipAddress"]);
                        order.ShipCity = Convert.ToString(reader["ShipCity"]);
                        order.ShipRegion = Convert.ToString(reader["ShipRegion"]);
                        order.ShipPostalCode = Convert.ToString(reader["ShipPostalCode"]);
                        order.ShipCountry = Convert.ToString(reader["ShipCountry"]);
                    }
                }
                finally
                {
                    reader.Close();
                }

                string queryString1 = "select * from Northwind.[Order Details Extended] where OrderID = @OrderID;";
                SqlCommand command1 = new SqlCommand(queryString1, connection);
                command1.Parameters.Add(new SqlParameter("@OrderID", id));

                SqlDataReader reader1 = command1.ExecuteReader();
                try
                {
                    while (reader1.Read())
                    {
                        var orderdetail = new OrderDetail();

                        orderdetail.OrderID = Convert.ToInt32(reader1["OrderID"]);
                        orderdetail.ProductID = Convert.ToInt32(reader1["ProductID"]);
                        orderdetail.ProductName = Convert.ToString(reader1["ProductName"]);
                        orderdetail.UnitPrice = Convert.ToDecimal(reader1["UnitPrice"]);
                        orderdetail.Quantity = Convert.ToInt32(reader1["Quantity"]);
                        orderdetail.Discount = Convert.ToSingle(reader1["Discount"]);
                        orderdetail.ExtendedPrice = Convert.ToDecimal(reader1["ExtendedPrice"]);

                        order.OrderDetails.Add(orderdetail);
                    }
                }
                finally
                {
                    reader1.Close();
                }
            }
            return order;
        }

        public bool MakeComplete(int id, DateTime date)
        {
            string queryString = "update Northwind.Orders set OrderDate = @DateNow where OrderID = @OrderID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@OrderID", id));
                    command.Parameters.Add(new SqlParameter("@DateNow", date));

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }

        public bool TakeOrder(int id, DateTime date)
        {
            string queryString = "update Northwind.Orders set ShippedDate = @DateNow where OrderID = @OrderID;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@OrderID", id));
                    command.Parameters.Add(new SqlParameter("@DateNow", date));

                    command.ExecuteNonQuery();
                }
            }
            return true;
        }
    }
}
