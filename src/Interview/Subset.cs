using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Interview
{
    public class Subset
    {
        public List<IList<int>> Subsets(int[] nums)
        {
            var n = nums.Length;
            Array.Sort(nums);
            var subsets = new List<IList<int>>(new[] { new List<int>() });

            for (var i = 0; i < n; i++)
            {
                var count = subsets.Count;
                for (var j = 0; j < count; j++)
                {
                    var newSet = new List<int>(subsets[j]);
                    newSet.Add(nums[i]);
                    subsets.Add(newSet);
                }
            }

            return subsets;
        }

        public List<IList<int>> SubSetsRecursive(int[] nums)
        {
            var result = new List<IList<int>>();
            Recursive(nums, result, new List<int>(), 0, 2);
            return result;
        }

        private void Recursive(int[] nums, List<IList<int>> result, List<int> temp, int start, int count)
        {
            var n = nums.Length;
            if (count == 0 || n -start + 1 >= count) return;

            for (var i = start; i < count;)
            {
                temp.Add(nums[i]);
                Recursive(nums, result, temp, ++i, count);
            }
        }


        [Fact]
        public void Test()
        {
            var subsets = new Subset().Subsets(new int[] { 0, 1 });
            Assert.Equal(4, subsets.Count());
            Assert.Empty(subsets[0]);
            Assert.Equal(1, subsets[1].Count());
            Assert.Equal(1, subsets[2].Count());
            Assert.Equal(2, subsets[3].Count());
        }
    }
}
