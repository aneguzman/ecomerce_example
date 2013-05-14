using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Entities {
	public class Cart {
		private List<CartLine> lines = new List<CartLine>();
		public IList<CartLine> Lines {get { return lines; }} 

		public void AddItem(Product product, int quantity)
		{
			var line = lines.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
			if(line == null)
				lines.Add(new CartLine{Product = product, Quantity = quantity});
			else
				line.Quantity += quantity;
		}
		public decimal ComputeTotalValue()
		{
			return lines.Sum(l => l.Product.Price * l.Quantity);
		}
		public void Clear()
		{
			lines.Clear();
		}

		public void RemoveLine(Product product)
		{
			lines.RemoveAll(x => x.Product.ProductID == product.ProductID);
//			var productToDelete = lines.FirstOrDefault(x => x.Product.ProductID == product.ProductID);
//			lines.ForEach(line =>
//			              	{
//			              		if(line.Product.ProductID == product.ProductID && line.Quantity > 1) line.Quantity -= 1;
//								else if (line.Product.ProductID == product.ProductID && line.Quantity <= 1) lines.Remove(line);
//			              	});
		}

	}

	public class CartLine
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
