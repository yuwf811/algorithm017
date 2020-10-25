学习笔记
DFS(深度优先，使用stack结构实现)
BFS(广度优先，使用queue结构实现)

public int FindPosition(int[] nums)
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
                if(nums[mid - 1] >= nums[left])
                {
                    return mid;
                }
                fromLeft = false;
                right = mid - 1;
            }
            //如果mid位置的值比right位置的值大，说明转折点在mid位置或者mid位置往右
            else if (nums[mid] >= nums[right])
            {
                //如果mid位置的后一个值比right位置的值小，说明在mid位置，数组产生了无序
                if(nums[mid + 1] < nums[right])
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