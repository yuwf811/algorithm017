using System;
using System.Collections.Generic;

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q)
        {
            return root;
        }
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if (left == null)
        {
            return right;
        }
        else if (right == null)
        {
            return left;
        }
        else
        {
            return root;
        }
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return BuildTree2(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }

    private TreeNode BuildTree2(int[] preorder, int[] inorder, int preFrom, int preTo, int inFrom, int inTo)
    {
        if (preFrom > preTo)
        {
            return null;
        }
        var pre_root = preFrom;
        var in_root = Array.IndexOf(inorder, preorder[pre_root]);

        var root = new TreeNode(preorder[preFrom]);

        var size_left = in_root - inFrom;

        root.left = BuildTree2(preorder, inorder, preFrom + 1, preFrom + size_left, inFrom, in_root - 1);
        root.right = BuildTree2(preorder, inorder, preFrom + size_left + 1, preTo, in_root + 1, inTo);

        return root;
    }

    public IList<IList<int>> Combine(int n, int k)
    {
        if (k > n)
        {
            return new List<IList<int>>();
        }
        return Combine2(1, n, k);
    }

    private IList<IList<int>> Combine2(int start, int n, int k)
    {
        var result = new List<IList<int>>();
        if (k == 0)
        {
            return result;
        }
        if (k == n - start + 1)
        {
            var list = new List<int>();
            for (int i = start; i <= n; i++)
            {
                list.Add(i);
            }
            result.Add(list);
            return result;
        }
        var items = Combine2(start + 1, n, k - 1);
        if (items.Count > 0)
        {
            foreach (var item in items)
            {
                var list = new List<int> { start };
                list.AddRange(item);
                result.Add(list);
            }
        }
        else
        {
            result.Add(new List<int> { start });
        }
        result.AddRange(Combine2(start + 1, n, k));

        return result;
    }

    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                result.Add(new List<int> { nums[0] });
            }
            else
            {
                var temp = new List<IList<int>>();
                foreach (var list in result)
                {
                    for (int j = 0; j <= list.Count; j++)
                    {
                        var newList = CopyList(list);
                        newList.Insert(j, nums[i]);
                        temp.Add(newList);
                    }
                }
                result = temp;
            }
        }

        return result;
    }

    private List<int> CopyList(IList<int> list)
    {
        var newList = new List<int>();
        foreach (var item in list)
        {
            newList.Add(item);
        }
        return newList;
    }

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        var ans = new List<IList<int>>();
        var perm = new List<int>();
        var visited = new bool[nums.Length];
        Array.Sort(nums);
        BackTrack(nums, ans, visited, 0, perm);
        return ans;
    }

    private void BackTrack(int[] nums, IList<IList<int>> ans, bool[] visited, int index, List<int> perm)
    {
        if(perm.Count == nums.Length)
        {
            ans.Add(CopyList(perm));
            return;
        }

        for(int i = 0; i < nums.Length; i++)
        {
            if(visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
            {
                continue;
            }
            perm.Add(nums[i]);
            visited[i] = true;
            BackTrack(nums, ans, visited, index + 1, perm);
            visited[i] = false;
            perm.RemoveAt(perm.Count - 1);
        }
    }
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}