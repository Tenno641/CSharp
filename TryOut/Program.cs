using System.Collections;

var type = new CustomCollection(new string[] { "name1", "name2", "name3" });
foreach(var item in type) // boxing may happen which is bad.
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
public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }
    public CustomCollection(string[] words)
    {
        Words = words;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    public IEnumerator<string> GetEnumerator()
    {
        Console.WriteLine("Generic");
        throw new NotImplementedException();
    }
}

public class WordsEnumerator : IEnumerator<string>
{
    private const int _InitialPosition = -1;
    private int _currentPosition = _InitialPosition;
    private string[] _words;
    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    public string Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            } catch(IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(CustomCollection)}'s limit reached", ex);
            }
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose()
    {
        // whaa..
    }

    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = _InitialPosition;
    }
} 
interface IApp
{
    void Run();
    void AppMethod();
}
interface IProcess<T> : IApp
{
    new T Run();
}
class CustomShit<T> : IProcess<T>
{
    public void AppMethod()
    {
        throw new NotImplementedException();
    }

    public T Run()
    {
        throw new NotImplementedException();
    }

    void IApp.Run()
    {
        throw new NotImplementedException();
    }
}
