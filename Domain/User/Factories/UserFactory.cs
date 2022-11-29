using Domain.User.Contracts;
using Exceptions;

namespace Domain.User.Factories;

public class UserFactory
{
    private readonly IUserDbService _userDbService;

    public UserFactory(IUserDbService userDbService)
    {
        _userDbService = userDbService;
    }

    public async Task<UserAuthorize> CreateAsync(string login, string password)
    {
        if (await _userDbService.IsLoginUnicueAsync(login))
        {
            throw new DataValidationException(nameof(login), "Login is not unicue");
        }
        int id = await _userDbService.GetNextIdAsync();
        return UserAuthorize.Create(id, login, password);
    }

    public async Task<UserAuthorize> GetUserAuthorizeAsync(string login)
    {
        if (await _userDbService.GetUserByLoginAsync(login) is UserAuthorize user)
        {
            return user;
        }
        throw new InvalidDataException("Db send invalid data object");
    }

    public async Task<User> GetUserDataAsync(UserIdentity identity)
    {
        if (await _userDbService.GetUserByIdAsync(identity!.Id) is User user)
        {
            return user;
        }
        throw new InvalidDataException("Db send invalid data object");
    }
}
