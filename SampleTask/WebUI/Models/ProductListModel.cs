using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace WebUI.Models
{
	public class ProductListModel
	{
		[Key]
		public int Id { get; set; }
		public long TCNO { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public decimal Price { get; set; }
		public string ForeignCurrency { get; set; }
		public decimal CalculateValue { get; set; }
		public List<Product> Products { get; set; }
	}
}
