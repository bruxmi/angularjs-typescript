namespace WebApiTypeScript.Data.AppContext
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using Core.Entities;

	public class WebApiTypeScriptContext : DbContext
	{
		public WebApiTypeScriptContext()
			: base("name=WebApiTypeScriptContext")
		{ 

		}

		public virtual DbSet<User> User { get; set; }
	}
}