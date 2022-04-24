using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelReserSystem.database_Access_Layer;
using HotelReserSystem.Models;

namespace HotelReserSystem.Controllers
{
    public class RoomController : Controller
    {
        readonly db dbdatabase_Access_Layer = new db();
        // GET: RoomController
        public ActionResult Index()
        {
            List<rooms> RoomsList = dbdatabase_Access_Layer.GetAllrooms().ToList();
            return View(RoomsList);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int room_id)
        {
            if (room_id <= 0)
            {
                return NotFound();
            }
            rooms Rooms = dbdatabase_Access_Layer.GetRoomsByid(room_id);
            if (Rooms == null)
            {
                return NotFound();
            }
            return View(Rooms);
        }

        // GET: RoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] rooms Rooms)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.InsertRooms(Rooms);
                    return RedirectToAction("Index");

                }
                return View(Rooms);
            }

            catch
            {
                return View();
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int room_id)
        {
            if (room_id <= 0)
            {
                return NotFound();
            }
            rooms Rooms = dbdatabase_Access_Layer.GetRoomsByid(room_id);
            if (Rooms == null)
            {
                return NotFound();
            }
            return View(Rooms);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int room_id, [Bind] rooms Rooms)
        {
            try
            {
                if (room_id <= 0)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    dbdatabase_Access_Layer.UpdateRooms(Rooms);
                    return RedirectToAction("Index");
                }
                return View(dbdatabase_Access_Layer);

            }
            catch
            {
                return View();
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int room_id)
        {
            if (room_id <= 0)
            {
                return NotFound();
            }
            rooms Rooms = dbdatabase_Access_Layer.GetRoomsByid(room_id);
            if (Rooms == null)
            {
                return NotFound();
            }
            return View(Rooms);
        }
        // POST: RoomController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int room_id)
        {
            try
            {
                dbdatabase_Access_Layer.DeleteRooms(room_id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
