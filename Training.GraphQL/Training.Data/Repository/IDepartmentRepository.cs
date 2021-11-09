using System;
using System.Collections.Generic;
using System.Text;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetAll();
		Department GetById(long id);
		Department CreateDepartment(Department user);
		Department UpdateDepartment(Department newUser);
		String DeleteDepartment(Department user);
	}
}
