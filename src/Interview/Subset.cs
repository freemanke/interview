using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Interview
{
    public class Solution
    {
        public List<IList<int>> Subsets(int[] nums)
        {
            var n = nums.Length;
            var sorted = nums.ToList();
            sorted.Sort();
            var subsets = new List<IList<int>>(new[] { new List<int>() });

            for (var i = 0; i < n; i++)
            {
                var count = subsets.Count;
                for (var j=0; j<count;j++)
                {
                    var newSet = new List<int>(subsets[j]);
                    newSet.Add(nums[i]);
                    subsets.Add(newSet);
                }
            }

            return subsets;
        }

        [Fact]
        public void Test()
        {
            foreach (var v in Subsets(new[] { 1 }))
            {
                Console.WriteLine(string.Join(',', v));
            }
        }
    }
}
