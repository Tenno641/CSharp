namespace StarWars.Reports;

internal class PlanetReporter : IReporter
{
    public string[] GetStatistics(string requiredProperty, IEnumerable<PlanetDto> planets, Func<PlanetDto, double> selector)
    {
        string[] results = new string[2];
        IEnumerable<PlanetDto> validPlanets = planets.Where(planet =>
        {
            double value = selector(planet);
            return value > 0;
        });
        if (!validPlanets.Any()) throw new InvalidOperationException("[List] Planets is empty");

        PlanetDto? max = validPlanets.MaxBy(planet => selector(planet));
        PlanetDto? min = validPlanets.MinBy(planet => selector(planet));
        if (max is null || min is null) throw new ArgumentNullException("[List] Planets is null | can't find values to fit the criteria");

        results[0] = $"Max {requiredProperty} is {selector(max)} (planet:{max.Name})";
        results[1] = $"Min {requiredProperty} is {selector(min)} (planet:{min.Name})";
        return results;
    }
}
