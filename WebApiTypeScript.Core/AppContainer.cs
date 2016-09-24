using Autofac;

namespace WebApiTypeScript.Core
{
	public class AppContainer
	{
		/// <summary>
		/// Gets the current instance of the container.
		/// </summary>
		public static IContainer Current => Factory;

		/// <summary>
		/// Gets or sets the factory.
		/// </summary>
		public static IContainer Factory { private get; set; }

		/// <summary>
		/// Creates a new instance of the container, 
		/// but without affecting the current instance.
		/// </summary>
		/// <returns>Returns an instance of type <see cref="IUnityContainer"/>.</returns>
		public static ContainerBuilder Create()
		{
			return new ContainerBuilder();
		}
	}
}