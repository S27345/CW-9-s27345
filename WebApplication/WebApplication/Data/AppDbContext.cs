using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data;

public class AppDbContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}