using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
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

    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (dict.Any() && dict.ContainsKey(target - nums[i]))
            {
                return new int[] { dict[target - nums[i]], i };
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

    public IList<int> Preorder(Node root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        result.Add(root.val);
        foreach (var child in root.children)
        {
            result.AddRange(Preorder(child));
        }
        return result;
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();
        foreach (var str in strs)
        {
            var key = SortStr(str);
            if (dict.ContainsKey(key))
            {
                dict[key].Add(str);
            }
            else
            {
                dict.Add(key, new List<string> { str });
            }
        }

        var result = new List<IList<string>>();
        foreach (var item in dict)
        {
            result.Add(item.Value);
        }

        return result;
    }

    private string SortStr(string str)
    {
        var temp = str.ToArray();
        Array.Sort(temp);
        return string.Join("", temp);
    }

    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        result.AddRange(InorderTraversal(root.left));
        result.Add(root.val);
        result.AddRange(InorderTraversal(root.right));

        return result;
    }

    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root == null)
        {
            return result;
        }
        result.Add(root.val);
        result.AddRange(PreorderTraversal(root.left));
        result.AddRange(PreorderTraversal(root.right));

        return result;
    }

    public IList<IList<int>> LevelOrder(Node root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        return GetOneLevel(new List<Node> { root });
    }

    private IList<IList<int>> GetOneLevel(IList<Node> nodes)
    {
        var result = new List<IList<int>>();
        var currentLevel = new List<int>();
        var nextLevelNodes = new List<Node>();
        foreach (var node in nodes)
        {
            currentLevel.Add(node.val);
            if (node.children != null && node.children.Count > 0)
            {
                nextLevelNodes.AddRange(node.children);
            }
        }
        result.Add(currentLevel);
        if (nextLevelNodes.Count > 0)
        {
            result.AddRange(GetOneLevel(nextLevelNodes));
        }
        return result;
    }

    public int NthUglyNumber(int n)
    {
        var dp = new int[n];
        dp[0] = 1;
        int p1 = 0, p2 = 0, p3 = 0;
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Min(Math.Min(dp[p1] * 2, dp[p2] * 3), dp[p3] * 5);
            if (dp[i] == dp[p1] * 2)
            {
                p1++;
            }
            if (dp[i] == dp[p2] * 3)
            {
                p2++;
            }
            if (dp[i] == dp[p3] * 5)
            {
                p3++;
            }
        }
        return dp[n - 1];
    }

    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict.Add(num, 1);
            }
        }

        var arr = dict.Keys.ToArray();
        QuickSort(dict, arr, 0, arr.Length - 1, k);
        var result = new int[k];
        Array.Copy(arr, result, k);
        return result;
        //return dict.OrderByDescending(i => i.Value).Take(k).Select(i => i.Key).ToArray();
    }

    private void QuickSort(Dictionary<int, int> dict, int[] arr, int start, int end, int k)
    {
        var picked = start;
        var target = dict[arr[picked]];
        var index = start + 1;
        for (int i = start + 1; i <= end; i++)
        {
            if (dict[arr[i]] > target)
            {
                Swap(arr, index, i);
                index++;
            }
        }
        Swap(arr, start, index - 1);

        if (index - start == k)
        {
            return;
        }
        else if (index - start < k)
        {
            QuickSort(dict, arr, index, end, k - index + start);
        }
        else
        {
            QuickSort(dict, arr, start, index - 1, k);
        }
    }

    private void Swap(int[] arr, int left, int right)
    {
        var temp = arr[left];
        arr[left] = arr[right];
        arr[right] = temp;
    }
}



public class Node
{
    public int val;
    public IList<Node> children;

    public Node() { }

    public Node(int _val)
    {
        val = _val;
    }

    public Node(int _val, IList<Node> _children)
    {
        val = _val;
        children = _children;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
