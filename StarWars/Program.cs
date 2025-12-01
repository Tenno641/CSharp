using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using HttpClient httpClient = new HttpClient();
httpClient.BaseAddress = new Uri("https://swapi.info/api/");
string response = await httpClient.GetStringAsync("planets");

List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(response);
IEnumerable<PlanetDto> planetDtos = [];
if (planets is not null)
{
    planetDtos = planets.Select(planet => (PlanetDto)planet);
}

Console.WriteLine(@"The statistics of which property would you like to see?
population
diameter
surface water
");
string? userInput = Console.ReadLine();
if (userInput is not null)
{
    PlanetStatistics(userInput, planetDtos);
}
void PlanetStatistics(string requiredProperty, IEnumerable<PlanetDto> planets)
{
    Type planetType = typeof(PlanetDto);
    PropertyInfo? propertyInfo = planetType.GetProperty(requiredProperty);
    if (propertyInfo is null) return;
    PlanetDto? maximumValue = planets.MaxBy(propertyInfo.GetValue);
    PlanetDto? minimumValue = planets.Where(planet =>
    {
        object? value = propertyInfo.GetValue(planet);
        if (value is null) return false;

        double numericValue = Convert.ToDouble(value);
        return numericValue > 0;
    }).MinBy(propertyInfo.GetValue);
    if (maximumValue is null || minimumValue is null) return;
    Console.WriteLine($"Max {propertyInfo.Name} is {propertyInfo.GetValue(maximumValue)} (planet:{maximumValue.Name})");
    Console.WriteLine($"Max {propertyInfo.Name} is {propertyInfo.GetValue(minimumValue)} (planet:{minimumValue.Name})");
}

public readonly record struct Planet(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("diameter")] string Diameter,
    [property: JsonPropertyName("surface_water")] string SurfaceWater,
    [property: JsonPropertyName("population")] string Population
)
{
    public static implicit operator PlanetDto(Planet planet) 
    {
        int.TryParse(planet.Diameter, out int diameter);
        double.TryParse(planet.SurfaceWater, out double surfaceWater);
        long.TryParse(planet.Population, out long population);
        return new PlanetDto(
           Name: planet.Name,
           Diameter: diameter,
           SurfaceWater: surfaceWater,
           Population: population
            );
    }
};

public record PlanetDto(string Name, int Diameter, double SurfaceWater, long Population);
