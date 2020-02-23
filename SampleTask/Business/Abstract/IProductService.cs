using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IProductService
	{
		Product GetById(int id);
		List<Product> GetList();
		void Add(Product product);
		void Update(Product product);
		void Delete(Product product);

	}
}
