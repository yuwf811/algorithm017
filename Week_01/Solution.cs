public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return 0;
        }
        var count = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[count] = nums[i];
                count++;
            }
        }

        return count;
    }

    public void Rotate(int[] nums, int k)
    {
        if (nums == null || nums.Length == 0)
        {
            return;
        }
        k = k % nums.Length;
        var temp = new int[k];
        for (int i = nums.Length - k; i < nums.Length; i++)
        {
            temp[i + k - nums.Length] = nums[i];
        }
        for (int i = nums.Length - k - 1; i >= 0; i--)
        {
            nums[i + k] = nums[i];
        }
        for (int i = 0; i < temp.Length; i++)
        {
            nums[i] = temp[i];
        }
    }

    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        if (l1 == null)
        {
            return l2;
        }
        if (l2 == null)
        {
            return l1;
        }
        if (l1.val < l2.val)
        {
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        if (m <= 0)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[i] = nums2[i];
            }
        }
        else if (n <= 0)
        {
            return;
        }
        else
        {
            if (nums1[m - 1] > nums2[n - 1])
            {
                nums1[m + n - 1] = nums1[m - 1];
                m--;
            }
            else
            {
                nums1[m + n - 1] = nums2[n - 1];
                n--;
            }
            Merge(nums1, m, nums2, n);
        }
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var key = target - nums[i];
            if (dict.ContainsKey(key))
            {
                return new int[] { dict[key], i };
            }
            else
            {
                if (!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
        }
        return null;
    }

    public void MoveZeroes(int[] nums)
    {
        var j = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                var temp = nums[j];
                nums[j] = nums[i];
                nums[i] = temp;
                j++;
            }
        }
    }

    public int[] PlusOne(int[] digits)
    {
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            if (digits[i] <= 8)
            {
                digits[i]++;
                return digits;
            }
            else
            {
                digits[i] = 0;
            }
        }
        digits = new int[digits.Length + 1];
        digits[0] = 0;
        return digits;
    }
}