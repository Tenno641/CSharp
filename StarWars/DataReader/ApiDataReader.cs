namespace StarWars.DataReader;

public class ApiDataReader : IDataReader
{
    private string _baseAddress;

    public ApiDataReader(string baseAddress)
    {
        _baseAddress = baseAddress;
    }

    public async Task<string> ReadAsync(string endPoint)
    {
        using HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://swapi.info/api/");
        return await httpClient.GetStringAsync(endPoint);
    }
}
