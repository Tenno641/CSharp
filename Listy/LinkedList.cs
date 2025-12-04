using System.Collections;

namespace Listy;

public class LinkedList<T> : ILinkedList<T?>
{
    private int _count;
    private Node<T>? _head;

    public int Count => _count;

    public bool IsReadOnly => false;
    public void Add(T? item)
    {
        AddToEnd(item);
    }

    public void AddToEnd(T? item)
    {
        Node<T> newNode = new Node<T>(item);
        if (_head is null)
        {
            _head = newNode;
        } else
        {
            Node<T>? last = GetNodes().Last();
            last.Next = newNode;
        }
        _count++;
    }

    public void AddToFront(T? item)
    {
        Node<T> newNode = new Node<T>(item);
        newNode.Next = _head;
        _head = newNode;
        _count++;
    }

    public void Clear()
    {
        Node<T>? current = _head;
        while(current is not null)
        {
            Node<T>? temporary = current;
            current = current.Next;
            temporary.Next = null;
        }
        _count = 0;
    }

    public bool Contains(T? item)
    {
        if (item is null)
        {
            return GetNodes().Any(node => node.Value is null);
        }
        return GetNodes().Any(node => item.Equals(node.Value));
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array is null) throw new ArgumentNullException(nameof(array));
        if (arrayIndex < 0 || arrayIndex >= array.Length) throw new ArgumentOutOfRangeException(nameof(array));
        if (array.Length < arrayIndex + _count) throw new ArgumentException("array is not big enough)");
        foreach(Node<T>? node in GetNodes())
        {
            array[arrayIndex] = node.Value;
            arrayIndex++;
        }
    }

    public bool Remove(T? item)
    {
        foreach(Node<T>? node in GetNodes())
        {
            Node<T>? predecessor = null;
            if ((node.Value is null && item is null)
                || (node.Value is not null && node.Value.Equals(item)))
            {
                if(predecessor is null)
                {
                    _head = node.Next;
                } else
                {
                    predecessor.Next = node.Next;
                }
                _count--;
            }
            predecessor = node;
        }
        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        foreach(Node<T> node in GetNodes())
        {
            yield return node.Value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private IEnumerable<Node<T>> GetNodes()
    {
        Node<T>? current = _head;
        while(current is not null)
        {
            yield return current;
            current = current.Next;
        }
    }
}

public class Node<T>
{
    public T? Value { get; }
    public Node<T>? Next { get; set; }
    public Node(T? value)
    {
        Value = value;
    }
}

public interface ILinkedList<T> : ICollection<T?>
{
    void AddToFront(T? item);
    void AddToEnd(T? item);
}
