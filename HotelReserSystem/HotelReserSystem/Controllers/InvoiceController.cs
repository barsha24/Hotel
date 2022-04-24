using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReserSystem.database_Access_Layer;
using HotelReserSystem.Models;

namespace HotelReserSystem.Controllers
{
    public class InvoiceController : Controller
    {
        readonly db dbdatabase_Access_Layer = new db();

        // GET: InvoiceController
        public ActionResult Index()
        {
            List<invoice> invoicelist = dbdatabase_Access_Layer.GetAllinvoice().ToList();
            return View(invoicelist);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int invoice_id)
        {
            if (invoice_id <= 0)
            {
                return NotFound();
            }
            invoice Invoice = dbdatabase_Access_Layer.GetInvoiceByid(invoice_id);
            if (Invoice == null)
            {
                return NotFound();
            }
            return View(Invoice);
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] invoice Invoice)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.InsertInvoice(Invoice);
                    return RedirectToAction("Index");

                }
                return View(Invoice);
            }

            catch
            {
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int invoice_id)
        {
            if (invoice_id <= 0)
            {
                return NotFound();
            }
            invoice Invoice = dbdatabase_Access_Layer.GetInvoiceByid(invoice_id);
            if (Invoice == null)
            {
                return NotFound();
            }
            return View(Invoice);
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int invoice_id, [Bind] invoice Invoice)
        {
            try
            {
                if (invoice_id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.UpdateInvoice(Invoice);
                    return RedirectToAction("Index");
                }
                return View(dbdatabase_Access_Layer);

            }
            catch
            {
                return View();
            }
        }

            // GET: InvoiceController/Delete/5
        public ActionResult Delete(int invoice_id)
        {
            if (invoice_id <= 0)
            {
                return NotFound();
            }
            invoice Invoice = dbdatabase_Access_Layer.GetInvoiceByid(invoice_id);
            if (Invoice == null)
            {
                return NotFound();
            }
            return View(Invoice);
        }

        // POST: InvoiceController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int  invoice_id)
        {
            try
            {
                dbdatabase_Access_Layer.DeleteInvoice(invoice_id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
