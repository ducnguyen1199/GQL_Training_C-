using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Training.Data.Models
{
	public class User
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		public long DepartmentId { get; set; }
		[ForeignKey("RoleId")]
		public Department Department { get; set; }
	}
}
