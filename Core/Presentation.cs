namespace Core;

public record class Presentation
{
    public required string Name { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public required string Location { get; set; }
}