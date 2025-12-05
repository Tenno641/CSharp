namespace DesignPatterns.HighLevel;
using Key = string;

internal class FlyweightFactory
{
    private readonly Dictionary<Key, Flyweight> _flyweights = [];
    public Flyweight GetFlyweight(Key key)
    {
        if (!_flyweights.ContainsKey(key))
        {
            return new ConcreteFlyweight(intrinsicState: key);
        }
        return _flyweights[key];
    }
}
