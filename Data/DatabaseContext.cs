using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.Configuration;
using dotnetproject.Models.Entities;

namespace dotnetproject.Data;

public class ApplicationContext : DbContext {
    public required DbSet<dotnetproject.Models.Entities.BookEntity> Books { get; set; }
    public required DbSet<dotnetproject.Models.Entities.UserEntity> Users { get; set; }
    public required DbSet<dotnetproject.Models.Entities.BookTransactionEntity> BookTransactions { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookEntity>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("NOW()");
        
        modelBuilder.Entity<BookEntity>()
            .Property(b => b.UpdatedAt)
            .HasDefaultValueSql("NOW()");
        
        modelBuilder.Entity<UserEntity>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<UserEntity>()
            .Property(u => u.UpdatedAt)
            .HasDefaultValueSql("NOW()");
        
        modelBuilder.Entity<BookTransactionEntity>()
            .Property(bt => bt.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<BookTransactionEntity>()
            .Property(bt => bt.UpdatedAt)
            .HasDefaultValueSql("NOW()");
    }
}