using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace dotnetproject.Models.Entities;

public class BookTransaction {
    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Column("user_id"), NotNull]
    public int? UserId { get; set; }
    public User? User { get; set; }

    [Column("book_id"), NotNull]
    public int? BookId { get; set; }
    public Book? Book { get; set; }

    [Column("borrowed_at"), NotNull]
    public DateTime? BorrowedAt { get; set; }

    [Column("status"), NotNull]
    public string? Status { get; set; }

    [Column("returned_at"), NotNull]
    public DateTime? ReturnedAt { get; set; }

    [Column("created_at"), NotNull]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at"), NotNull]
    public DateTime? UpdatedAt { get; set; }
    
    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }
}