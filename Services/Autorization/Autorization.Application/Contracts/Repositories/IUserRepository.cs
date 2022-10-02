using Authorization.Domain.DbModels;
using CommonRepository.Interfaces;

namespace Authorization.Infrastructure.Abstractions;

public interface IUserRepository : IBaseRepository<User>
{
}
