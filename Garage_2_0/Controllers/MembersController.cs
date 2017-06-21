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

namespace Garage_2_0.Controllers
{
    public class MembersController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Members
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

            var member = db.Members.Select(p => p);
            switch (orderBy)
            {
                case "firstname":
                    member = descending? member.OrderByDescending(p => p.FirstName) : member.OrderBy(p => p.FirstName);
                    break;
                case "lastname":
                    member = descending? member.OrderByDescending(p => p.LastName) : member.OrderBy(p => p.LastName);
                    break;
                case "age":
                    member = descending? member.OrderByDescending(p => p.Age) : member.OrderBy(p => p.Age);
                    break;
                case "phone":
                    member = descending? member.OrderByDescending(p => p.Phone) : member.OrderBy(p => p.Phone);
                    break;
                default:
                    break;
            }
            return View(member.ToList());

        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberId,FirstName,LastName,Age,Phone")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberId,FirstName,LastName,Age,Phone")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
        public ActionResult FindByMember(string by, string criteria)
        {
            if (criteria == "")
            {
                return View();
            }
            else
            {
                IQueryable<Member> member = db.Members;
                switch (by)
                {
                    case "firstname":
                        member = db.Members.Where(p => p.FirstName.StartsWith(criteria));
                        break;
                    case "lastname":
                        member = db.Members.Where(p => p.LastName == criteria);
                        break;
                    case "phone":
                        member = db.Members.Where(p => p.Phone == criteria);
                        break;
                    case "age":
                        {
                            int age = 0;
                            if (int.TryParse(criteria, out age))
                                member = db.Members.Where(p => p.Age == age);
                            else
                            {
                                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                                return View("SnakeEyes");
                            }
                            break;
                        }
                default:
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (member.ToList().Count == 0)
                {
                    return View("SnakeEyes");
                }

                return View("FindResults", member.ToList());
            }
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
