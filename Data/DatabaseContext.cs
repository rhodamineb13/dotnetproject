using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;

namespace dotnetproject.Data;

public class AppContext : DbContext {
    public DbSet<dotnetproject.Models.Entities.Book>? Books { get; set; }
    public DbSet<dotnetproject.Models.Entities.User>? Users { get; set; }
    public DbSet<dotnetproject.Models.Entities.BookTransaction>? BookTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
        
        optionsBuilder.UseNpgsql(config.GetConnectionString("AppContext"));
    }

    
}