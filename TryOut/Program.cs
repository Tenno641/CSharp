Point firstPoint = new Point(4, 6);
Point secondPoint = new Point(6, 4);
Point newPoint = firstPoint + secondPoint;

Console.WriteLine(newPoint);
Console.WriteLine(firstPoint == secondPoint);
Console.WriteLine(firstPoint != secondPoint);

Tuple<int, int> tuple = new(2, 4);
Point tuplePoint = tuple;
Console.WriteLine(tuplePoint);

readonly struct Point : IEquatable<Point>
{
    private readonly int _field;
    public int X { get; init; } // works fine
    public int Y { get; init; } // works fine
    // public int X { get; private set; } // Compilation error
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"{X}, {Y}";

    public bool Equals(Point other) => X == other.X && Y == other.Y;

    public static Point operator +(Point point1, Point point2) =>
        new Point(point1.X + point2.X, point1.Y + point2.Y);

    public static bool operator ==(Point point1, Point point2) =>
        point1.Equals(point2);

    public static bool operator !=(Point point1, Point point2) =>
        !point1.Equals(point2);

    public static implicit operator Point(Tuple<int, int> tuple) => 
        new Point(tuple.Item1, tuple.Item2);

    // public static explicit operator Point(Tuple<int, int> tuple) =>
      //  new Point(tuple.Item1, tuple.Item2);

}