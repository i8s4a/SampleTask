using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
	[Route("home")]
    public class HomeController : Controller
    {
	    private IProductService _productService;
	    private IServiceAdapter _serviceAdapter;

	    public HomeController(IProductService productService, IServiceAdapter serviceAdapter)
	    {
		    _productService = productService;
		    _serviceAdapter = serviceAdapter;
	    }

		[Route("")]
		[Route("index")]
		[Route("~/")]
		public IActionResult Index()
        {
	        
			return View();
        }

		public JsonResult List()
		{
			//_serviceAdapter.ServiceData();
			//var model = new ProductListModel
			//{
			//	Products = _productService.GetList()
			//};
			return Json(_productService.GetList());
		}

		public JsonResult GetById(int Id)
		{
			return Json(_productService.GetById(Id));
		}

	   

		[HttpPost]
	    public JsonResult CreateProduct(ProductListModel model)
	    {
		    var entity = new Product()
		    {
				TCNO = model.TCNO,
			    Name = model.Name,
			    Password = model.Password,
				ConfirmPassword = model.ConfirmPassword,
				ForeignCurrency = model.ForeignCurrency,
				Price = model.Price,
				CalculateValue = model.CalculateValue
		    };

			_productService.Add(entity);

		    return Json("");
		}

	
	    [HttpPost]
	    public JsonResult EditProduct(ProductListModel model)
	    {
		    var entity = _productService.GetById(model.Id);
		    

		    entity.TCNO = model.TCNO;
		    entity.Name = model.Name;
		    entity.Password = model.Password;
		    entity.ForeignCurrency = model.ForeignCurrency;
		    entity.Price = model.Price;
		    entity.CalculateValue = model.CalculateValue;

			_productService.Update(entity);

		    return Json(new JsonSerializerSettings());
		}

	    [HttpPost]
	    public JsonResult DeleteProduct(int id)
	    {
		    var entity = _productService.GetById(id);
		    if (entity!=null)
		    {
			    _productService.Delete(entity);
		    }

		    return Json(new JsonSerializerSettings());
	    }
	}
}