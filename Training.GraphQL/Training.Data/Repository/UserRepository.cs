using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public class UserRepository : IUserRepository
	{
		private static IList<User> users = new List<User>
		{
			new User
			{
				Id = 1,
				Name = "NCDUC",
				DepartmentId = 1,
			},
			new User
			{
				Id = 2,
				Name = "Nguyen Van A",
				DepartmentId = 1,
			},
			new User
			{
				Id = 3,
				Name = "ABC",
				DepartmentId = 2,
			}
		};
		public IEnumerable<User> GetAll()
		{
			return users;
		}

		public User GetById(long id)
		{
			return users.FirstOrDefault(u => u.Id.Equals(id));
		}

		public User CreateUser(User user)
		{
			users.Add(user);

			return user;
		}

		public User UpdateUser(User newUser)
		{
			var oldUser = users.FirstOrDefault(o => o.Id.Equals(newUser.Id));
			oldUser = newUser;
			return newUser;
		}

		public String DeleteUser(User user)
		{
			users.Remove(user);
			return $"Delete user(id = {user.Id}) successful.";
		}
	}
}
