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

    public async Task AddPresentation(Presentation presentation)
    {
        var response = await httpClient.PostAsJsonAsync("api/Presentation", presentation);
        response.EnsureSuccessStatusCode();
    }

    public async Task<int> GetPresentationStatistics(DateTime fromDate, DateTime toDate)
    {
        var url = $"api/Presentation/statistic?fromdate={fromDate:O}&todate={toDate:O}";
        return await httpClient.GetFromJsonAsync<int>(url);
    }
}