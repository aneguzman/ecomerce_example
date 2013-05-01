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
    	public int PageSize = 4;
		public ProductsController(IProductsRepository productsRepository)
		{
			this.productsRepository = productsRepository;
		}
        public ViewResult List(int page = 1)
        {
			return View(productsRepository.Products
				.Skip((page-1) * PageSize)
				.ToList());
        }

    }
}
