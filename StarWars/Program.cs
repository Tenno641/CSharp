using StarWars.App;
using StarWars.DataReader;
using StarWars.Reports;
using StarWars.UserCommunications;

IDataReader dataReader = new ApiDataReader("https://swapi.info/api/");
IUserCommunications userCommunications = new ConsoleUserCommunications();
IReporter reporter = new PlanetReporter();

StarWarsApp app = new StarWarsApp(dataReader, userCommunications, reporter);
await app.RunAsync();