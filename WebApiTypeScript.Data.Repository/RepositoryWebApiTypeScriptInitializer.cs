﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;
using WebApiTypeScript.Data.AppContext;
using WebApiTypeScript.Data.Repository.Generic;

namespace WebApiTypeScript.Data.Repository
{
	public class RepositoryWebApiTypeScriptInitializer<T> : RepositoryBaseInitializer<T>
		where T : class, IEntity
	{
		public RepositoryWebApiTypeScriptInitializer(WebApiTypeScriptContext context) : base(context)
		{

		}
	}
}
