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
    public class PlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plans
        public ActionResult Index()
        {
            return View(db.Plan.ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // GET: Plans/Create
		[Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
			PopulateEntreeDropDownList();
			PopulateSideDropDownList();
			PopulateFruitDropDownList();
			PopulateVegetableDropDownList();
			PopulateBeverageDropDownList();
			PopulateDessertDropDownList();
			return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanName,Entree,Fruit,Vegetable,Side,Beverage,Dessert")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Plan.Add(plan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			PopulateEntreeDropDownList();
			PopulateSideDropDownList();
			PopulateFruitDropDownList();
			PopulateVegetableDropDownList();
			PopulateBeverageDropDownList();
			PopulateDessertDropDownList();
			return View(plan);
        }

        // GET: Plans/Edit/5
		[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }

			PopulateEntreeDropDownList();
			PopulateSideDropDownList();
			PopulateFruitDropDownList();
			PopulateVegetableDropDownList();
			PopulateBeverageDropDownList();
			PopulateDessertDropDownList();
			return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
		[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanName,Entree,Fruit,Vegetable,Side,Beverage,Dessert")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			PopulateEntreeDropDownList();
			PopulateSideDropDownList();
			PopulateFruitDropDownList();
			PopulateVegetableDropDownList();
			PopulateBeverageDropDownList();
			PopulateDessertDropDownList();
			return View(plan);
        }

		private void PopulateEntreeDropDownList()
		{
			var entrees = new List<string>();
			var entreesQuery = from f in db.Food
							   where f.FoodType == FoodType.Entree
							   select f.FoodName;
			entrees.AddRange(entreesQuery.Distinct());
			ViewBag.Entree = new SelectList(entrees);
		}

		private void PopulateSideDropDownList()
		{
			var sides = new List<string>();
			var sidesQuery = from f in db.Food
							 where f.FoodType == FoodType.Side
							 select f.FoodName;
			sides.AddRange(sidesQuery.Distinct());
			ViewBag.Side = new SelectList(sides);
		}

		private void PopulateFruitDropDownList()
		{
			var fruits = new List<string>();
			var fruitsQuery = from f in db.Food
							  where f.FoodType == FoodType.Fruit
							  select f.FoodName;
			fruits.AddRange(fruitsQuery.Distinct());
			ViewBag.Fruit = new SelectList(fruits);
		}

		private void PopulateVegetableDropDownList()
		{
			var veggies = new List<string>();
			var veggiesQuery = from f in db.Food
							   where f.FoodType == FoodType.Vegetable
							   select f.FoodName;
			veggies.AddRange(veggiesQuery.Distinct());
			ViewBag.Vegetable = new SelectList(veggies);
		}

		private void PopulateBeverageDropDownList()
		{
			var drinks = new List<string>();
			var drinksQuery = from f in db.Food
							  where f.FoodType == FoodType.Beverage
							  select f.FoodName;
			drinks.AddRange(drinksQuery.Distinct());
			ViewBag.Beverage = new SelectList(drinks);
		}

		private void PopulateDessertDropDownList()
		{
			var desserts = new List<string>();
			var dessertsQuery = from f in db.Food
								where f.FoodType == FoodType.Dessert
								select f.FoodName;
			desserts.AddRange(dessertsQuery.Distinct());
			ViewBag.Dessert = new SelectList(desserts);
		}


		// GET: Plans/Delete/5
		[Authorize(Roles = "Admin")]
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plan plan = db.Plan.Find(id);
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
		[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plan plan = db.Plan.Find(id);
            db.Plan.Remove(plan);
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
