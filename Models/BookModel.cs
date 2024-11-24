using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace dotnetproject.Models;

public class Book {

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Column("title"), NotNull]
    public string? Title { get; set; }

    [Column("author"), NotNull]
    public string? Author { get; set; }

    [Column("quantity"), NotNull]
    public int? Qty { get; set; }

    [Column("created_at"), NotNull]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at"), NotNull]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

}