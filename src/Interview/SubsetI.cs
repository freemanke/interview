
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Interview
{
    public class SubsetI
    {
        public IList<IList<int>> Subset(int[] nums)
        {
            var result = new List<IList<int>>();
            SubsetIRecursive(nums, result, nums.Length - 1);
            return result;
        }

        public void SubsetIRecursive(int[] nums, IList<IList<int>> result, int index)
        {
            if (index < 0) return;
            if (index == 0)
            {
                result.Add(new List<int>());
                result.Add(new List<int>(new[] { nums[index] }));
                return;
            }

            SubsetIRecursive(nums, result, index - 1);
            var previousCount = result.Count;
            for (var i = 0; i < previousCount; i++)
            {
                var newList = new List<int>(result[i]);
                newList.Add(nums[index]); 
                result.Add(newList);
            }
        }

        [Fact]
        public void TestSubsetI()
        {
            var result = Subset(new[] { 1 });
            Assert.Equal(2, result.Count);
            Assert.Equal(0, result.First().Count);
            Assert.Equal(1, result.Last().Count);
            Assert.Equal(1, result.Last().First());
        }
    } 
}
