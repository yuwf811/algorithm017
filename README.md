1. Array：访问 O(1)  删除：O(n)
   Linked List：访问 O(n)  删除：O(1)
   Stack：先进后出
   Queue：先进先出 Deque：两边都能操作
   Set: HashSet: O(1) 无序
        TreeSet: O(logn) 有序 二叉搜索树
   Tree: Preorder Traversal (VLR),Inorder Traversal (LDR),Postorder Traversal (LRD)
         二叉搜索树(binary search tree)的前序遍历是升序的
         大顶堆（小顶堆）适用于优先队列，以大顶堆为例：
            添加元素：将新元素插入堆尾，依次与父元素（(n - 1) / 2）比较，比父元素大，则与父元素交换，以此类推
            删除元素：移除根元素，将堆尾元素移到跟元素，依次比较左右节点（n * 2 + 1, n * 2 + 2）,将大的那个节点与跟节点做交换，以此类推
         并查集
         字典树

2. 搜索：
    DFS: 使用stack不断递归压栈，直到无法无法继续下探，弹出栈顶元素并重新下探其他分支
    BFS: 使用queue，将每一层种满足条件的元素enqueue，直到达成目标或者queue为空
    双向BFS: 
                  +
                +   +
              +   +   +
            +           +
              +   +   +
                +   +
                  +
    A*

3. 动态规划：一般用于求极值的问题，关键在于找到状态转移方程，通过备忘录的方式，存放中间状态，加速算法
4. 二分查找：通过将问题拆分成两个子问题，定义好子问题的终止条件，递归解决子问题，并将两个子问题的结果进行合并
5. 贪心算法：如果问题的局部最优解就是全局的最优解，可以通过每一步都选择当前最优来达到全局最优的目的
6. 代码模板：
    递归：
    recursion(level, params)
    {
        #recursion terminator
        if(level > maxlevel)
        {
            return;
        }

        #process current level
        process(level, params);

        #drill down
        recursion(levle + 1, params);
    }

    分治：
    divide_conquer(problem, prams)
    {
        #recursion terminator
        if(problem == null)
        {
            return;
        }

        subProblems = split_problem(problem, params);
        foreach(subProblem in subProblems)
        {
            subResult = divide_conquer(subProblems, params);
        }

        #process subResults
        result = processSubResults(subResult1, subResult2);
        return result; 
    }

    DFS:
    dfs(node, visited)
    {
        if(node in visited)
        {
            return;
        }
        visited.Add(node);
        foreach(child in node.Children)
        {
            if(child not in visited)
            {
                dfs(child, visited);
            }
        }
    }

    BFS:
    bfs(node)
    {
        if(node == null)
        {
            return;
        }
        visited = [];
        queue = [];
        queue.Enqueue(node);
        while(queue.Any())
        {
            current = queue.Pop();
            visited.Add(current);

            process(node);
            children = getRelatedNodes(node);
            foreach(child in children)
            {
                if(child not in visited)
                {
                    queue.Push(children);
                }
            }
        }
    }


7. 过遍数很重要，一道题需要反复做才能融会贯通！