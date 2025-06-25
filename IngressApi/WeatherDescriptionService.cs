public interface IWeatherDescriptionService
{
    Task<string[]> GetWeatherDescriptionsAsync();
}

public class WeatherDescriptionHttpClient : IWeatherDescriptionService
{
    private readonly HttpClient _httpClient;

    public WeatherDescriptionHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string[]> GetWeatherDescriptionsAsync()
    {
        return await _httpClient.GetFromJsonAsync<string[]>("weatherdescriptions") ?? [];
    }
}
