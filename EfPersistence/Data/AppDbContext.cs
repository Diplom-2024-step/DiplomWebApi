using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Constants.Models.AppUsers;

namespace EfPersistence.Data;

public class AppDbContext
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<User> AppUsers { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole<Guid>>().HasData(
           new IdentityRole<Guid>
           {
               Id = Guid.Parse("2ae998d7-d8b1-4616-a0b3-60d29eca6c90"),
               Name = UserStringConstants.AdminRole,
               NormalizedName = UserStringConstants.AdminRole.ToUpper()
           },
           new IdentityRole<Guid>
           {
               Id = Guid.Parse("b1e76313-b130-44f8-ae76-6aff097064aa"),
               Name = UserStringConstants.UserRole,
               NormalizedName = UserStringConstants.UserRole.ToUpper()
           }
       );

    }
}