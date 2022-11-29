using Domain.User.Extensions;
using Exceptions;

namespace Domain.User;

// TODO: Переименовать класс правильнее
public class UserAuthorize : UserIdentity
{
    public string Login { get; private set; }
    private string _password;

    protected UserAuthorize(int id, string login, string password) : base(id)
    {
        Login = login;
        _password = password;
    }

    public static UserAuthorize Create(int id, string login, string password)
    {
        VerifyLogin(login);
        VerifyPassword(password);
        return new UserAuthorize(id, login, password.HashString());
    }

    public bool CheckPassword(string password)
    {
        return _password.CompareHashedString(password);
    }

    public void ChangeLogin(string newLogin)
    {
        VerifyLogin(newLogin);
        Login = newLogin;
    }

    public void ChangePassword(string newPassword)
    {
        VerifyPassword(newPassword);
        _password = newPassword.HashString();
    }

    private static void VerifyPassword(string password)
    {
        if (password.Length < 3) throw new DataValidationException(nameof(password), "String length can't be less then 3 characters.");
        if (password.Length > 50) throw new DataValidationException(nameof(password), "String length can't be longer then 50 characters.");
    }

    private static void VerifyLogin(string login)
    {
        if (login.Length < 3) throw new DataValidationException(nameof(login), "String length can't be less then 3 characters.");
        if (login.Length > 50) throw new DataValidationException(nameof(login), "String length can't be longer then 50 characters.");
    }
}
