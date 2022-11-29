namespace Domain.User;

public class UserIdentity
{
    protected readonly int _id;

    public int Id { get => _id; }

    protected UserIdentity(int id) 
    {
        _id = id;
    }

    public sealed override bool Equals(object? obj)
    {
        if (obj is UserIdentity user)
        {
            return _id == user.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
