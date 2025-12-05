namespace DesignPatterns.HighLevel;

internal class ConcreteFlyweight : Flyweight
{
    private readonly string _intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        _intrinsicState = intrinsicState;
    }
    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Concrete Flyweight: intrinsic : {_intrinsicState}. extrinsic {extrinsicState}");
    }
}
