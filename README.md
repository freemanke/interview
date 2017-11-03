# 技术面试基础算法

## Subset I (无重复数字)
- [*****] => []
- [****1] => [] [1] 
- [**1,2] => [] [1] [2] [1,2]
- [1,2,3] => [] [1] [2] [1,2] [3] [1,3] [2,3] [1,2,3]

通过样例我们可以总结出基本规律，第n个结果总是等于第n-1的结果组合加上一组新的组合，这组新的组合是在n-1的组合结果的每个项中添加第n个数而成的，基于这个规律，用递归实现起来应该是最简洁的, 递归的终止条件: n == 1 return [] [1].

## Subset II (有重复数字)
- [*******] => []
- [******1] => [] [1] 
- [****1,1] => [] [1] [1,1]
- [**1,1,2] => [] [1] [1,1] [2] [1,2] [1,1,2]
- [1,1,2,2] => [] [1] [1,1] [2] [1,2] [1,1,2] [2,2] [1,2,2] [1,1,2,2]

因为Subset中不允许包含该相同的组合，所以当有重复数字存在的时候，我们需要过滤掉已经有的组合，一种思路就是如果该给定集合为无序的，则我们先排好序，看一下上面的样例结果，我们不难总结出规律: 如果第n个数和第n-1个数相同，则从第n-1的结果集中构造新组合应该不是从第0个开始而是从i=count[n-2]开始

## Palindrome 回文检测问题
1 https://leetcode.com/problems/palindrome-number/description/


## 排序算法

术语

- 稳定性 如果a原本在b前面，而a=b，排序后a仍然在b的前面，则该算法是稳定的，否则是不稳定的
- 内排序 所有操作都在内存中完成
- 外排序 由于数据太大，因此数据需要放到磁盘中
- 时间复杂度 一个算法执行所耗费的时间
- 空间复杂度 算法所需内存占用


### Bubble Sort O(n2)
### Selection Sort O(n2)
### Insertion Sort O(n2)
### Shell Sort O(nlogn)
### Merge Sort O(nlogn)
### QuickSort O(nlogn)


## 递归
- 一个函数直接或间接调用自身，这个过程叫做递归过程
- 必须要有一个明确的递归结束条件，叫做递归出口
- 递归算法阶梯简洁，但运行效率较低
- 递归次数过多容易造成栈溢出

```
int Caculate(int n)
{
	if(n == 1 || n == 2) return 1;
	
	return Caculate(n-1) + Caculate(n-2);
}

```



## 回溯算法 Backtracking 
## 深度优先 Depth First Search
## 贪心算法


## 二叉树遍历

- Binary Tree Preorder 前序 根左右 
- Binary Tree Inorder 中序 左根右
- Binary Tree Postorder 后序 左右根



## Permutation Combination Subset Two Sum ...


## System Design
