namespace WebApiTypeScript.Data.AppContext
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class WebApiTypeScriptContext : DbContext
	{
		public WebApiTypeScriptContext()
			: base("name=WebApiTypeScriptContext")
		{
		}
	}
}