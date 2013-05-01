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
			var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=SportStore;Integrated Security=True;Pooling=False";
			productsRepository = new SqlProductsRepository(connectionString);
            return View(productsRepository.Products.ToList());
        }

    }
}
