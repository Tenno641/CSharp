namespace StarWars.UserCommunications;

public interface IUserCommunications
{
    void PrintMessage(string message);
    void PrintPlanets(IEnumerable<PlanetDto> planets);
    void PrintStatisticsOptions();
}