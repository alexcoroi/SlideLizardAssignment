namespace Core;

public class PresentationRepository
{
    private static readonly List<Presentation> presentations = new();

    static PresentationRepository()
    {
        SeedData();
    }

    public IEnumerable<Presentation> GetAllPresentations()
    {
        return presentations.AsReadOnly();
    }

    public IEnumerable<Presentation> GetPresentationsBetweenDates(DateTime from, DateTime to)
    {
        return presentations.Where(p => p.FromDate <= to && p.ToDate >= from);
        
    }

    public void Add(Presentation presentation)
    {
        if (presentations.Contains(presentation))
        {
            throw new InvalidOperationException($"Presentation with the name \"{presentation.Name}\" already exists.");
        }

        presentations.Add(presentation);
    }

    private static void SeedData()
    {
        presentations.Clear();
        
        var samples = new List<Presentation>
        {
            new Presentation("Clean Code Workshop", new DateTime(2024, 06, 01, 09, 0, 0),
                new DateTime(2024, 06, 01, 17, 0, 0), "Conference Room 1"),
            new Presentation("Mastering Entity Framework", new DateTime(2024, 07, 12, 13, 0, 0),
                new DateTime(2024, 07, 12, 15, 0, 0), "Virtual Room B"),
            new Presentation("Cloud Native Architecture", new DateTime(2024, 08, 05, 10, 0, 0),
                new DateTime(2024, 08, 05, 12, 30, 0), "Innovation Hub")
        };

        foreach (var presentation in samples)
        {
            presentations.Add(presentation);
        }
    }
}