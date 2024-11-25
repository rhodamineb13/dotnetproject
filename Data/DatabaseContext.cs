using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;

namespace dotnetproject.Data;

public class ApplicationContext : DbContext {
    public DbSet<dotnetproject.Models.Entities.BookEntity>? Books { get; set; }
    public DbSet<dotnetproject.Models.Entities.UserEntity>? Users { get; set; }
    public DbSet<dotnetproject.Models.Entities.BookTransactionEntity>? BookTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
        
        optionsBuilder.UseNpgsql(config.GetConnectionString("AppContext"));
    }

}