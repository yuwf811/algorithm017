学习笔记

1. C# PriorityQueue实现
```
public class PriorityQueue<T> where T : IComparable
{
    private List<T> data;

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        var index = data.Count - 1;
        while (index > 0 && item.CompareTo(data[(index - 1) / 2]) < 0)
        {
            var temp = data[index];
            data[index] = data[(index - 1) / 2];
            data[(index - 1) / 2] = temp;
            index = (index - 1) / 2;
        }
    }

    public T Dequeue()
    {
        if (data.Count == 0)
        {
            throw new Exception();
        }

        var ret = data[0];
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);

        if (data.Count > 0)
        {
            var p1 = 0;
            while (true)
            {
                var left = p1 * 2 + 1;
                var right = p1 * 2 + 2;
                if (left >= data.Count)
                {
                    break;
                }
                var p2 = left;
                if (right < data.Count && data[left].CompareTo(data[right]) > 0)
                {
                    p2 = right;
                }
                if (data[p1].CompareTo(data[p2]) <= 0)
                {
                    break;
                }
                var temp = data[p1];
                data[p1] = data[p2];
                data[p2] = temp;
                p1 = p2;
            }

        }

        return ret;
    }

    public T Peek()
    {
        return data[0];
    }

    public int Count()
    {
        return data.Count;
    }
}
```