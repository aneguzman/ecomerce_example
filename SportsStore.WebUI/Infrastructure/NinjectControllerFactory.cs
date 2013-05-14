using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure {
	public class NinjectControllerFactory : DefaultControllerFactory {

		// A Ninject "kernel" is the thing that can supply object instances
		private IKernel kernel = new StandardKernel( new SportsStoreServices() );
		// ASP.NET MVC calls this to get the controller for each request
		protected override IController GetControllerInstance( RequestContext context,
		Type controllerType ) {
			if( controllerType == null )
				return null;
			return ( IController ) kernel.Get( controllerType );
		}
		// Configures how abstract service types are mapped to concrete implementations
		private class SportsStoreServices : NinjectModule {
			public override void Load() {
				// We'll add some configuration here in a moment
				Bind<IProductsRepository>()
					.To<SqlProductsRepository>()
					.WithConstructorArgument("connectionString",
                    ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString
					);
			}
		}
	}
}