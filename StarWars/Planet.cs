using System.Text.Json.Serialization;

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
