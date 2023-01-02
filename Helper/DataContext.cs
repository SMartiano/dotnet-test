namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
// using WebApi.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        String hostname = Environment.GetEnvironmentVariable("DB_HOST");

        // connect to sql server with connection string from app settings
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase").Replace("$DB_HOST", hostname));
    }

    // public DbSet<User> Users { get; set; }
}