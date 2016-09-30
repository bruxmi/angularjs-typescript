using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;

namespace WebApiTypeScript.Core.Entities.Application
{
	[Table("ApplicationSetting")]
	public class ApplicationSetting : IEntity
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		[Index(IsUnique = true)]
		public string Key { get; set; }

		public string Value { get; set; }
	}
}
