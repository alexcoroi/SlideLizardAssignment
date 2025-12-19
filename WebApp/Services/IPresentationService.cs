using Core;

namespace WebApp.Services;

public interface IPresentationService
{
    Task<IEnumerable<Presentation>?> GetAllPresentations();
}