using Core;

namespace WebApp.Services;

public interface IPresentationService
{
    Task<IEnumerable<Presentation>?> GetAllPresentations();
    
    Task AddPresentation(Presentation presentation);
    
    Task<int> GetPresentationStatistics(DateTime fromDate, DateTime toDate);
}