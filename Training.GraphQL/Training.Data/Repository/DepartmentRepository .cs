using System.Collections.Generic;
using System.Linq;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;
		public DepartmentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Department> GetAll()
		{
			return _context.Departments;
		}
		public Department GetById(long id)
		{
			return _context.Departments.FirstOrDefault(d => d.Id.Equals(id));
		}
		public Department CreateDepartment(Department department)
		{
			_context.Departments.Add(department);
			_context.SaveChanges();
			return department;
		}

		public string DeleteDepartment(Department department)
		{
			_context.Departments.Remove(department);
			_context.SaveChanges();
			return $"Delete Department(id = {department.Id}) successful.";
		}

		public Department UpdateDepartment(Department department)
		{
			var oldDepartment = _context.Departments.FirstOrDefault(o => o.Id.Equals(department.Id));
			department = oldDepartment;
			_context.SaveChanges();
			return department;
		}
	}
}
