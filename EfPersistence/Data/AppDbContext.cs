using AnytourApi.Constants.Models.AppUsers;
using AnytourApi.Domain.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.Domain.Models.Relations;
using AnytourApi.Domain.Models.Shared;
using AnytourApi.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnytourApi.EfPersistence.Data;

public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Country> Countries { get; set; }

    public DbSet<ForSport> ForSports { get; set; }

    public DbSet<InHotel> InHotels { get; set; }

    public DbSet<City> Cities { get; set; }

    public DbSet<Hotel> Hotels { get; set; }

    public DbSet<Tour> Tours { get; set; }

    public DbSet<TransportationType> TransportationType { get; set; }

    public DbSet<BeachType> BeachTypes { get; set; }

    public DbSet<RoomType> RoomTypes { get; set; }

    public DbSet<Activity> Activities { get; set; }

    public DbSet<OrderStatus> OrderStatuses { get; set; }

    public DbSet<DietType> DietTypes { get; set; }

    public DbSet<InHotelHotel> InHotelHotels { get; set; }

    public DbSet<ForSportHotel> ForSportHotels { get; set; }

    public DbSet<BeachTypeHotel> BeachTypeHotels { get; set; }

    public DbSet<RoomTypeHotel> RoomTypeHotels { get; set; }

    public DbSet<DietTypeHotel> DietTypeHotels { get; set; }

    public DbSet<FavoriteTour> FavoriteTours { get; set; }

    public DbSet<InRoom> InRooms { get; set; }

    public DbSet<ForKid> ForKids { get; set; }

    public DbSet<ForKidHotel> ForKidHotels { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<InRoomHotel> InRoomHotels { get; set; }

    public DbSet<ProcessedOrder> ProcessedOrders { get; set; }

    public DbSet<TourActivity> TourActivities { get; set; }

    public DbSet<OrderActivity> OrderActivities { get; set; }


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

        //Reviewable
        modelBuilder.Entity<Reviewable>().UseTptMappingStrategy();

        //ReviewablePhotoable
        modelBuilder.Entity<ReviewablePhotoable>().UseTptMappingStrategy();

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

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.RoomTypes)
            .WithMany(e => e.Hotels)
            .UsingEntity<RoomTypeHotel>();
        
        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.ForKids)
            .WithMany(e => e.Hotels)
            .UsingEntity<ForKidHotel>();

        modelBuilder.Entity<Hotel>()
            .HasMany(e => e.InRooms)
            .WithMany(e => e.Hotels)
            .UsingEntity<InRoomHotel>();

        // Tour
        modelBuilder.Entity<Tour>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Tours)
            .UsingEntity<FavoriteTour>();

        modelBuilder.Entity<Tour>()
            .HasMany(e => e.Activities)
            .WithMany(e => e.Tours)
            .UsingEntity<TourActivity>();

        //Order

        modelBuilder.Entity<Order>()
            .HasMany(e => e.Activities)
            .WithMany(e => e.Orders)
            .UsingEntity<OrderActivity>();
      

    }
}