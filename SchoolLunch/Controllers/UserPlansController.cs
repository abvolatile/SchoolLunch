using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolLunch.Data;
using SchoolLunch.Models;

namespace SchoolLunch.Controllers
{
	[Authorize]
    public class UserPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserPlans
        public ActionResult Index()
        {
            return View(db.UserPlan.Where(p => p.UserEmail == User.Identity.Name).ToList());
        }

        // GET: UserPlans/Details/5
        public ActionResult Details(string email, string month)
        {
            if (month == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlan userPlan = db.UserPlan.Find(email, month);
            if (userPlan == null)
            {
                return HttpNotFound();
            }
            return View(userPlan);
        }

        // GET: UserPlans/Create
        public ActionResult Create()
        {
			PopulatePlansDropDownList();
			return View();
        }

		// POST: UserPlans/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Month,MondayPlan,TuesdayPlan,WednesdayPlan,ThursdayPlan,FridayPlan")] UserPlan userPlan)
        {
			userPlan.UserEmail = User.Identity.Name;

            if (ModelState.IsValid)
            {
                db.UserPlan.Add(userPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			PopulatePlansDropDownList();
            return View(userPlan);
        }

        // GET: UserPlans/Edit/5
        public ActionResult Edit(string email, string month)
        {
            if (month == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlan userPlan = db.UserPlan.Find(email, month);
            if (userPlan == null)
            {
                return HttpNotFound();
            }

			PopulatePlansDropDownList();
			return View(userPlan);
        }

        // POST: UserPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Month,MondayPlan,TuesdayPlan,WednesdayPlan,ThursdayPlan,FridayPlan")] UserPlan userPlan)
        {
			userPlan.UserEmail = User.Identity.Name;

			if (ModelState.IsValid)
            {
                db.Entry(userPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			PopulatePlansDropDownList();
			return View(userPlan);
        }

		private void PopulatePlansDropDownList()
		{
			var plans = new List<string>();
			var plansQuery = from p in db.Plan
							 orderby p.PlanName
							 select p.PlanName;
			plans.AddRange(plansQuery.Distinct());
			ViewBag.Plans = new SelectList(plans);
		}


		// GET: UserPlans/Delete/5
		public ActionResult Delete(string email, string month)
        {
            if (month == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPlan userPlan = db.UserPlan.Find(email, month);
            if (userPlan == null)
            {
                return HttpNotFound();
            }
            return View(userPlan);
        }

        // POST: UserPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string email, string month)
        {
            UserPlan userPlan = db.UserPlan.Find(email, month);
            db.UserPlan.Remove(userPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
