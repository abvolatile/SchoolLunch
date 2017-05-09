namespace SchoolLunch.Migrations
{
	using SchoolLunch.Data;
	using SchoolLunch.Models;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolLunch.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//

			context.Food.AddOrUpdate(f => f.FoodName,
				new Food { FoodName = "Chicken Sandwich", FoodType = FoodType.Entree },
				new Food { FoodName = "Green Beans", FoodType = FoodType.Vegetable },
				new Food { FoodName = "Apple", FoodType = FoodType.Fruit },
				new Food { FoodName = "Mac & Cheese", FoodType = FoodType.Side },
				new Food { FoodName = "Milk", FoodType = FoodType.Beverage },
				new Food { FoodName = "Chocolate Chip Cookie", FoodType = FoodType.Dessert },
				new Food { FoodName = "Corn Dog", FoodType = FoodType.Entree },
				new Food { FoodName = "Salad", FoodType = FoodType.Vegetable },
				new Food { FoodName = "Banana", FoodType = FoodType.Fruit },
				new Food { FoodName = "Potato Chips", FoodType = FoodType.Side },
				new Food { FoodName = "Juice", FoodType = FoodType.Beverage },
				new Food { FoodName = "Blueberry Muffin", FoodType = FoodType.Dessert }
				);

			context.Plan.AddOrUpdate(p => p.PlanName,
				new Plan {
					PlanName = "Chicken Sandwich",
					Entree = "Chicken Sandwich",
					Side = "Mac & Cheese",
					Vegetable = "Green Beans",
					Fruit = "Apple",
					Beverage = "Milk",
					Dessert = "Chocolate Chip Cookie" },
				new Plan {
					PlanName = "Corn Dog",
					Entree = "Corn Dog",
					Side = "Potato Chips",
					Vegetable = "Salad",
					Fruit = "Banana",
					Beverage = "Juice",
					Dessert = "Blueberry Muffin" },
				new Plan {
					PlanName = "Broccoli Beef",
					Entree = "Broccoli Beef",
					Side = "Steamed Rice",
					Vegetable = "Carrots",
					Fruit = "Orange",
					Beverage = "Green Tea",
					Dessert = "Fortune Cookie" }
				);
        }
    }
}
