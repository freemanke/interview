using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Interview.SortAlgorithm
{
    public class SortTest
    {
        int[] array = new int[] { 2, 6, 5, 4, 3, 6, 8, 4, 3, 2, 2, 5, 7 };
        const string expected = "2,2,2,3,3,4,4,5,5,6,6,7,8";

       [Fact]
        public void BubbleTest()
        {
            Assert.Equal(expected, string.Join(",", new BubbleSort().Sort(new List<int>(array).ToArray(), array.Length)));
        }

        [Fact]
        public void InsertionTest()
        {
            Assert.Equal(expected, string.Join(",", new InsertionSort().Sort(new List<int>(array).ToArray(), array.Length)));
        }

        [Fact]
        public void QuickTest()
        {
            Assert.Equal(expected, string.Join(",", new QuickSort().Sort(new List<int>(array).ToArray(), array.Length)));
        }

        [Fact]
        public void SelectionTest()
        {
            Assert.Equal(expected, string.Join(",", new SelectionSort().Sort(new List<int>(array).ToArray(), array.Length)));
        }
    }
}
