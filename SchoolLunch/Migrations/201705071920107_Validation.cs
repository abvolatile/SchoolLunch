namespace SchoolLunch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans");
            DropForeignKey("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans");
            DropIndex("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            DropIndex("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            DropPrimaryKey("dbo.UserPlans");
            AlterColumn("dbo.Foods", "FoodName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Plans", "PlanName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Plans", "Entree", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "Fruit", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "Vegetable", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "Side", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "Beverage", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "Dessert", c => c.String(nullable: false));
            AlterColumn("dbo.Plans", "UserPlan_Month", c => c.String(maxLength: 30));
            AlterColumn("dbo.UserPlans", "Month", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.UserPlans", "MondayPlan", c => c.String(nullable: false));
            AlterColumn("dbo.UserPlans", "TuesdayPlan", c => c.String(nullable: false));
            AlterColumn("dbo.UserPlans", "WednesdayPlan", c => c.String(nullable: false));
            AlterColumn("dbo.UserPlans", "ThursdayPlan", c => c.String(nullable: false));
            AlterColumn("dbo.UserPlans", "FridayPlan", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "UserPlan_Month", c => c.String(maxLength: 30));
            AddPrimaryKey("dbo.UserPlans", new[] { "UserEmail", "Month" });
            CreateIndex("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            CreateIndex("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            AddForeignKey("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans", new[] { "UserEmail", "Month" });
            AddForeignKey("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans", new[] { "UserEmail", "Month" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans");
            DropForeignKey("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans");
            DropIndex("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            DropIndex("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            DropPrimaryKey("dbo.UserPlans");
            AlterColumn("dbo.AspNetUsers", "UserPlan_Month", c => c.String(maxLength: 128));
            AlterColumn("dbo.UserPlans", "FridayPlan", c => c.String());
            AlterColumn("dbo.UserPlans", "ThursdayPlan", c => c.String());
            AlterColumn("dbo.UserPlans", "WednesdayPlan", c => c.String());
            AlterColumn("dbo.UserPlans", "TuesdayPlan", c => c.String());
            AlterColumn("dbo.UserPlans", "MondayPlan", c => c.String());
            AlterColumn("dbo.UserPlans", "Month", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Plans", "UserPlan_Month", c => c.String(maxLength: 128));
            AlterColumn("dbo.Plans", "Dessert", c => c.String());
            AlterColumn("dbo.Plans", "Beverage", c => c.String());
            AlterColumn("dbo.Plans", "Side", c => c.String());
            AlterColumn("dbo.Plans", "Vegetable", c => c.String());
            AlterColumn("dbo.Plans", "Fruit", c => c.String());
            AlterColumn("dbo.Plans", "Entree", c => c.String());
            AlterColumn("dbo.Plans", "PlanName", c => c.String());
            AlterColumn("dbo.Foods", "FoodName", c => c.String());
            AddPrimaryKey("dbo.UserPlans", new[] { "UserEmail", "Month" });
            CreateIndex("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            CreateIndex("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" });
            AddForeignKey("dbo.AspNetUsers", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans", new[] { "UserEmail", "Month" });
            AddForeignKey("dbo.Plans", new[] { "UserPlan_UserEmail", "UserPlan_Month" }, "dbo.UserPlans", new[] { "UserEmail", "Month" });
        }
    }
}
