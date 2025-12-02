namespace StarWars.DataReader;

public interface IDataReader
{
    Task<string> ReadAsync(string endPoint);
}
