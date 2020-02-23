using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete
{
	public class EfProductDal:EfEntityRepositoryBase<Product,SampleTaskContext>,IProductDal
	{
	}
}
