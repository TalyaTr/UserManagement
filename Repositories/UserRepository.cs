using UserManagement.Data;
using UserManagement.Models;

namespace UserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                // Log the error (you can plug in ILogger later)
                throw new Exception("Failed to create user", ex);
            }
        }

        public bool Delete(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user == null)
                    return false;

                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete user", ex);
            }
        }

        public User Validate(string username, string password)
        {
            try
            {
                return _context.Users
                    .FirstOrDefault(u => u.UserName == username &&
                                         u.UserPassword == password);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to validate user", ex);
            }
        }
    }
}
