public interface IWeatherSummaryService
{
    Task<string[]> GetWeatherSummariesAsync();
}

public class WeatherSummaryHttpClient : IWeatherSummaryService
{
    private readonly HttpClient _httpClient;

    public WeatherSummaryHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string[]> GetWeatherSummariesAsync()
    {
        return await _httpClient.GetFromJsonAsync<string[]>("summaries") ?? [];
    }
}
