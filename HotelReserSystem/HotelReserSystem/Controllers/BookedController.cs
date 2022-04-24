using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReserSystem.database_Access_Layer;
using HotelReserSystem.Models;


namespace HotelReserSystem.Controllers
{
    public class BookedController : Controller
    {
        readonly db dbdatabase_Access_Layer = new db();

        // GET: BookedController
        public ActionResult Index()
        {
            List<booked> bookedlist = dbdatabase_Access_Layer.GetAllbooked().ToList();
            return View(bookedlist);
        }

        // GET: BookedController/Details/5
        public ActionResult Details(int booking_id)
        {
            if (booking_id <= 0)
            {
                return NotFound();
            }
            booked Booked = dbdatabase_Access_Layer.GetBookedByid(booking_id);
            if (Booked == null)
            {
                return NotFound();
            }
            return View(Booked);
        }

        // GET: BookedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] booked Booked)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.InsertBooked(Booked);
                    return RedirectToAction("Index");

                }
                return View(Booked);
            }

            catch
            {
                return View();
            }
        }

        // GET: BookedController/Edit/5
        public ActionResult Edit(int booking_id)
        {
            if (booking_id <= 0)
            {
                return NotFound();
            }
            booked Booked = dbdatabase_Access_Layer.GetBookedByid(booking_id);
            if (Booked == null)
            {
                return NotFound();
            }
            return View(Booked);
        }

        // POST: BookedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int booking_id, [Bind] booked Booked)
        {
            try
            {
                if (booking_id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.UpdateBooked(Booked);
                    return RedirectToAction("Index");
                }
                return View(dbdatabase_Access_Layer);

            }
            catch
            {
                return View();
            }
        }

        // GET: BookedController/Delete/5
        public ActionResult Delete(int booking_id)
        {
            if (booking_id <= 0)
            {
                return NotFound();
            }
            booked Booked = dbdatabase_Access_Layer.GetBookedByid(booking_id);
            if (Booked == null)
            {
                return NotFound();
            }
            return View(Booked);
        }

        // POST: BookedController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int booking_id)
        {
            try
            {
                dbdatabase_Access_Layer.DeleteBooked(booking_id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
