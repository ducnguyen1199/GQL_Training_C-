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
	}
}
