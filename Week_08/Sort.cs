public class Sort
{
    public void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            var minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if(arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            Swap(i, minIndex);
        }
    }

    public void InsertionSort(int[] arr)
    {
        for(int i = 1; i < arr.Length; i++)
        {
            var temp = arr[i];
            var j = i - 1;
            while(arr[j] > arr[i] && j >= 0)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
    }

    public void BubbleSort(int[] arr)
    {
        for(int i = arr.Length - 1; i >= 1; i--)
        {
            for(int j = 0; j <= i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                }
            }
        }
    }

    public void QuickSort(int[] arr)
    {
        partition(arr, 0, arr.Length - 1);
    }

    private void partition(int[] arr, int l, int r)
    {
        if (l >= r)
        {
            return;
        }
        var pivot = r;
        var p = l;
        for (int i = l; i <= r; i++)
        {
            if (arr[i] < arr[pivot])
            {
                Swap(arr, i, p++);
            }
        }
        Swap(arr, p, pivot);
        partition(arr, l, p - 1);
        partition(arr, p + 1, r);
    }

    public void MergeSort(int[] arr)
    {
        Merge(arr, 0, arr.Length - 1);
    }

    private void Merge(int[] arr, int l, int r)
    {
        if(l >= r)
        {
            return;
        }
        var mid = l + (r - l) / 2;
        Merge(arr, l, mid);
        Merge(arr, mid + 1, r);

        var p1 = l;
        var p2 = mid + 1;
        var cache = new int[r - l + 1];
        var index = 0;
        while(p1 <= mid || p2 <= r)
        {
            if(p1 <= mid && p2 <= r)
            {
                cache[index++] = arr[p1] < arr[p2] ? arr[p1++] : arr[p2++];
            }
            else if(p1 <= mid)
            {
                cache[index++] = arr[p1++];
            }
            else
            {
                cache[index++] = arr[p2++];
            }
        }
        for(int i = 0; i < cache.Length; i++)
        {
            arr[l + i] = cache[i];
        }
    }

    private void Swap(int[] arr, int i, int j)
    {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
    }
}