﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTypeScript.Core.Interfaces.Services.Query
{
	public interface IRepositoryApplicationSettingInitializer<T> : IRepositoryInitializer<T>
		where T : class, IEntity
	{
	}
}
