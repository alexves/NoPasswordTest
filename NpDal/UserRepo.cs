using System;
using System.Linq;

namespace NpDal
{
	public class UserRepo : IDisposable
	{
		private readonly NpContext _context;

		public UserRepo()
		{
			_context = new NpContext();
		}

		public void AddOrUpdateUser(User user)
		{
			var dbUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

			if (dbUser == null)
			{
				_context.Users.Add(user);
			}
			else
			{
				dbUser.Key = user.Key;
				dbUser.PasswordHash = user.PasswordHash;
				dbUser.Vector = user.Vector;
			}
		    _context.SaveChanges();
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}
	}
}
