using System.Reflection;

namespace TryOut.Attributes;

internal class StringLengthValidator
{
    public bool Validate(object obj)
    {
        Type type = obj.GetType();
        IEnumerable<PropertyInfo> properties = type.GetProperties()
            .Where(property => Attribute.IsDefined(property, typeof(AttributesMetadata.StringLengthAttribute)));

        foreach(PropertyInfo property in properties)
        {
            object? propertyValue = property.GetValue(obj);
            if (propertyValue is not string) throw new InvalidOperationException();
            AttributesMetadata.StringLengthAttribute? attribute = property.GetCustomAttribute<AttributesMetadata.StringLengthAttribute>();
            string value = (string)propertyValue;
            if (value.Length > attribute.Min && value.Length < attribute.Max) return true;
        }
        return false;
    }
}
