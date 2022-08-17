using final_api.Models;

namespace final_api.Repositories;

public interface IAuthService
{
    User CreateUser(User user);

    // SIGN IN OPTIONS
    // POST string SignIn(SignInRequest request); (would need to create new model)
    // GET string SignIn(string email, string password);

}