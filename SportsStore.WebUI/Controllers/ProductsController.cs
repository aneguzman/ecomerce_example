using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        //
        // GET: /Products/
    	private IProductsRepository productsRepository;
		public ProductsController()
		{
			productsRepository = new FakeProductsRepository();
		}
        public ActionResult List()
        {
            return View(productsRepository.Products.ToList());
        }

    }
}
