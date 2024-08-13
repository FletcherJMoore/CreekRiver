using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "Wilderness Whispers", ImageUrl="https://www.familyparks.com.au/wp-content/uploads/2021/12/shutterstock_462419059-scaled.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 3, Nickname = "Adventure Haven", ImageUrl="https://www.rontar.com/blog/wp-content/uploads/2024/05/campsite-name-ideas.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 4, Nickname = "Enchanted Forest Retreat", ImageUrl="https://australia.businessesforsale.com/australian/static/articleimage?articleId=12982&name=run-campsite"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, Email = "me@example.com", FirstName = "John", LastName = "Doe"}
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 2, CheckinDate = new DateTime(2024, 07, 17), CheckoutDate = new DateTime(2024, 07, 24), UserProfileId = 1}
        });
    }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
}



