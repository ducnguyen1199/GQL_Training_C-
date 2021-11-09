using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Data.Models
{
	public class User
	{
		[Key]
		public long Id { get; set; }
		public string Name { get; set; }
		[ForeignKey("DepartmentId")]
		public long DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
