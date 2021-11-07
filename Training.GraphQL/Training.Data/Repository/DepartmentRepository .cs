using System;
using System.Collections.Generic;
using System.Linq;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private static IList<Department> departments = new List<Department>
		{
			new Department
			{
				Id = 1,
				Name = "PG2-DC13",
			},
			new Department
			{
				Id = 2,
				Name = "Data-Gene",
			}
		};
		public IEnumerable<Department> GetAll()
		{
			return departments;
		}
		public Department GetById(long id)
		{
			return departments.FirstOrDefault(d => d.Id.Equals(id));
		}
	}
}
