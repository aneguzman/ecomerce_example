using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Models;

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
        	var productsToShow = productsRepository.Products;
        	var viewModel = new ProductsListViewModel
        	                	{
        	                		Products = productsToShow.Skip((page - 1)*PageSize)
        	                			.ToList(),
        	                		PagingInfo = new PagingInfo
        	                		             	{
        	                		             		CurrentPage = page,
        	                		             		ItemsPerPage = PageSize,
        	                		             		TotalItems = productsToShow.Count()
        	                		             	}
        	                	}; 
			return View(viewModel);
        }

    }
}
