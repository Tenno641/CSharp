namespace Utilities;

public class Repository : IRepository
{
    private List<Person> _person = [];

    public void Add(int id, string name, int age)
    {
        var person = new Person() { Id = id, Name = name, Age = age };
        _person.Add(person);
    }

    public Person Get(int id)
    {
        return _person.First(person => person.Id.Equals(id));
    }
}

public record Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
}
