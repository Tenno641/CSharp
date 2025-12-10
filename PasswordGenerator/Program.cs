IRandomizable<int> randomizable = new RandomNumber();
PasswordGenerator passwordGenerator = new PasswordGenerator(randomizable);
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(passwordGenerator.Generate(5, 10, PasswordGeneratorOption.Special));
}
Console.ReadKey();

public enum PasswordGeneratorOption
{
    None, 
    Special
}

public class PasswordGenerator
{
    private readonly IRandomizable<int> _random;

    public PasswordGenerator(IRandomizable<int> randomizable)
    {
        _random = randomizable;
    }

    public string Generate(
        int minimumRange,
        int maximumRange,
        PasswordGeneratorOption options)
    {
        if (minimumRange < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be greater than 0");
        }
        if (maximumRange < minimumRange)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be smaller than rightRange");
        }

        var length = _random.Generate(minimumRange, maximumRange + 1);

        var chars = options == PasswordGeneratorOption.Special ?
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=" :
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(
            Enumerable.Repeat(chars, length).
            Select(chars => chars[_random.Generate(chars.Length)])
            .ToArray());
    }
}

public class RandomNumber : IRandomizable<int>
{
    public int Generate(int minimum, int maximum)
    {
        return new Random().Next(minimum, maximum);
    }
    public int Generate(int maximum)
    {
        return new Random().Next(maximum);
    }
}
public interface IRandomizable<T>
{
    T Generate(int minimum, int maximum);
    T Generate(int maximum);
}
