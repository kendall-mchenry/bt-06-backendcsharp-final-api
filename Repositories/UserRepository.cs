using final_api.Migrations;
using final_api.Models;

namespace final_api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PostsDbContext _context;

    public UserRepository(PostsDbContext context)
    {
        _context = context;
    }

    // PUT / edit user by 
    public User? EditUser(User editUser)
    {
        var originalUser = _context.Users.Find(editUser.UserId);

        if (originalUser != null) {
            originalUser.Username = editUser.Username;
            // Do we want users to be able to edit their password?
            originalUser.Password = editUser.Password;
            originalUser.FirstName = editUser.FirstName;
            originalUser.LastName = editUser.LastName;
            originalUser.State = editUser.State;
            originalUser.PhotoUrl = editUser.PhotoUrl;
            _context.SaveChanges();
        }

        return originalUser;
    }

    // GET / ALL users
    public IEnumerable<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    // GET / one user by user id
    public User? GetUserById(int userId)
    {
        return _context.Users.SingleOrDefault(u => u.UserId == userId);
    }
}