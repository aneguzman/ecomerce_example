﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests {
	[TestFixture]
	public class CatalogBrowsing {
		[Test]
		public void Can_View_A_Single_Page_Of_Products()
		{
			IProductsRepository repository= UnitTestHelpers.MockProductsRepository(
				new Product{Name="P1"}, new Product{Name = "P2"}, new Product{Name = "P3"}, new Product{Name = "P4"}, new Product{Name = "P5"}
			);
			var controller = new ProductsController(repository);
			controller.PageSize = 3;

			var result = controller.List(2);

			var displayedProducts = (IList<Product>) result.ViewData.Model;
			displayedProducts.Count.ShouldEqual(2);
			displayedProducts[0].Name.ShouldEqual("P4");
			displayedProducts[1].Name.ShouldEqual("P5");

		}
	}
}
