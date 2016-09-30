using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WebApiTypeScript.Core.Interfaces.Services.Query;

namespace WebApiTypeScript.Core
{
	/// <summary>
	/// Provides central access to the configuration.
	/// </summary>
	public static class AppConfiguration
	{
		/// <summary>
		///     Get the current configuration.
		/// </summary>
		public static IAppConfigurationService Current
			=> Factory ?? (Factory = AppContainer.Current.Resolve<IAppConfigurationService>());

		/// <summary>
		/// Gets or sets the factory.
		/// </summary>
		public static IAppConfigurationService Factory { private get; set; }
	}
}
