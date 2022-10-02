using Authorization.Domain.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authorization.Infrastructure.Context.Maps;

internal class UserDbMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).HasColumnType("VARCHAR(36)").IsRequired();
        builder.Property(p => p.CreatedBy).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnType("TIMESTAMP").IsRequired();
        builder.Property(p => p.LastModifiedBy).HasColumnType("VARCHAR(30)");
        builder.Property(p => p.LastModifiedDate).HasColumnType("TIMESTAMP").IsRequired();
        builder.HasIndex(p => p.Login);
        builder.Property(p => p.Login).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Password).HasColumnType("VARCHAR(30)").IsRequired();
        builder.Property(p => p.Name).HasColumnType("VARCHAR(50)").IsRequired();
        builder.Property(p => p.Surname).HasColumnType("VARCHAR(50)").IsRequired();
    }
}
