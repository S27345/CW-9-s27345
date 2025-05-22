using Microsoft.EntityFrameworkCore;

namespace WebApplication.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}