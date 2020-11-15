public class Solution
{
    #region 爬楼梯
    public int ClimbStairs(int n)
    {
        if (n <= 2)
        {
            return n;
        }
        var a = 1;
        var b = 2;
        for (int i = 2; i < n; i++)
        {
            var temp = a + b;
            a = b;
            b = temp;
        }
        return b;
    }
    #endregion

    #region 朋友圈
    public int FindCircleNum(int[][] M)
    {
        var len = M.Length;
        var p = new int[len];
        for (int i = 0; i < p.Length; i++)
        {
            p[i] = i;
        }

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (M[i][j] == 1)
                {
                    Union(p, i, j);
                }
            }
        }

        var set = new HashSet<int>();
        for (int i = 0; i < p.Length; i++)
        {
            set.Add(Parent(p, i));
        }
        return set.Count;
    }

    private void Union(int[] p, int i, int j)
    {
        var p1 = Parent(p, i);
        var p2 = Parent(p, j);
        p[p2] = p1;
    }

    private int Parent(int[] p, int i)
    {
        var root = i;
        while (p[root] != root)
        {
            root = p[root];
        }

        while (p[i] != i)
        {
            var temp = i;
            i = p[i];
            p[temp] = root;
        }
        return root;
    }
    #endregion

    #region 岛屿数量
    public int NumIslands(char[][] grid)
    {
        var ans = 0;
        if (grid.Length == 0 || grid[0].Length == 0)
        {
            return ans;
        }
        var height = grid.Length;
        var width = grid[0].Length;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[i][j] == '1')
                {
                    ans++;
                    Dfs(grid, i, j);
                }
            }
        }
        return ans;
    }

    private void Dfs(char[][] grid, int i, int j)
    {
        if (grid[i][j] == '1')
        {
            grid[i][j] = '0';
            if (i < grid.Length - 1)
            {
                Dfs(grid, i + 1, j);
            }
            if (i > 0)
            {
                Dfs(grid, i - 1, j);
            }
            if (j < grid[0].Length - 1)
            {
                Dfs(grid, i, j + 1);
            }
            if (j > 0)
            {
                Dfs(grid, i, j - 1);
            }
        }
    }
    #endregion

    #region 括号生成
    public IList<string> GenerateParenthesis(int n)
    {
        var ans = new List<string>();
        Generate(ans, 0, 0, n, "");
        return ans;
    }

    private void Generate(List<string> ans, int left, int right, int n, string s)
    {
        if (left == n && right == n)
        {
            ans.Add(s);
        }
        if (left < n)
        {
            Generate(ans, left + 1, right, n, s + "(");
        }
        if (left > right)
        {
            Generate(ans, left, right + 1, n, s + ")");
        }
    }
    #endregion

    #region 单词接龙
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> words = new HashSet<string>(wordList);
        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        var len = beginWord.Length;
        queue.Enqueue(new Tuple<string, int>(beginWord, 1));
        while (queue.Any())
        {
            var tuple = queue.Dequeue();
            var word = tuple.Item1;
            var count = tuple.Item2;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    char c = (char)('a' + j);
                    var newWord = word.Substring(0, i) + c + word.Substring(i + 1, len - i - 1);
                    if (words.Contains(newWord))
                    {
                        words.Remove(newWord);
                        if (newWord == endWord)
                        {
                            return count + 1;
                        }
                        else
                        {
                            queue.Enqueue(new Tuple<string, int>(newWord, count + 1));
                        }
                    }
                }
            }
        }

        return 0;
    }
    #endregion

    #region 最小基因变化
    public int MinMutation(string start, string end, string[] bank)
    {
        if (bank.Length == 0)
        {
            return -1;
        }
        var queue = new Queue<Tuple<string, int>>();
        var possibles = new string[] { "A", "C", "G", "T" };
        queue.Enqueue(new Tuple<string, int>(start, 0));
        while (queue.Count > 0)
        {
            var tuple = queue.Dequeue();
            start = tuple.Item1;
            var count = tuple.Item2;
            for (int i = 0; i < start.Length; i++)
            {
                foreach (var gene in possibles)
                {
                    var temp = start.Substring(0, i) + gene + start.Substring(i + 1, start.Length - i - 1);
                    var index = Array.IndexOf(bank, temp);
                    if (index >= 0)
                    {
                        if (temp == end)
                        {
                            return count + 1;
                        }
                        bank[index] = null;
                        queue.Enqueue(new Tuple<string, int>(temp, count + 1));
                    }
                }
            }
        }
        return -1;
    }
    #endregion

    #region 单词搜索2
    public IList<string> FindWords(char[][] board, string[] words) {
        var ret = new List<string>();
        if(board.Length == 0 || board[0].Length == 0 || words.Length == 0)
        {
            return ret;
        }
        
        var trie = new Trie();
        foreach(var word in words)
        {
            trie.Insert(word);
        }

        var height = board.Length;
        var width = board[0].Length;
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                dfs(ret, board, trie, "", i, j);
            }
        }
        return ret;
    }

    private void dfs(IList<string> ret, char[][] board, Trie trie, string word, int x, int y)
    {
        if( x < 0 || x >= board.Length || y <0 || y >= board[0].Length || board[x][y] == '#')
        {
            return;
        }

        trie = trie.PreSearch(board[x][y].ToString());
        if(trie == null)
        {
            return;
        }
        else
        {
            var newWord = word + board[x][y];
            var temp = board[x][y];
            board[x][y] = '#';
            if(trie.IsEnd)
            {
                ret.Add(newWord);
                trie.IsEnd = false;
            }
            var directions = new int[4][]{ new int[]{ -1, 0 }, new int[]{ 0, 1 }, new int[]{ 1, 0 }, new int[]{ 0, -1 }  };
            foreach(var dir in directions)
            {
                dfs(ret, board, trie, newWord, x + dir[0], y + dir[1]);
            }
            board[x][y] = temp;
        }
    }
    #endregion

    #region N皇后
    public IList<IList<string>> SolveNQueens(int n) {
        var columns = new HashSet<int>();
        var pie = new HashSet<int>();
        var na = new HashSet<int>();
        var ans = new List<IList<string>>();
        var term = new List<string>();
        Fill(columns, pie, na, ans, term, n, 0);
        return ans;
    }

    private void Fill(HashSet<int> columns, HashSet<int> pie, HashSet<int> na, IList<IList<string>> ans, IList<string> term, int n, int row)
    {
        if (row >= n)
        {
            var temp = new List<string>();
            foreach (var item in term)
            {
                temp.Add(item);
            }
            ans.Add(temp);
            return;
        }
        for (int i = 0; i < n; i++)
        {
            if (!columns.Contains(i) && !pie.Contains(row + i) && !na.Contains(row - i))
            {
                columns.Add(i);
                pie.Add(row + i);
                na.Add(row - i);
                term.Add(GenerateStr(n, i));
                Fill(columns, pie, na, ans, term, n, row + 1);
                term.RemoveAt(term.Count - 1);
                columns.Remove(i);
                pie.Remove(row + i);
                na.Remove(row - i);
            }
        }
    }
    
    private string GenerateStr(int n, int index)
    {
        var result = "";
        for (int i = 0; i < n; i++)
        {
            result += i == index ? "Q" : ".";
        }
        return result;
    }
    #endregion
}