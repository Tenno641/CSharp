using System.Collections;

var text = "string";
foreach(char ch in text)
{
    Console.WriteLine(ch);
}

var type = new CustomType(new string[] { "name1", "name2", "name3" });

IEnumerator wordsEnumerator = type.GetEnumerator();
object currentWord;
while(wordsEnumerator.MoveNext())
{
    currentWord = wordsEnumerator.Current;
    Console.WriteLine(currentWord);
}
public class CustomType : IEnumerable
{
    public string[] Words { get; }
    public CustomType(string[] words)
    {
        Words = words;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

