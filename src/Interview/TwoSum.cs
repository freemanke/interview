using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    class TwoSum
    {
        public int[] TwoSumI(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return new int[] { };
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }

            return new int[] { };
        }

        /// <summary>
        /// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
        /// </summary>
        public int[] TwoSumII(int[] numbers, int target)
        {
            if (numbers == null || numbers.Length == 0) return new int[] { };
            var i = 0;
            var j = numbers.Length - 1;

            while (true)
            {
                var sum = numbers[i] + numbers[j];
                if (sum < target) i++;
                if (sum > target) j--;

                if (sum == target) return new[] { i + 1, j + 1 };
            }
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        /// <summary>
        /// https://leetcode.com/problems/two-sum-iv-input-is-a-bst/description/
        /// </summary>
        public bool FindTarget(TreeNode root, int k)
        {
            var nums = new List<int>();
            Traval(nums, root);

            var left = 0;
            var right = nums.Count - 1;
            while (left < right)
            {
                var sum = nums[left] + nums[right];
                if (sum < k) left++;
                if (sum > k) right--;
                if (sum == k) return true;
            }

            return false;
        }

        private void Traval(List<int> nums, TreeNode node)
        {
            if (node == null) return;

            Traval(nums, node.left);
            nums.Add(node.val);
            Traval(nums, node.right);
        }
    }
}
