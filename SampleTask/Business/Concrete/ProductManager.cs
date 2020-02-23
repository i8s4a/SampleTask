using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class ProductManager:IProductService
	{
		private IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public Product GetById(int id)
		{
			return _productDal.Get(p => p.Id == id);
		}

		public List<Product> GetList()
		{
			return _productDal.GetList();
		}

		public void Add(Product product)
		{
			_productDal.Add(product);
		}

		public void Update(Product product)
		{
			_productDal.Update(product);
		}

		public void Delete(Product product)
		{
			_productDal.Delete(product);
		}
	}
}
