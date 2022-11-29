namespace Domain.User.Contracts;

public interface IUserDbService
{
    Task<bool> IsLoginUnicueAsync(string login);
    Task<int> GetNextIdAsync();
    Task<User> GetUserByIdAsync(int id);
    Task<UserAuthorize> GetUserByLoginAsync(string login);
}
