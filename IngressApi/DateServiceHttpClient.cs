public interface IDateService
{
    Task<DateOnly[]> GetDatesAsync();
}

public class DateServiceHttpClient : IDateService
{
    private readonly HttpClient _httpClient;

    public DateServiceHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DateOnly[]> GetDatesAsync()
    {
        return await _httpClient.GetFromJsonAsync<DateOnly[]>("dates") ?? [];
    }
}
