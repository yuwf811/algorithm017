public class Solution {
    public int MinPathSum(int[][] grid) {
        var rows = grid.Length;
        var columns = grid[0].Length;
        var dp = new int[rows][];
        for(int i = 0;i<rows;i++)
        {
            dp[i] = new int[columns];
            if(i==0)
            {
                dp[0][0] = grid[0][0];
                for(int j = 1;j<columns;j++)
                {
                    dp[0][j] = dp[0][j-1]+grid[0][j];
                }
            }
            else
            {
              dp[i][0] = dp[i-1][0]+grid[i][0];
            }
        }

        for(int i = 1 ;i<rows;i++)
        {
            for(int j = 1 ;j< columns; j++)
            {
                dp[i][j] = grid[i][j]+ Math.Min(dp[i][j-1],dp[i-1][j]);
            }
        }
        return dp[rows-1][columns-1];
    }

    public int NumDecodings(string s)
    {
        var dp = new int[s.Length];
        for(int i = 0; i < s.Length; i++)
        {
            if(i == 0)
            {
                dp[i] = s[0] == '0' ? 0 : 1;
            }
            else if(i == 1)
            {
                dp[i] = (s[0] == '0' || (s[0] >= '3' && s[1] == '0'))? 0 :
                        ((s[0] == '2' && s[1] >= '7') || s[0] >= '3' || s[1] == '0' ? 1 : 2);  
            }
            else
            {
                if(s[i] == '0')
                {
                    dp[i] = (s[i - 1] >= '3' || s[i - 1] == '0') ? 0 : dp[i - 2];
                }
                else if((s[i] >= '7' &&  s[i - 1] == '2')|| s[i - 1] >= '3' || s[i - 1] == '0')
                {
                    dp[i] = dp[i - 1];
                }
                else
                {
                    dp[i] = dp[i - 2] + dp[i - 1];
                }
            }
            if(dp[i] == 0)
            {
                return 0;
            }
        }
        return dp[s.Length - 1];
    }

    public int MaximalSquare(char[][] matrix) {
        if(matrix.Length == 0 || matrix[0].Length == 0)
        {
            return 0;
        }
        var maxSlide = 0;
        var height = matrix.Length;
        var width = matrix[0].Length;
        var dp = new int[height][];
        for(int i = 0; i < height ; i++)
        {
            dp[i] = new int[width];
            for(int j = 0; j < width; j++)
            {
                if(matrix[i][j] == '1')
                {
                    //最边缘的1，只能形成变成为1的正方形
                    if(i == 0 || j == 0)
                    {
                        dp[i][j] = 1;
                    }
                    else
                    {
                        dp[i][j] = Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]) + 1;
                    }
                }
                maxSlide = Math.Max(dp[i][j], maxSlide);
            }
        }
        return maxSlide * maxSlide;
    }

    public int LeastInterval(char[] tasks, int n) {
        int[] map = new int[26];
        foreach (var c in tasks)
            map[c - 'A']++;
        Array.Sort(map);
        int max_val = map[25] - 1;
        int idle_slots = max_val * n;
        for (int i = 24; i >= 0 && map[i] > 0; i--) {
            idle_slots -= Math.Min(map[i], max_val);
        }
        return idle_slots > 0 ? idle_slots + tasks.Length : tasks.Length;
    }

    public int CountSubstrings(string s) {
        var len = s.Length;
        var count = 0;
        var dp = new bool[len][];
        for(int i = 0; i < len; i++)
        {
            dp[i] = new bool[len];
            for(int j = 0; j <= i; j++)
            {
                if(i == j)
                {
                    dp[j][i] = true;
                }
                else if(i - j == 1)
                {
                    dp[j][i] = s[i] == s[j];
                }
                else
                {
                    dp[j][i] = s[i] == s[j] && dp[j + 1][i - 1];
                }
                if(dp[j][i])
                {
                    count++;
                }
            }
        }
        return count;
    }

}