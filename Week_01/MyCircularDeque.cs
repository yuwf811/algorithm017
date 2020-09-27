using System.Collections.Generic;

public class MyCircularDeque
{

    private List<int> data;
    private int capacity;

    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k)
    {
        data = new List<int>();
        capacity = k;
    }

    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value)
    {
        if (capacity == data.Count)
        {
            return false;
        }
        data.Insert(0, value);
        return true;
    }

    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value)
    {
        if (capacity == data.Count)
        {
            return false;
        }
        data.Add(value);
        return true;
    }

    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront()
    {
        if (data.Count == 0)
        {
            return false;
        }
        data.RemoveAt(0);
        return true;
    }

    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast()
    {
        if (data.Count == 0)
        {
            return false;
        }
        data.RemoveAt(data.Count - 1);
        return true;
    }

    /** Get the front item from the deque. */
    public int GetFront()
    {
        if (data.Count == 0)
        {
            return -1;
        }
        return data[0];
    }

    /** Get the last item from the deque. */
    public int GetRear()
    {
        if (data.Count == 0)
        {
            return -1;
        }
        return data[data.Count - 1];
    }

    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty()
    {
        return data.Count == 0;
    }

    /** Checks whether the circular deque is full or not. */
    public bool IsFull()
    {
        return data.Count == capacity;
    }
}

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */