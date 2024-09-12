using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AnytourApi.Domain.Models;
using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Infrastructure.Extensions;

namespace AnytourApi.EfPersistence.Data;

public class AppDbContext
    : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{

    public DbSet<Country> Countries { get; set; }

    public DbSet<ForSport> ForSports { get; set; }

    public DbSet<ForSportHotel> ForSportHotels { get; set; }

    public DbSet<InHotel> InHotels { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Hotel> Hotels { get; set; }

    public DbSet<InHotelHotel> InHotelHotels { get; set; }
    
    public DbSet<TransportationType> TransportationType { get; set; }

    public DbSet<BeachType> BeachTypes { get; set; }

    public DbSet<BeachTypeHotel> BeachTypeHotels { get; set; }

    public DbSet<RoomType> RoomTypes { get; set; }

    public DbSet<Activity> Activities { get; set; }


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

        // Relations
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(e => e.ClrType.GenericIsSubclassOf(typeof(RelationModel<,>))))
        {
            var relationType = entityType.ClrType.GetSubclassType(typeof(RelationModel<,>))!;
            var firstType = relationType.GetGenericArguments()[0];
            var secondType = relationType.GetGenericArguments()[1];

            var firstName = firstType.Name;
            var secondName = firstType == secondType ? $"Second{secondType.Name}" : secondType.Name;

            var firstIdName = $"{firstName}Id";
            var secondIdName = $"{secondName}Id";

            modelBuilder.Entity(entityType.ClrType).Property("FirstId").HasColumnName(firstIdName);
            modelBuilder.Entity(entityType.ClrType).Property("SecondId").HasColumnName(secondIdName);
        }

        //Photoable
        modelBuilder.Entity<Photoable>().UseTptMappingStrategy();

        //User
        modelBuilder.Entity<User>()
            .HasMany(e => e.Roles)
            .WithMany()
            .UsingEntity<IdentityUserRole<Guid>>();


        //Hotels
        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.InHotels)
            .WithMany(e => e.Hotels)
            .UsingEntity<InHotelHotel>();

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.ForSports)
            .WithMany(e => e.Hotels)
            .UsingEntity<ForSportHotel>();

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.BeachTypes)
            .WithMany(e => e.Hotels)
            .UsingEntity<BeachTypeHotel>();






    }
}