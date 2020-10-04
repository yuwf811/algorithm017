public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s == null || t == null || s.Length != t.Length)
        {
            return false;
        }
        
        var dict = new Dictionary<char, int>();
        foreach(char character in s)
        {
            if(dict.ContainsKey(character))
            {
                dict[character]++;
            }
            else
            {
                dict.Add(character, 1);
            }
        }

        foreach(char character in t)
        {
            if(!dict.ContainsKey(character) || dict[character] == 0)
            {
                return false;
            }
            dict[character]--;
        }
        foreach(var item in dict)
        {
            if(item.Value != 0)
            {
                return false;
            }
        }
        return true;
    }

    public int[] TwoSum(int[] nums, int target) {
        var dict = new Dictionary<int, int>();
        for(var i = 0; i < nums.Length; i++)
        {
            if(dict.Any() && dict.ContainsKey(target - nums[i]))
            {
                return new int[]{dict[target - nums[i]], i};
            }
            else
            {
                if(!dict.ContainsKey(nums[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
        }
        return null;
    }

    public IList<int> Preorder(Node root) {
        var result = new List<int>();
        if(root == null)
        {
            return result;
        }
        result.Add(root.val);
        foreach(var child in root.children)
        {
            result.AddRange(Preorder(child));
        }
        return result;
    }
}