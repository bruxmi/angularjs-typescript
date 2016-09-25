using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiTypeScript.Core;

namespace WebApiTypeScript.Api.Base
{
	//public class BaseApiController<TBusinessService, TMappingService, TLoggerService> : ApiController
	public class BaseApiController<TBusinessService> : ApiController
	{

        protected const string ApiRouteBase = "api/";
        public BaseApiController()
            : this(
                AppContainer.Current.Resolve<TBusinessService>())//,
                //AppContainer.Current.Resolve<TMappingService>(),
                //AppContainer.Current.Resolve<TLoggerService>())
        {
        }
		public BaseApiController(TBusinessService service)
		{
			if (service == null)
			{
				throw new ArgumentNullException(nameof(service));
			}
			this.Service = service;
		}

		//public BaseApiController(TBusinessService service, TMappingService mapping, TLoggerService logger)
		//{
		//    if (service == null)
		//    {
		//        throw new ArgumentNullException(nameof(service));
		//    }

		//    if (mapping == null)
		//    {
		//        throw new ArgumentNullException(nameof(mapping));
		//    }

		//    if (logger == null)
		//    {
		//        throw new ArgumentNullException(nameof(logger));
		//    }

		//    this.Service = service;
		//    this.Mapping = mapping;
		//    this.Logger = logger;
		//}

		//protected TLoggerService Logger { get; }

  //      protected TMappingService Mapping { get; }

        protected TBusinessService Service { get; }
    }
}