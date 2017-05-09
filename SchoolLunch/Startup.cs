using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SchoolLunch.Data;
using SchoolLunch.Models;

[assembly: OwinStartupAttribute(typeof(SchoolLunch.Startup))]
namespace SchoolLunch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
			CreateRoles();
        }

		private void CreateRoles()
		{
			ApplicationDbContext context = new ApplicationDbContext();

			//adding custom roles
			var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			//creating the Admin role and seeding it to the database
			if (!RoleManager.RoleExists("Admin"))
			{
				//create the Admin role  
				var role = new IdentityRole();
				role.Name = "Admin";
				RoleManager.Create(role);

				//create the Admin user 
				var user = new ApplicationUser();
				user.UserName = "admin@futuretech.com";
				user.Email = "admin@futuretech.com";

				string userPWD = "Admin*123";

				var chkUser = UserManager.Create(user, userPWD);

				//Add Admin User to Admin Role   
				if (chkUser.Succeeded)
				{
					UserManager.AddToRole(user.Id, "Admin");
				}
			}
		}
	}
}
