using CommonRepository.Models;

namespace Authorization.Domain.DbModels;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public User() : base() 
    {
        Name = "";
        Surname = "";
        Login = "";
        Password = "";
    }

    public User(string creatorName) : base(creatorName) 
    {
        Name = "";
        Surname = "";
        Login = "";
        Password = "";
    }

}
