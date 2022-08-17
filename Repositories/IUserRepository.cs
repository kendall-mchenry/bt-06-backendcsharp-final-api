using final_api.Models;

namespace final_api.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();

    User? GetUserById(int userId);

    User? EditUser(User editUser);

    // Add anything here about getting the posts for a user?
}