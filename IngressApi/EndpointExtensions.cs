namespace IngressApi;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        RouteGroupBuilder group = app.MapGroup("/weatherforecast");

        group.MapGet("/", (IWeatherForecaster weatherForecaster) => weatherForecaster.GetForecastAsync)
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }
}