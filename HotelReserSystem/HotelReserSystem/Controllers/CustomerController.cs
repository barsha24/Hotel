using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReserSystem;
using HotelReserSystem.database_Access_Layer;
using HotelReserSystem.Models;


namespace HotelReserSystem.Controllers
{
    public class CustomerController : Controller
    {
        readonly db dbdatabase_Access_Layer = new db();
        // GET: CustomerController
        public ActionResult Index()
        {
            List<customers> customersList = dbdatabase_Access_Layer.GetAllcustomers().ToList();
            return View(customersList);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int customer_id)
        {
            if (customer_id <= 0)
            {
                return NotFound();
            }
            customers Customers = dbdatabase_Access_Layer.GetCustomerByid(customer_id);
            if (Customers == null)
            {
                return NotFound();
            }
            return View(Customers);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] customers Customers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.InsertCustomers(Customers);
                    return RedirectToAction("Index");

                }
                return View(Customers);
            }

            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int customer_id)
        {
            if (customer_id <= 0)
            {
                return NotFound();
            }
            customers Customers = dbdatabase_Access_Layer.GetCustomerByid(customer_id);
            if (Customers == null)
            {
                return NotFound();
            }
            return View(Customers);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int customer_id, [Bind] customers Customers)
        {
            try
            {
                if (customer_id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.UpdateCustomers(Customers);
                    return RedirectToAction("Index");
                }
                return View(dbdatabase_Access_Layer);

            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int customer_id)
        {
            if (customer_id <= 0)
            {
                return NotFound();
            }
            customers Customers = dbdatabase_Access_Layer.GetCustomerByid(customer_id);
            if (Customers == null)
            {
                return NotFound();
            }
            return View(Customers);
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int customer_id)
        {
            try
            {
                dbdatabase_Access_Layer.DeleteCustomers(customer_id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
