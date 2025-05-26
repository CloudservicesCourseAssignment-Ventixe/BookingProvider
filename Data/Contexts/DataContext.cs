using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; } = null!;
    public DbSet<BookingOwnerEntity> BookingOwners { get; set; } = null!;
    public DbSet<BookingAddressEntity> BookingAddresses { get; set; } = null!;
   
}
