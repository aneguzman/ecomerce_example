using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SportsStore.Domain.Entities;
using SportsStore.WebUI;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests {
	[TestFixture]
	public class ShoppingCart {
		[Test]
		public void Cart_Starts_Empty() {
			new Cart().Lines.Count.ShouldEqual( 0 );
		}

		[Test]
		public void Cart_Combines_Lines_With_Same_Products() {
			// Arrange: Given we have two products
			Product p1 = new Product {
				ProductID = 1
			};
			Product p2 = new Product {
				ProductID = 2
			};

			var cart = new Cart();
			cart.AddItem( p1, 1 );
			cart.AddItem( p1, 2 );
			cart.AddItem( p2, 10 );

			cart.Lines.Count.ShouldEqual( 2 );
			cart.Lines.First( x => x.Product.ProductID == 1 ).Quantity.ShouldEqual( 3 );
			cart.Lines.First( x => x.Product.ProductID == 2 ).Quantity.ShouldEqual( 10 );
		}

		[Test]
		public void Car_Can_Be_Cleared() {
			var cart = new Cart();
			cart.AddItem( new Product(), 1 );

			cart.Clear();
			cart.Lines.Count.ShouldEqual( 0 );
		}

		[Test]
		public void Cart_TotalValue_Is_Sum_Of_Price_Times_Quantity() {
			Cart cart = new Cart();
			cart.AddItem( new Product {
				ProductID = 1, Price = 5
			}, 10 );
			cart.AddItem( new Product {
				ProductID = 2, Price = 2.1M
			}, 3 );
			cart.AddItem( new Product {
				ProductID = 3, Price = 1000
			}, 1 );

			cart.ComputeTotalValue().ShouldEqual( 1056.3M );
		}

		[Test]
		public void Cart_Can_Remove_An_Item() {
			var cart = new Cart();
			var productA = new Product {
				ProductID = 1, Price = 5
			};
			var productB = new Product {
				ProductID = 2, Price = 5
			};
			cart.AddItem( productA, 3 );
			cart.AddItem( productB, 1 );

			cart.RemoveLine( productA );
			cart.Lines.Count.ShouldEqual( 1 );
		}
		[Test]
		public void Can_Add_Product_To_Cart() {
			var mockProductsRepository = UnitTestHelpers.MockProductsRepository(
				new Product {
					ProductID = 123
				},
				new Product {
					ProductID = 456
				}
			);
			var cartController = new CartController( mockProductsRepository, null );
			var cart = new Cart();

			cartController.AddToCart( cart, 456, null );

			cart.Lines.Count.ShouldEqual( 1 );
			cart.Lines[0].Product.ProductID.ShouldEqual( 456 );
		}
		[Test]
		public void After_Adding_Product_To_Cart_User_Goes_To_Your_Cart_Screen() {
			var mockProductsRepository = UnitTestHelpers.MockProductsRepository(
				new Product {
					ProductID = 1
				}
			);
			var cartController = new CartController( mockProductsRepository, null );

			var result = cartController.AddToCart( new Cart(), 1, "someReturnUrl" );

			result.ShouldBeRedirectionTo( new {
				action = "Index",
				returnUrl = "someReturnUrl"
			} );
		}
		[Test]
		public void Can_Remove_Product_To_Cart()
		{
			var mockProductsRepository = UnitTestHelpers.MockProductsRepository(
				new Product {ProductID = 100},
				new Product {ProductID = 102}
			);
			var cartController = new CartController(mockProductsRepository, null);
			var cart = new Cart();
			cartController.AddToCart(cart, 100, null);
			cartController.AddToCart(cart, 102, null);

			cartController.RemoveFromCart(cart, 100, null);

			cart.Lines.Count.ShouldEqual(1);
			cart.Lines[0].Product.ProductID.ShouldEqual(102);
		}
		[Test]
		public void Can_View_Cart_Contents()
		{
			var cart = new Cart();
			var result = new CartController(null, null).Index(cart, "someReturnUrl");

			var viewModel = (CartIndexViewModel) result.ViewData.Model;
			viewModel.Cart.ShouldEqual(cart);
			viewModel.ReturnUrl.ShouldEqual("someReturnUrl");
		}
	}
}
