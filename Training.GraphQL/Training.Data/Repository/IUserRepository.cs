using System;
using System.Collections.Generic;
using System.Text;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public interface IUserRepository
	{
		IEnumerable<User> GetAll();
		User GetById(long id);
		IEnumerable<User> GetByDepartmentId(long id);
		User CreateUser(User user);
		User UpdateUser(User newUser);
		String DeleteUser(User user);

	}
}
