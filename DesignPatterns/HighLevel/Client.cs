namespace DesignPatterns.HighLevel;

internal class Client
{
    private readonly FlyweightFactory _factory;
    internal Client(FlyweightFactory factory)
    {
        _factory = factory;
    }
    public void operation(string extrinsicState)
    {
        string key1 = extrinsicState[0].ToString();
        string key2 = extrinsicState[0].ToString();

        Flyweight flyweight1 = _factory.GetFlyweight(key1);
        Flyweight flyweight2 = _factory.GetFlyweight(key2);

        flyweight1.Operation(extrinsicState);
        flyweight2.Operation(extrinsicState);
    }
}
