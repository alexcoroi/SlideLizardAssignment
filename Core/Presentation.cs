using System.ComponentModel.DataAnnotations;

namespace Core;

public record class Presentation
{
    [Required] public string Name { get; set; }
    [Required] public DateTime FromDate { get; set; }
    [Required] public DateTime ToDate { get; set; }
    [Required] public string Location { get; set; }

    public Presentation(string name, DateTime fromDate, DateTime toDate, string location)
    {
        Name = name;
        FromDate = fromDate;
        ToDate = toDate;
        Location = location;
    }

    public virtual bool Equals(Presentation? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
    }
}