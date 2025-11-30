namespace TryOut.Attributes;

internal class AttributesMetadata
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : Attribute
    {
        public int Min { get; }
        public int Max { get; }
        public StringLengthAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}

public class Person
{
    [AttributesMetadata.StringLengthAttribute(2, 50)]
    public required string Name { get; set; }
}
