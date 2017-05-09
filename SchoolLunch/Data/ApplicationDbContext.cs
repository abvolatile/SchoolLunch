using Microsoft.AspNet.Identity.EntityFramework;
using SchoolLunch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolLunch.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<Food> Food { get; set; }
		public DbSet<Plan> Plan { get; set; }
		public DbSet<UserPlan> UserPlan { get; set; }


		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}