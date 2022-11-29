using Exceptions;

namespace Domain.User;

public class User : UserIdentity
{
    public string Name { get; protected set; }
    public string Surname { get; protected set; }

    protected User(int id, string name, string surname) : base(id)
    {
        Name = name;
        Surname = surname;
    }

    public void SetUserNameAndSurname(string name, string surname)
    {
        VerifyName(name);
        VerifySurname(surname);
        Name = name;
        Surname = surname;
    }

    private static void VerifyName(string name)
    {
        if (name.Length < 3) throw new DataValidationException(nameof(name), "String length can't be less then 3 characters.");
        if (name.Length > 50) throw new DataValidationException(nameof(name), "String length can't be longer then 50 characters.");
    }

    private static void VerifySurname(string surname)
    {
        if (surname.Length < 3) throw new DataValidationException(nameof(surname), "String length can't be less then 3 characters.");
        if (surname.Length > 50) throw new DataValidationException(nameof(surname), "String length can't be longer then 50 characters.");
    }
}
