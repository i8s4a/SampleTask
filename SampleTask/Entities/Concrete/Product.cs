using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
	public class Product:IEntity
	{
		[Key]
		public virtual int Id { get; set; }
		//[RegularExpression("([0-9]+)")]
		public virtual long TCNO { get; set; }
		//[Required]
		public virtual string Name { get; set; }
		//[Required(ErrorMessage = "Şifre boş olamaz!")]
		public virtual string Password { get; set; }
		//[Compare("Password",ErrorMessage = "Girilen şifreler eşleşmiyor!")]
		public virtual string ConfirmPassword { get; set; }
		public virtual decimal Price { get; set; }
		public virtual string ForeignCurrency { get; set; }
		public virtual decimal CalculateValue { get; set; }

	}
}
