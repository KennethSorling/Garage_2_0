﻿using System;
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
            var parkedvehicle = db.Vehicles.Select(p => p);

            if (orderBy == "regcode")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.RegCode);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "type")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.Type);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "brand")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.Brand);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "model")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.Model);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "color")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.Color);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "numberofwheels")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.NumberOfWheels);
                return View(parkedvehicle.ToList());
            }
            if (orderBy == "datecheckedin")
            {
                parkedvehicle = parkedvehicle.OrderBy(p => p.DateCheckedIn);
                return View(parkedvehicle.ToList());
            }
            return View(db.Vehicles.ToList());
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
        public ActionResult Edit([Bind(Include = "Id,RegCode,Type,Brand,Model,Color,NumberOfWheels")] ParkedVehicle parkedVehicle)
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
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.Vehicles.Find(id);
            var vm = new UnparkedVehicleViewModel(parkedVehicle);
            db.Vehicles.Remove(parkedVehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
                        vehicles = db.Vehicles.Where(p => p.DateCheckedIn == dateCheckedIn);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(vehicles.ToList());
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
            return HttpNotFound();
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
