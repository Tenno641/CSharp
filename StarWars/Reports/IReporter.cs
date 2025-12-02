namespace StarWars.Reports;

public interface IReporter
{
    string[] GetStatistics(string requiredProperty, IEnumerable<PlanetDto> planets, Func<PlanetDto, double> selector);
}
