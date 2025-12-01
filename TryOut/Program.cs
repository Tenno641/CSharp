using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient httpClient = new();
httpClient.BaseAddress = new Uri("http://localhost:5290/");
HttpResponseMessage response = await httpClient.GetAsync("weatherforecast");
string content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);

IEnumerable<Weather>? weathers = JsonSerializer.Deserialize<IEnumerable<Weather>>(content);
if (weathers is null) return;
foreach(Weather weather in weathers)
{
    Console.WriteLine(weather);
}    
readonly record struct Weather 
{
    [JsonPropertyName("date")]
    public DateOnly Date { get; init; }
    [JsonPropertyName("temperatureC")]
    public int TemperatureC { get; init; }
    [JsonPropertyName("summary")] public string Summary { get; init; }
    [JsonPropertyName("temperatureF")] public int TemperatureF { get; init; }
}