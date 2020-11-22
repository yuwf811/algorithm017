public class MyComparer : IComparer<int>
{
    private Dictionary<int, int> numbers;
    public MyComparer(int[] arr)
    {
        numbers = new Dictionary<int, int>();
        for(int i = 0; i < arr.Length; i++)
        {
            numbers.Add(arr[i], i);
        }
    }

    public int Compare(int n1, int n2)
    {
        if(numbers.ContainsKey(n1) && numbers.ContainsKey(n2))
        {
            return numbers[n1] - numbers[n2];
        }
        else if(numbers.ContainsKey(n1))
        {
            return -1;
        }
        else if(numbers.ContainsKey(n2))
        {
            return 1;
        }
        else
        {
            return n1 - n2;
        }
    }
}