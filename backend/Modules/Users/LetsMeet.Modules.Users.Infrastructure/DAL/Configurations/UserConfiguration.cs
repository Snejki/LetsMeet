using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Shared.Abstractions.Kernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LetsMeet.Modules.Users.Infrastructure.DAL.Configurations;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Id, x => UserId.Create(x));

        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => Email.Create(x))
            .IsRequired();
        
        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => FirstName.Create(x))
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => LastName.Create(x))
            .IsRequired();
        
        builder.Property(x => x.HashedPassword)
            .HasConversion(x => x.Value, x => HashedPassword.Create(x))
            .IsRequired();
    }
}