using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{
    public class SelectionSort : SortBase
    {
        public override int[] Sort(int[] array, int n)
        {
            for (var i = 0; i < n - 1; i++)
            {
                int min = i;
                for (var j = i + 1; j < n; j++)
                {
                    if (array[j] < array[min]) min = j;
                }

                if (min != i)
                {
                    Swap(array, i, min);
                }
            }
            return array;
        }
    }
}
