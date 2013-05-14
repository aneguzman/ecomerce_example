using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Services;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers {
	public class CartController : Controller {
		//
		// GET: /Cart/
		private IProductsRepository productsRepository;
		private IOrderSubmitter orderSubmitter; 
		public CartController( IProductsRepository productsRepository, IOrderSubmitter orderSubmitter ) {
			this.productsRepository = productsRepository;
			this.orderSubmitter = orderSubmitter;
		}
		public RedirectToRouteResult AddToCart( Cart cart, int productId, string returnUrl ) {
			Product product = productsRepository.Products.FirstOrDefault( x => x.ProductID == productId );
			cart.AddItem( product, 1 );
			return RedirectToAction( "Index", new {
				returnUrl
			} );
		}
		public RedirectToRouteResult RemoveFromCart( Cart cart, int productId, string returnUrl ) {
			Product product = productsRepository.Products.FirstOrDefault( x => x.ProductID == productId );
			cart.RemoveLine( product );
			return RedirectToAction( "Index", new {
				returnUrl
			} );
		}
		public ViewResult Index( Cart cart, string returnUrl ) {
			return View( new CartIndexViewModel {
				Cart = cart,
				ReturnUrl = returnUrl
			} );
		}
		public ViewResult Summary( Cart cart ) {
			return View( cart );
		}
		public ViewResult Checkout()
		{
			return View(new ShippingDetails());
		}
	}
}
