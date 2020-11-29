public class Solution
{
    #region 字符串中的第一个唯一字符
    public int FirstUniqChar(string s) {
        var arr = new int[26];
        foreach(var c in s)
        {
            arr[c - 'a']++;
        }
        for(int i = 0; i < s.Length; i++)
        {
            if(arr[s[i] - 'a'] == 1)
            {
                return i;
            }
        }
        return -1;
    }
    #endregion

    #region 反转字符串 II
    public string ReverseStr(string s, int k) {
        var result = "";
        for(int i = 0; i < s.Length; i += 2 * k)
        {
            var start = i;
            var end = Math.Min(i + k - 1, s.Length - 1);
            while(end >= start)
            {
                result += s[end--];
            }
            start = i + k;
            end = Math.Min(i + 2 * k - 1, s.Length - 1);
            while(start <= end)
            {
                result += s[start++];
            }
        }
        return result;
    }
    #endregion
}