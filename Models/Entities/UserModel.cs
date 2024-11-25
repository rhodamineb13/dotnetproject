using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace dotnetproject.Models.Entities;

public class UserEntity {

    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Column("name"), NotNull]
    public string? Name { get; set; }

    [Column("email"), NotNull]
    public string? Email { get; set; }

    [Column("password"), NotNull]
    public string? Password { get; set; }

    [Column("date_of_birth"), NotNull]
    public DateOnly DateOfBirth { get; set; }

    [Column("address"), NotNull]
    public string? Address { get; set; }

    [Column("created_at"), NotNull]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at"), NotNull]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at"), NotNull]
    public DateTime? DeletedAt { get; set; }
}