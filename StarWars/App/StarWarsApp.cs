using StarWars.DataReader;
using StarWars.Reports;
using StarWars.UserCommunications;
using System.Text.Json;

namespace StarWars.App;

public class StarWarsApp
{
    private readonly IDataReader _dataReader;
    private readonly IUserCommunications _userCommunication;
    private readonly IReporter _reporter;
    public StarWarsApp(IDataReader dataReader, IUserCommunications userCommunication, IReporter reporter)
    {
        _dataReader = dataReader;
        _userCommunication = userCommunication;
        _reporter = reporter;
    }
    public async Task RunAsync()
    {
        string response = await _dataReader.ReadAsync("planets");
        List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(response);

        if (planets is not null)
        {
            IEnumerable<PlanetDto> planetDtos = planets.Select(planet => (PlanetDto)planet);
            _userCommunication.PrintPlanets(planetDtos);

            _userCommunication.PrintStatisticsOptions();
            string? userInput = Console.ReadLine();
            if (userInput is not null)
            {
                string[] results = [];
                switch (userInput)
                {
                    case "population":
                        results = _reporter.GetStatistics("Population", planetDtos, planet => planet.Population);
                        break;
                    case "diameter":
                        results = _reporter.GetStatistics("Diameter", planetDtos, planet => planet.Diameter);
                        break;
                    case "surface-water":
                        results = _reporter.GetStatistics("SurfaceWater", planetDtos, planet => planet.SurfaceWater);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine(string.Join("\n", results));
            }
        }
    }
}
