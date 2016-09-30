using Autofac;

namespace WebApiTypeScript.Core
{
	public class AppContainer
	{

		public static IContainer Current => Factory;

		public static IContainer Factory { private get; set; }

		public static ContainerBuilder Create()
		{
			return new ContainerBuilder();
		}

		public static void UpdateContainer(ContainerBuilder builder)
		{
			builder.Update(Current);
		}
	}
}