using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;

namespace WebApiTypeScript.Core.Entities
{
	public class Course : IEntity
	{
		public string CourseName { get; set; }
		public int Id { get; set; }
		public virtual User User { get; set; }
		[ForeignKey("User")]
		public int? UserId { get; set; }
	}
}
