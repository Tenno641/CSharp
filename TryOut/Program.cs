readonly struct Point
{
    private readonly int _field;
    public int X { get; } // works fine
    public int Y { get; init; } // works fine
    // public int X { get; private set; } // Compilation error
}