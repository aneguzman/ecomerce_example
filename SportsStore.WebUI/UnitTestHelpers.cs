using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
	}


}