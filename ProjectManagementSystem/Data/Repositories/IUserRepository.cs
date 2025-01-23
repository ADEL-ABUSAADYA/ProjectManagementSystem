using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<(int, bool)> LogInUser(string email, string password);
    }
}
