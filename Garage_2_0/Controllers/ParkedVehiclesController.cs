using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage_2_0.DataAccessLayer;
using Garage_2_0.Models;
using Garage_2_0.Enum;

namespace Garage_2_0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: ParkedVehicles
        public ActionResult Index(string orderBy)
        {
            bool descending = false;
            string sortOrder = "ascending";
            if (TempData["sortOrder"] != null)
            {
                sortOrder = TempData["sortOrder"].ToString();
                if (sortOrder == "ascending")
                {
                    TempData["sortOrder"] = "descending";
                }
            }
            else
            {
                TempData["sortOrder"] = "descending";
            }
            descending = sortOrder == "descending" ? true : false;

            var parkedvehicle = db.Vehicles.Select(p => p);
            switch (orderBy)
            {
                case "regcode":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.RegCode) : parkedvehicle.OrderBy(p => p.RegCode);
                    break;
                case "type":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.Type) : parkedvehicle.OrderBy(p => p.Type);
                    break;
                case "brand":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.Brand) : parkedvehicle.OrderBy(p => p.Brand);
                    break;
                case "model":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.Model) : parkedvehicle.OrderBy(p => p.Model);
                    break;
                case "color":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.Color) : parkedvehicle.OrderBy(p => p.Color);
                    break;
                case "numberofwheels":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.NumberOfWheels) : parkedvehicle.OrderBy(p => p.NumberOfWheels);
                    break;
                case "datecheckedin":
                    parkedvehicle = descending ? parkedvehicle.OrderByDescending(p => p.DateCheckedIn) : parkedvehicle.OrderBy(p => p.DateCheckedIn);
                    break;
                default:
                    break;
            }
            return View(parkedvehicle.ToList());

        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegCode,Type,Brand,Model,Color,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                parkedVehicle.DateCheckedIn = DateTime.Now;
                db.Vehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegCode,Type,Brand,Model,Color,NumberOfWheels,DateCheckedIn")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            if (parkedVehicle == null)
            {
                ViewBag.Id = id;
                return View("AlreadyDeleted");
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, bool? wantReceipt = false)
        {
            bool doWantReceipt = wantReceipt.HasValue && wantReceipt.Value;
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            var vm = new UnparkedVehicleViewModel(parkedVehicle);
            db.Vehicles.Remove(parkedVehicle);
            db.SaveChanges();
            if (!doWantReceipt) return RedirectToAction("Index");
            return View("Receipt", vm);
        }

        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }

        [HttpPost, ActionName("Find")]
        [ValidateAntiForgeryToken]
        public ActionResult FindBy(string by, string criteria)
        {
            if (criteria == "")
            {
                return View();
            }
            else
            {
                IQueryable<ParkedVehicle> vehicles = db.Vehicles;
                switch (by)
                {
                    case "regcode":
                        vehicles = db.Vehicles.Where(p => p.RegCode == criteria);
                        break;
                    case "type":
                        VehicleType t;
                        if (System.Enum.TryParse<VehicleType>(criteria, true, out t))
                        {
                            vehicles = db.Vehicles.Where(p => p.Type == t);
                        }
                        else
                        {
                            ViewBag.VehicleType = criteria;
                            return View("InvalidVehicleType");
                        }
                        break;
                    case "brand":
                        vehicles = db.Vehicles.Where(p => p.Brand == criteria);
                        break;
                    case "model":
                        vehicles = db.Vehicles.Where(p => p.Model == criteria);
                        break;
                    case "color":
                        VehicleColor color;
                        if (System.Enum.TryParse<VehicleColor>(criteria, true, out color))
                        {
                            vehicles = db.Vehicles.Where(p => p.Color == color);
                        }
                        else
                        {
                            ViewBag.Color = criteria;
                            return View("InvalidColor");
                        }

                        break;
                    case "numberofwheels":
                        int numberOfWheels = 0;
                        if (int.TryParse(criteria, out numberOfWheels))
                        {
                            vehicles = db.Vehicles.Where(p => p.NumberOfWheels == numberOfWheels);
                        }
                        else
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }

                        break;
                    case "datecheckedin":
                        DateTime dateCheckedIn;
                        if (DateTime.TryParse(criteria, out dateCheckedIn))
                        {
                            var matches = new List<ParkedVehicle>();
                            foreach (var v in vehicles)
                            {
                                if (null != v.DateCheckedIn && v.DateCheckedIn.ToString() == dateCheckedIn.ToString())
                                {
                                    matches.Add(v);
                                }
                            }

                            return View("FindResults", matches);

                            //vehicles = db.Vehicles.Where(p =>  p.DateCheckedIn.Equals(dateCheckedIn));
                        }
                        else
                        {
                            //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                            return View("SnakeEyes");
                        }
                        break;
                    default:
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (vehicles.ToList().Count == 0)
                {
                    return View("SnakeEyes");
                }

                return View("FindResults", vehicles.ToList());
            }
        }
        public ActionResult FindByRegCode(string regCode)
        {
            if (!string.IsNullOrEmpty(regCode))
            {
                var vehicle = db.Vehicles
                    .Where(p => p.RegCode == regCode)
                    .SingleOrDefault();

                if (vehicle != null) return View(vehicle);
            }
            return View("SnakeEyes");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
