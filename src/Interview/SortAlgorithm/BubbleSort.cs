using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{
    public class BubbleSort : SortBase
    {
        public override int[] Sort(int[] array, int n)
        {
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
            return array;
        }
    }
}
