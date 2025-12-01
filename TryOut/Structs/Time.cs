/*
Point firstPoint = new Point(4, 6);
Point secondPoint = new Point(6, 4);
Point newPoint = firstPoint + secondPoint;

Console.WriteLine(newPoint);
Console.WriteLine(firstPoint == secondPoint);
Console.WriteLine(firstPoint != secondPoint);

Tuple<int, int> tuple = new(2, 4);
Point tuplePoint = tuple;
Console.WriteLine(tuplePoint);

Time time1 = new Time(11, 15);
Time time2 = new Time(15, 10);
Time newTime = time1 + time2;
Console.WriteLine(newTime);
*/
public struct Time
{
    public int Hour { get; }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(
                "Hour is out of range of 0-23");
        }
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(
                "Minute is out of range of 0-59");
        }
        Hour = hour;
        Minute = minute;
    }

    public override string ToString() =>
        $"{Hour.ToString("00")}:{Minute.ToString("00")}";

    public static bool operator ==(Time time1, Time time2) =>
        time1.Hour.Equals(time2.Hour) && time1.Minute.Equals(time2.Minute);

    public static bool operator !=(Time time1, Time time2) =>
        time1.Hour.Equals(time2.Hour) && time1.Minute.Equals(time2.Minute);

    public static Time operator +(Time time1, Time time2)
    {
        int minutes = time1.Minute + time2.Minute;
        int hours = time1.Hour + time2.Hour;

        if (minutes > 59)
        {
            minutes -= 60;
            ++hours;
        }
        return new Time(hours % 24, minutes);
    }
}