using NUnit.Framework;
using System.Collections;
using Utilities;

namespace UtilitiesTests;

[TestFixture]
public class EnumerableExtensionTests
{
    [Test]
    public void SumOfEvenNumbers_ShallReturnZero_ForEmptyCollections()
    {
        var input = Enumerable.Empty<int>();
        
        var result = input.SumOfEvenNumbers();

        Assert.AreEqual(0, result);
    }
    [TestCaseSource(nameof(GetCollectionOfPositiveNumbers))]
    public void SumOfEvenNumbers_ShallReturnNonZero_ForEvenNumbersArePresent(IEnumerable<int> input, int expected)
    {
        // Act
        var result = input.SumOfEvenNumbers();
        // Assert
        Assert.AreEqual(expected, result, $"For input {string.Join(",", input)}, expected {expected} as even numbers are present");
    }
    [TestCase(5, 0)]
    [TestCase(8, 8)]
    [TestCase(4, 4)]
    public void SumOfEvenNumbers_ShallReturnValueOfTheOnlyItem_ForCollectionWithSingleItem(int testCase, int expected)
    {
        // Arrange
        var input = new int[] { testCase };

        // Act
        var result = input.SumOfEvenNumbers();

        // Assert
        Assert.AreEqual(expected, result);
    }
    public void SumOfEvenNumbers_ShallThrowsNullReferenceException_ForNullCollection()
    {
        // Arrange
        int[]? input = null;

        // Assert
        Assert.Throws<NullReferenceException>(() => input!.SumOfEvenNumbers());

    }
    [Test]
    public void GetNumberOne_ShallReturnOne()
    {
        // Act
        int result = EnumerableExtensions.GetNumberOne();

        // Assert
        Assert.AreEqual(1, result);
    }
    public static IEnumerable GetCollectionOfPositiveNumbers()
    {
        return new object[]
        {
            new object[] { new int[] { 1, 4, 5 }, 4},
            new object[] { new List<int> { 2, 4, 6 }, 12 },
            new object[] { new int[] { -2, -4 }, -6 }
        };
    }
}
