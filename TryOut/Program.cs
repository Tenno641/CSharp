using System.Collections;
using System.Collections.ObjectModel;




Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(4);

int first = stack.Pop();
int stackSecond = stack.Peek();

Queue<int> intQueue = new Queue<int>();
intQueue.Enqueue(1);
intQueue.Enqueue(4);

int number = intQueue.Dequeue();
int second = intQueue.Peek();

PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();
priorityQueue.Enqueue("VIP", 1);
priorityQueue.Enqueue("Regular", 3);
priorityQueue.Enqueue("Platinum", 2);

Console.ReadLine();

var hugeArray = Enumerable.Repeat(0, 100_000_000);
List<int> ints = new List<int>(hugeArray);

ints.Clear(); // memory still allocated
ints.TrimExcess();

ints.Remove(2); // will search the list and then delete

string[] stringArray = { "one", "two", "three" };
int? wordIndex = BinarySearch(stringArray, "three");
Console.WriteLine(wordIndex);

int? BinarySearch<T>(T[] array, T item) where T: IComparable<T>
{
    Array.Sort(array);
    int low = 0;
    int high = array.Length - 1;
    while(high >= low)
    {
        int middle = (low + high) / 2;
        if (array[middle].Equals(item)) return middle;
        if (array[middle].CompareTo(item) < 0) low = middle + 1;
        if (array[middle].CompareTo(item) > 0) high = middle - 1;
    }
    return null;
}

int[] array = new int[] { 5, 2, 6, 2, 6, 3, 2, 1, 4, 7, 8, 9 };
int? index = BinarySearchInt(array, 7);
Console.WriteLine(index);

int? BinarySearchInt(int[] array, int item)
{
    Array.Sort(array);
    int low = 0;
    int high = array.Length - 1;
    while (high >= low)
    {
        int middle = (high + low) / 2;
        if (array[middle].Equals(item)) return middle;
        if (array[middle] > item) high = middle - 1;
        if (array[middle] < item) low = middle + 1;
    }
    return null;
}

/*
List<string> words = (List<string>)GetNumbers();
words.Add("Honga-Bonga");

Console.WriteLine(string.Join(Environment.NewLine, words));

IEnumerable<string> GetNumbers()
{
    List<string> words = new List<string>() { "One", "Two", "three" };
    return new ReadOnlyCollection<string>(words);
}

var array = new int[] { 1, 5, 6, 3 };
var implementedInterfaces = array.GetType().GetInterfaces();
Console.WriteLine(string.Join<Type>(Environment.NewLine, implementedInterfaces));

ICollection<int> collection = array;
collection.Add(5);

var customCollection = new CustomCollection(new string[] { "name1", "name2", "name3" });
Console.WriteLine(customCollection[0]);
customCollection[1] = "Honga-Bonga";
foreach(var item in customCollection) // boxing may happen which is bad.
{
    Console.WriteLine(item);
}

IEnumerator wordsEnumerator = type.GetEnumerator();
object currentWord;
while(wordsEnumerator.MoveNext())
{
    currentWord = wordsEnumerator.Current;
    Console.WriteLine(currentWord);
}
*/

public static class HashSetsUnionExercise
{
    public static HashSet<T> CreateUnion<T>(
        HashSet<T> set1, HashSet<T> set2)
    {
        IEnumerable<T> result = set1.Union(set2);
        return new HashSet<T>(result);
    }
}

public class CustomCollection : IEnumerable<string>
{
    public string[] Words { get; }
    public CustomCollection(int capacity = 10)
    {
        Words = new string[capacity];
    }
    public CustomCollection(string[] words)
    {
        Words = words;
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
