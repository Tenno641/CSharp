Person person1 = new Person("User-Defined", 22);
Person person2 = new Person("User-Defined", 22);
Console.WriteLine(person1.Equals(person2));
Console.WriteLine(person1 == person2);
public record Person(string Name, int Age); // positional record 