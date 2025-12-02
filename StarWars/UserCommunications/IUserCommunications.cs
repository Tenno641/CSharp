namespace StarWars.UserCommunications;

public interface IUserCommunications
{
    void PrintMessage(string message);
    void PrintAsTable<T>(IEnumerable<T> data) where T: class;
    void PrintStatisticsOptions();
}