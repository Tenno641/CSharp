using TryOut.Attributes;

StringLengthValidator validator = new();
Person invalidPerson = new Person() { Name = "2" };
Person validPerson = new Person() { Name = "Defined-Name" };

Console.WriteLine(validator.Validate(invalidPerson) ? "Valid Object" : "Invalid Object");
Console.WriteLine(validator.Validate(validPerson) ? "Valid Object" : "Invalid Object");

public class Person
{
    [AttributesMetadata.StringLengthAttribute(2, 50)]
    public required string Name { get; set; }
}