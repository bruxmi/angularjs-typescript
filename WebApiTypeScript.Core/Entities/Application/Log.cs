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
	[Table("Log")]
	public class Log : IEntity
	{
		public DateTime Date { get; set; }

		[MaxLength]
		public string Exception { get; set; }

		public int Id { get; set; }

		[MaxLength(50)]
		public string Level { get; set; }

		[MaxLength(255)]
		public string Logger { get; set; }

		[MaxLength]
		public string Message { get; set; }

		[MaxLength(50)]
		public string RequestId { get; set; }

		[MaxLength(255)]
		public string TenantName { get; set; }

		[MaxLength(255)]
		public string Thread { get; set; }
	}
}
