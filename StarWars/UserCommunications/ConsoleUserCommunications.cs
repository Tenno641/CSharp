namespace StarWars.UserCommunications;

public class ConsoleUserCommunications : IUserCommunications
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void PrintPlanets(IEnumerable<PlanetDto> planets)
    {
        foreach (PlanetDto planet in planets)
        {
            Console.WriteLine(planet);
        }
    }

    public void PrintStatisticsOptions()
    {
        PrintMessage(@"The statistics of which property would you like to see?
population
diameter
surface-water
");
    }
}
