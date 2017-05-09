using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolLunch.Models
{
	public enum FoodType
	{
		Entree,
		Fruit,
		Vegetable,
		Side,
		Beverage,
		Dessert
	}

	public class Food
	{
		public int ID { get; set; }

		[Display(Name = "Name")]
		[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
		[Required]
		[StringLength(30)]
		public string FoodName { get; set; }

		[Display(Name = "Type")]
		[Required]
		public FoodType FoodType { get; set; }
	}
}