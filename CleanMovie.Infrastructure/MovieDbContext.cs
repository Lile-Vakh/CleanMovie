using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .HasOne<Rental>(s => s.Rental)
            .WithMany(s => s.Members)
            .HasForeignKey(s => s.RentalId);

        modelBuilder.Entity<MovieRental>()
            .HasKey(g => new { g.RentalId, g.MovieId });
        
        modelBuilder.Entity<Rental>()
            .Property( p => p.TotalCost)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<Movie>()
            .Property( p => p.RentalCost)
            .HasColumnType("decimal(18,2)");
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<MovieRental> MovieRentals { get; set; }
}