using System;
using System.Collections.Generic;
using System.Linq;
using Training.Data.Models;

namespace Training.Data.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;
		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public IEnumerable<User> GetAll()
		{
			return _context.Users;
		}

		public User GetById(long id)
		{
			return _context.Users.FirstOrDefault(u => u.Id.Equals(id));
		}

		public IEnumerable<User> GetByDepartmentId(long id)
		{
			return _context.Users.Where(u => u.DepartmentId.Equals(id)).ToList();
		}

		public User CreateUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return user;
		}

		public User UpdateUser(User newUser)
		{
			var oldUser = _context.Users.FirstOrDefault(o => o.Id.Equals(newUser.Id));
			oldUser = newUser;
			_context.SaveChanges();
			return newUser;
		}

		public String DeleteUser(User user)
		{
			_context.Users.Remove(user);
			_context.SaveChanges();
			return $"Delete user(id = {user.Id}) successful.";
		}
	}
}
