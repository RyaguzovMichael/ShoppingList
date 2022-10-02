using Authorization.Domain.DbModels;
using Authorization.Infrastructure.Context.Maps;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Infrastructure.Context;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserDbMap());
    }
}
