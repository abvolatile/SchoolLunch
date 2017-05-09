using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolLunch.Models
{
	public class Plan
	{
		[Key]
		public int PlanID { get; set; }

		[Display(Name = "Name")]
		[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
		[Required]
		[StringLength(30)]
		public string PlanName { get; set; }

		[Required]
		public string Entree { get; set; }

		[Required]
		public string Fruit { get; set; }

		[Required]
		public string Vegetable { get; set; }

		[Required]
		public string Side { get; set; }

		[Required]
		public string Beverage { get; set; }

		[Required]
		public string Dessert { get; set; }

		//NAV prop
		public ICollection<Food> Food { get; set; }
	}
}