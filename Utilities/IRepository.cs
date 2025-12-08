namespace Utilities;
public interface IRepository
{
    public Person Get(int id);
    public void Add(int id, string name, int age);
}
