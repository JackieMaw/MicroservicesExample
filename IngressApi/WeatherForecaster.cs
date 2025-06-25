namespace IngressApi;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public interface IWeatherForecaster
{
    Task<WeatherForecast[]> GetForecastAsync(IWeatherSummaryService weatherSummaryService, IDateService dateService);
}

public class WeatherForecaster : IWeatherForecaster
{
    public async Task<WeatherForecast[]> GetForecastAsync(IWeatherSummaryService weatherSummaryService, IDateService dateService)
    {
        string[] summaries = await weatherSummaryService.GetWeatherSummariesAsync();
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
