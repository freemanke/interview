using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{
    public class InsertionSort : SortBase
    {
        public override int[] Sort(int[] array, int n)
        {
            for (var i = 1; i < n; i++)
            {
                var current = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > current)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = current;
            }

            return array;
        }
    }
}
