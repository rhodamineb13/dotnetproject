using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace dotnetproject.Models.Entities;

public class BookEntity {

    [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    [Column("title"), NotNull]
    public string? Title { get; set; }

    [Column("author"), NotNull]
    public string? Author { get; set; }

    [Column("quantity"), NotNull]
    public int? Qty { get; set; }

    [Column("created_at"), NotNull, DefaultValue("NOW()")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at"), NotNull, DefaultValue("NOW()")]
    public DateTime? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTime? DeletedAt { get; set; }

}

public class BookPaginationEntity {
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? QtyGreaterThan { get; set; }
    public int? QtySmallerThan { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}