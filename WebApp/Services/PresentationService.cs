using Core;

namespace WebApp.Services;

public class PresentationService : IPresentationService
{
    private readonly HttpClient httpClient;
    
    public PresentationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    
    public async Task<IEnumerable<Presentation>?> GetAllPresentations()
    {
        var response = await httpClient.GetAsync("api/Presentation");
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Presentation>>();
    }
}