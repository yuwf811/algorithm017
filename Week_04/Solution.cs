public class Solution
{
    #region 柠檬水找零
    public bool LemonadeChange(int[] bills)
    {
        var five_count = 0;
        var ten_count = 0;
        var i = 0;
        while (i < bills.Length)
        {
            if (bills[i] == 5)
            {
                five_count++;
            }
            else if (bills[i] == 10)
            {
                if (five_count > 0)
                {
                    five_count--;
                    ten_count++;
                }
                else
                {
                    return false;
                }
            }
            else if (bills[i] == 20)
            {
                if (ten_count > 0 && five_count > 0)
                {
                    ten_count--;
                    five_count--;
                }
                else if (five_count >= 3)
                {
                    five_count -= 3;
                }
                else
                {
                    return false;
                }
            }
            i++;
        }
        return i >= bills.Length;
    }
    #endregion

    #region 买卖股票的最佳时机 II 
    public int MaxProfit(int[] prices)
    {
        var result = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                result += prices[i] - prices[i - 1];
            }
        }
        return result;
    }
    #endregion

    #region 分发饼干
    public int FindContentChildren(int[] g, int[] s)
    {
        Array.Sort(g);
        Array.Sort(s);
        var count = 0;
        var i = 0;
        var j = 0;
        while (i < g.Length && j < s.Length)
        {
            if (g[i] <= s[j])
            {
                count++;
                i++;
                j++;
            }
            else
            {
                j++;
            }
        }
        return count;
    }
    #endregion

    #region 模拟行走机器人
    public int RobotSim(int[] commands, int[][] obstacles)
    {
        var ans = 0;
        var position = new int[] { 0, 0 };
        //north:0 east:1 south:2 west:3
        var direction = 0;
        var hashSet = new HashSet<string>();
        foreach (var item in obstacles)
        {
            hashSet.Add(item[0] + "," + item[1]);
        }
        for (int i = 0; i < commands.Length; i++)
        {
            var command = commands[i];
            if (command == -2)
            {
                direction = direction - 1;
                if (direction < 0)
                {
                    direction += 4;
                }
            }
            else if (command == -1)
            {
                direction = (direction + 1) % 4;
            }
            else if (command >= 1 && command <= 9)
            {
                while (command > 0)
                {
                    var nextPosition = new int[2];
                    switch (direction)
                    {
                        case 0:
                            nextPosition[0] = position[0];
                            nextPosition[1] = position[1] + 1;
                            break;
                        case 1:
                            nextPosition[0] = position[0] + 1;
                            nextPosition[1] = position[1];
                            break;
                        case 2:
                            nextPosition[0] = position[0];
                            nextPosition[1] = position[1] - 1;
                            break;
                        case 3:
                            nextPosition[0] = position[0] - 1;
                            nextPosition[1] = position[1];
                            break;
                    }

                    if (hashSet.Contains(nextPosition[0] + "," + nextPosition[1]))
                    {
                        break;
                    }
                    else
                    {
                        position = nextPosition;
                        ans = Math.Max(ans, (int)Math.Pow(position[0], 2) + (int)Math.Pow(position[1], 2));
                    }
                    command--;
                }
            }
        }
        return ans;
    }
    #endregion

    #region 单词接龙
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> hs = new HashSet<string>();
        Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
        queue.Enqueue(new Tuple<string, int>(beginWord, 1));
        hs.Add(beginWord);
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            beginWord = item.Item1;
            var count = item.Item2;
            for (int i = 0; i < beginWord.Length; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    var replace = ((char)('a' + j)).ToString();
                    var temp = beginWord.Substring(0, i) + replace + beginWord.Substring(i + 1, beginWord.Length - i - 1);
                    if (hs.Contains(temp))
                    {
                        continue;
                    }

                    var index = wordList.IndexOf(temp);
                    if (index >= 0)
                    {
                        if (temp == endWord)
                        {
                            return count + 1;
                        }
                        hs.Add(temp);
                        wordList.RemoveAt(index);
                        queue.Enqueue(new Tuple<string, int>(temp, count + 1));
                    }
                }
            }
        }
        return 0;
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

    #region 扫雷游戏
    public char[][] UpdateBoard(char[][] board, int[] click)
    {
        if (board[click[0]][click[1]] != 'M' && board[click[0]][click[1]] != 'E')
        {
            return board;
        }
        if (board[click[0]][click[1]] == 'E')
        {
            DFS(board, click[0], click[1]);
        }
        else
        {
            board[click[0]][click[1]] = 'X';
        }
        return board;
    }

    private void DFS(char[][] board, int i, int j)
    {
        var height = board.Length;
        var width = board[0].Length;
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != 'E')
        {
            return;
        }
        var count = 0;
        var index = 0;
        while (index < 9)
        {
            var row = i + index / 3 - 1;
            var column = j + index % 3 - 1;
            if (row >= 0 && row < height && column >= 0 && column < width)
            {
                if (board[row][column] == 'M')
                {
                    count++;
                }
            }
            index++;
        }
        if (count == 0)
        {
            board[i][j] = 'B';
            index = 0;
            while (index < 9)
            {
                var row = i + index / 3 - 1;
                var column = j + index % 3 - 1;
                if (row >= 0 && row < height && column >= 0 && column < width && board[row][column] == 'E')
                {
                    DFS(board, row, column);
                }
                index++;
            }
        }
        else
        {
            board[i][j] = (char)('0' + count);
        }
    }
    #endregion 

    #region 跳跃游戏 
    public bool CanJump(int[] nums)
    {
        var position = 0;
        var mostFar = 0;

        while (mostFar < nums.Length - 1)
        {
            var temp = mostFar;
            for (int i = position; i <= mostFar; i++)
            {
                temp = Math.Max(temp, nums[i] + i);
            }
            if (temp <= mostFar)
            {
                return false;
            }
            position = mostFar + 1;
            mostFar = temp;
        }

        return true;
    }
    #endregion

    #region 搜索旋转排序数组
    public int Search(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
        {
            return -1;
        }
        if (nums.Length == 1)
        {
            return nums[0] == target ? 0 : -1;
        }
        if (nums[0] == target)
        {
            return 0;
        }
        bool findInLeft = target > nums[0];
        bool stepOver = false;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                stepOver = true;
            }
            if (stepOver && findInLeft)
            {
                break;
            }
            if (nums[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    #endregion

    #region 搜索二维矩阵
    public bool SearchMatrix(int[][] matrix, int target)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return false;
        }
        var top = 0;
        var bottom = matrix.Length - 1;
        var columns = matrix[0].Length;
        if (columns == 0)
        {
            return false;
        }
        if (target < matrix[0][0] || target > matrix[bottom][columns - 1])
        {
            return false;
        }
        while (top < bottom)
        {
            var mid = (top + bottom) / 2;
            if (matrix[mid][0] > target)
            {
                bottom = mid - 1;
            }
            else if (matrix[mid][columns - 1] < target)
            {
                top = mid + 1;
            }
            else
            {
                top = mid;
                bottom = mid;
            }
        }
        var left = 0;
        var right = columns - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            if (matrix[top][mid] == target)
            {
                return true;
            }
            else if (matrix[top][mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return false;
    }
    #endregion

    #region 寻找旋转排序数组中的最小值
    public int FindMin(int[] nums)
    {
        var pos = FindPosition(nums);
        if (pos < 0 || pos > nums.Length - 1)
        {
            return nums[0];
        }
        else
        {
            return nums[pos];
        }
    }

    private int FindPosition(int[] nums)
    {
        var fromLeft = true;
        var left = 0;
        var right = nums.Length - 1;
        //前后夹逼
        while (left <= right)
        {
            var mid = (left + right) / 2;
            //如果mid位置的值比left位置的值小，说明转折点在mid位置或者mid位置往左
            if (nums[mid] < nums[left])
            {
                //如果mid位置的前一个值比left位置的值大，说明在mid位置，数组产生了无序
                if (nums[mid - 1] >= nums[left])
                {
                    return mid;
                }
                fromLeft = false;
                right = mid - 1;
            }
            //如果mid位置的值比right位置的值大，说明转折点在mid位置或者mid位置往右
            else if (nums[mid] > nums[right])
            {
                //如果mid位置的后一个值比right位置的值小，说明在mid位置，数组产生了无序
                if (nums[mid + 1] <= nums[right])
                {
                    return mid + 1;
                }
                fromLeft = true;
                left = mid + 1;
            }
            //如果nums[left] <= nums[mid] <= nums[right]说明剩下的left到right范围内的数据是有序的，推出循环
            else
            {
                break;
            }
        }
        //根据上一次迭代是从左边夹逼还是右边夹逼，获取转折点的位置
        return fromLeft ? left - 1 : right + 1;
    }
    #endregion

    #region 单词接龙 II 
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        var ans = new List<IList<string>>();
        Queue<Tuple<string, List<string>>> queue = new Queue<Tuple<string, List<string>>>();
        queue.Enqueue(new Tuple<string, List<string>>(beginWord, new List<string> { beginWord }));
        while (queue.Count > 0)
        {
            var found = false;
            var newQueue = new Queue<Tuple<string, List<string>>>();
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                beginWord = item.Item1;
                var list = item.Item2;

                for (int i = 0; i < beginWord.Length; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        var replace = ((char)('a' + j)).ToString();
                        var temp = beginWord.Substring(0, i) + replace + beginWord.Substring(i + 1, beginWord.Length - i - 1);
                        if (list.Contains(temp))
                        {
                            continue;
                        }

                        var index = wordList.IndexOf(temp);
                        if (index >= 0)
                        {
                            var newList = list.Select(s => s).ToList();
                            newList.Add(temp);
                            if (temp == endWord)
                            {
                                found = true;
                                ans.Add(newList);
                            }
                            else
                            {
                                newQueue.Enqueue(new Tuple<string, List<string>>(temp, newList));
                            }
                        }
                    }
                }
            }
            queue = newQueue;
            if (found)
            {
                break;
            }
        }
        return ans;
    }
    #endregion

    #region 跳跃游戏 II 
    public int Jump(int[] nums)
    {
        var count = 0;
        var position = 0;
        var fartest = 0;
        while (fartest < nums.Length - 1)
        {
            count++;
            var temp = 0;
            for (int i = position; i <= fartest; i++)
            {
                temp = Math.Max(temp, i + nums[i]);
            }
            if (temp <= fartest)
            {
                break;
            }
            position = fartest + 1;
            fartest = temp;
        }
        return count;
    }
    #endregion
}