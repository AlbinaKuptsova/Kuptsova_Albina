using System;
using System.Net;
using System.Web.Mvc;
using Northwind.DAL;

namespace Northwind.MVC
{
    public class OrdersController : Controller
    {
        private OrdersDAL ordersDal = new OrdersDAL();

        // GET: Orders
        public ActionResult Index()
        {
            return View(ordersDal.GetAllOrders());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = ordersDal.GetOrderDetails(id.Value);

            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,EmployeeID,ShipVia,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.Now;
                ordersDal.CreateNewOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult TakeOrder(int id)
        {
            ordersDal.TakeOrder(id, DateTime.Now);
            return RedirectToAction("Index");
        }

        public ActionResult MakeComplete(int id)
        {
            ordersDal.MakeComplete(id, DateTime.Now);
            return RedirectToAction("Index");
        }
    }
}
