using Authorization.Domain.DbModels;
using Authorization.Infrastructure.Abstractions;
using Authorization.Infrastructure.Context;
using CommonRepository;

namespace Authorization.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User, UserDbContext>, IUserRepository
{
    public UserRepository(UserDbContext dbContext) : base(dbContext) { }
}
