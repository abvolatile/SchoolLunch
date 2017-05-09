using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SchoolLunch.Models
{
	public class UserPlan
	{
		[Key, Column(Order = 1)]
		public string UserEmail { get; set; }

		[Key, Column(Order = 2)]
		[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
		[Required]
		[StringLength(30)]
		public string Month { get; set; }

		[Display(Name = "Monday")]
		[Required]
		public string MondayPlan { get; set; }

		[Display(Name = "Tuesday")]
		[Required]
		public string TuesdayPlan { get; set; }

		[Display(Name = "Wednesday")]
		[Required]
		public string WednesdayPlan { get; set; }

		[Display(Name = "Thursday")]
		[Required]
		public string ThursdayPlan { get; set; }

		[Display(Name = "Friday")]
		[Required]
		public string FridayPlan { get; set; }

		//NAV props
		public ICollection<ApplicationUser> Users { get; set; }
		public ICollection<Plan> Plans { get; set; }
	}
}