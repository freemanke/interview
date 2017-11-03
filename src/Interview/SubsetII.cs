using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Interview
{
    public class SubsetII
    {
        public IList<IList<int>> Subset(int[] nums)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();
            var counter = new Dictionary<int, int>();
            Recursive(nums, result, nums.Length, counter);
            return result;
        }

        public void Recursive(int[] nums, IList<IList<int>> result, int count, Dictionary<int,int> counter)
        {
            if (count < 1) return;
            if (count == 1)
            {
                result.Add(new List<int>());
                result.Add(new List<int>(new[] { nums[count] }));
                counter.Add(0, 2);
                return;
            }

            Recursive(nums, result, count - 1, counter);
            var previousCount = result.Count;
            var index = count - 1;
            var start = nums[index] != nums[index - 1] ? 0 : index>=2? counter[index - 2]:1;

            for (var i = start; i < previousCount; i++)
            {
                var newList = new List<int>(result[i]);
                newList.Add(nums[index]);
                result.Add(newList);
            }

            counter.Add(counter.Count, result.Count);
        }

        [Fact]
        public void Test2()
        {
            var result = Subset(new[] { 1, 1 }); // [] [1] [1,1]
            Assert.Equal(3, result.Count);
            Assert.Equal(0, result[0].Count);
            Assert.Equal(1, result[1].Count);
            Assert.Equal(2, result[2].Count);

            result = Subset(new[] { 1, 1, 2, 2 }); // [] [1] [1,1] [2] [1,2] [1,1,2] [2,2] [1,2,2] [1,1,2,2]
            Assert.Equal(9, result.Count);
            Assert.Equal(0, result[0].Count);
            Assert.Equal(1, result[1].Count);
            Assert.Equal(2, result[2].Count);
            Assert.Equal(1, result[3].Count);
            Assert.Equal(2, result[4].Count);
            Assert.Equal(3, result[5].Count);
            Assert.Equal(2, result[6].Count);
            Assert.Equal(3, result[7].Count);
            Assert.Equal(4, result[8].Count);
        }

        [Fact]
        public void Test4()
        {
            var result = Subset(new[] { 1, 1, 2, 2 }); // [] [1] [1,1] [2] [1,2] [1,1,2] [2,2] [1,2,2] [1,1,2,2]
            Assert.Equal(9, result.Count);
            Assert.Equal(0, result[0].Count);
            Assert.Equal(1, result[1].Count);
            Assert.Equal(2, result[2].Count);
            Assert.Equal(1, result[3].Count);
            Assert.Equal(2, result[4].Count);
            Assert.Equal(3, result[5].Count);
            Assert.Equal(2, result[6].Count);
            Assert.Equal(3, result[7].Count);
            Assert.Equal(4, result[8].Count);
        }
    } 
}
