using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NUnit.Framework;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI {
	public static class UnitTestHelpers {
		public static void ShouldEqual<T>(this T actualValue, T expectedValue)
		{
			Assert.AreEqual(expectedValue, actualValue);
		}
		public static IProductsRepository MockProductsRepository(params Product[] prods)
		{
			var mockProductsRepos = new Mock<IProductsRepository>();
			mockProductsRepos.Setup(x => x.Products).Returns(prods.AsQueryable());
			return mockProductsRepos.Object;
		} 
		public static void ShouldBeRedirectionTo(this ActionResult actionResult, object expectedRouteValues)
		{
			var actualValues = ((RedirectToRouteResult) actionResult).RouteValues;
			var expectedValues = new RouteValueDictionary(expectedRouteValues);

			foreach (var key in expectedValues.Keys)
			{
				actualValues[key].ShouldEqual(expectedValues[key]);
			}
		}
	}


}