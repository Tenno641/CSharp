using System.Collections;

var type = new CustomCollection(new string[] { "name1", "name2", "name3" });
foreach(object item in type) // boxing may happen which is bad.
{
    Console.WriteLine(item);
}
/*
IEnumerator wordsEnumerator = type.GetEnumerator();
object currentWord;
while(wordsEnumerator.MoveNext())
{
    currentWord = wordsEnumerator.Current;
    Console.WriteLine(currentWord);
}
*/
public class CustomCollection : IEnumerable
{
    public string[] Words { get; }
    public CustomCollection(string[] words)
    {
        Words = words;
    }

    public IEnumerator GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }
}

public class WordsEnumerator : IEnumerator
{
    private const int _InitialPosition = -1;
    private int _currentPosition = _InitialPosition;
    private string[] _words;
    public WordsEnumerator(string[] words)
    {
        _words = words;
    }
    public object Current => _words[_currentPosition];

    public bool MoveNext()
    {
        _currentPosition++;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = _InitialPosition;
    }
} 
