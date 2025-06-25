namespace IngressApi;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetForecastAsync(IWeatherDescriptionService weatherSummaryService, IDateService dateService);
}

public class WeatherForecastService : IWeatherForecastService
{
    public async Task<WeatherForecast[]> GetForecastAsync(IWeatherDescriptionService weatherDescriptionService, IDateService dateService)
    {
        string[] summaries = await weatherDescriptionService.GetWeatherDescriptionsAsync();
        DateOnly[] dates = await dateService.GetDatesAsync();
        return dates.Select(date =>
            new WeatherForecast
            (
                date,
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
    }
}
