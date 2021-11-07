using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Training.Data.Models
{
	public class Department
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
