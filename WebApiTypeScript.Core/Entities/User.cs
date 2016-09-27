using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTypeScript.Core.Interfaces;

namespace WebApiTypeScript.Core.Entities
{
    public class User : IEntity
    {
	    public User()
	    {
			this.Courses = new HashSet<Course>();
		}
		public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
	}
}
