using NUnit.Framework;
using Utilities;

namespace UtilitiesTests;

[TestFixture]
internal class FibonacciTests
{
    [Test]
    public void Generate_ThrowsArgumentException_IfInputSmallerThanZero()
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(-1));
    }

    [Test]
    public void Generate_ThrowsArgumentException_IfInputExceeded46()
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(47));
    }

    [Test]
    public void Generate_ReturnValidSequenceOfFiveNumbers_IfInputIsFive()
    {
        // Arrange
        IEnumerable<int> expected = [0, 1, 1, 2, 3];

        // Act 
        IEnumerable<int> result = Fibonacci.Generate(5);

        // Assert
        Assert.AreEqual(result, expected);
    }

}
