public class Solution
{
    #region 位1的个数
    public int HammingWeight(uint n)
    {
        var count = 0;
        while (n != 0)
        {
            count++;
            n = n & (n - 1);
        }
        return count;
    }
    #endregion

    #region 2的幂
    public bool IsPowerOfTwo(int n)
    {
        return n > 0 && ((n & (n - 1)) == 0);
    }
    #endregion

    #region 颠倒二进制位
    public uint reverseBits(uint n)
    {
        uint ans = 0;
        for (int i = 0; i < 32; i++)
        {
            ans = (ans << 1) + (n & 1);
            n = n >> 1;
        }
        return ans;
    }
    #endregion

    #region 数组的相对排序
    public int[] RelativeSortArray(int[] arr1, int[] arr2)
    {
        var comparer = new MyComparer(arr2);
        Array.Sort(arr1, comparer);
        return arr1;
    }
    #endregion

    #region 有效的字母异位词
    public bool IsAnagram(string s, string t)
    {
        if (s == null || t == null || s.Length != t.Length)
        {
            return false;
        }

        var dict = new Dictionary<char, int>();
        foreach (char character in s)
        {
            if (dict.ContainsKey(character))
            {
                dict[character]++;
            }
            else
            {
                dict.Add(character, 1);
            }
        }

        foreach (char character in t)
        {
            if (!dict.ContainsKey(character) || dict[character] == 0)
            {
                return false;
            }
            dict[character]--;
        }
        foreach (var item in dict)
        {
            if (item.Value != 0)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region 合并区间
    public int[][] Merge(int[][] intervals)
    {
        var comparer = new MyComparer2();
        Array.Sort(intervals, comparer);
        var ret = new List<int[]>();
        var min = intervals[0][0];
        var max = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] <= max)
            {
                max = Math.Max(max, intervals[i][1]);
            }
            else
            {
                ret.Add(new int[] { min, max });
                min = intervals[i][0];
                max = intervals[i][1];
            }
        }
        ret.Add(new int[] { min, max });
        return ret.ToArray();
    }
    #endregion

    #region N皇后 II
    public int TotalNQueens(int n)
    {
        var count = 0;
        dfs(ref count, 0, 0, 0, n, 0);
        return count;
    }

    private void dfs(ref int count, int columns, int xy_add, int xy_diff, int n, int row)
    {
        if (row == n)
        {
            count++;
            return;
        }
        var bits = ~(columns | xy_add | xy_diff) & ((1 << n) - 1); //位1为可以填充皇后的位置
        while (bits > 0)
        {
            var p = bits & -bits;  //p为每次填充皇后的位置
            bits = bits & (bits - 1);
            dfs(ref count, columns | p, (xy_add | p) >> 1, (xy_diff | p) << 1, n, row + 1);
        }
    }
    #endregion

    #region 翻转对
    public int ReversePairs(int[] nums)
    {
        return MergeSort(nums, 0, nums.Length - 1);
    }

    private int MergeSort(int[] nums, int l, int r)
    {
        if (l >= r)
        {
            return 0;
        }
        var mid = l + (r - l) / 2;
        var count = MergeSort(nums, l, mid) + MergeSort(nums, mid + 1, r);
        var cache = new int[r - l + 1];
        var c = 0;
        var i = l;
        var t = l;
        for (int j = mid + 1; j <= r; j++, c++)
        {
            while (i <= mid && nums[i] <= 2 * (long)nums[j])
            {
                i++;
            }
            while (t <= mid && nums[t] < nums[j])
            {
                cache[c++] = nums[t++];
            }
            cache[c] = nums[j];
            count += mid - i + 1;
        }
        while (t <= mid)
        {
            cache[c++] = nums[t++];
        }
        for (int k = 0; k < cache.Length; k++)
        {
            nums[l + k] = cache[k];
        }
        return count;
    }
    #endregion
}