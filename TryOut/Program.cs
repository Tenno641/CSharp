using System.Collections;

var customCollection = new CustomCollection(new string[] { "name1", "name2", "name3" });
Console.WriteLine(customCollection[0]);
customCollection[1] = "Honga-Bonga";
foreach(var item in customCollection) // boxing may happen which is bad.
{
    Console.WriteLine(item);
}
var newCustomCollection = new CustomCollection { "one", "two", "three" };
CustomCollection newCustomCollectionExpression = ["one", "two", "three"];
Console.ReadKey();

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
    private int _currentIndex = 0;
    public CustomCollection(int capacity = 10)
    {
        Words = new string[capacity];
    }
    public CustomCollection(string[] words)
    {
        Words = words;
    }
    public void Add(string value)
    {
        Words[_currentIndex++] = value; 
    }
    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return new WordsEnumerator(Words);
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

public class PairOfArrays<TLeft, TRight>
{
    private readonly TLeft[] _left;
    private readonly TRight[] _right;

    public PairOfArrays(
        TLeft[] left, TRight[] right)
    {
        _left = left;
        _right = right;
    }

    public (TLeft, TRight) this[int leftIndex, int rightIndex]
    {
        get
        {
            if (leftIndex > _left.Length || rightIndex > _right.Length) throw new IndexOutOfRangeException();
            return (_left[leftIndex], _right[rightIndex]);
        }
        set
        {
            if (leftIndex > _left.Length || rightIndex > _right.Length) throw new IndexOutOfRangeException();
            _left[leftIndex] = value.Item1;
            _right[rightIndex] = value.Item2;
        }
    }
}
