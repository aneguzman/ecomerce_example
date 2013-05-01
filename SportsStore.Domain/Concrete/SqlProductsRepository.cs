using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete {
	public class SqlProductsRepository: IProductsRepository
	{
		private Table<Product> produtcsTable;

		public SqlProductsRepository(string connectionString)
		{
			produtcsTable = (new DataContext(connectionString)).GetTable<Product>();
		}

		public IQueryable<Product> Products
		{
			get { return produtcsTable; }
		}
	}
}
