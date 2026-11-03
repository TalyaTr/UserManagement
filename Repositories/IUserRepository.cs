using UserManagement.Models;

namespace UserManagement.Repositories
{
    public interface IUserRepository
    {
        User Create(User user);
        bool Delete(int userId);
        User Validate(string username, string password);
    }
}
