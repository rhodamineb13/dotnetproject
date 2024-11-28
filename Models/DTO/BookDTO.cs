namespace dotnetproject.Models.DTO;

public class BookDTO {
    public int? ID { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? Qty { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class BookPagination {
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int? QtyGreaterThan { get; set; }
    public int? QtySmallerThan { get; set; }
    public DateTime? CreatedBefore { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
}