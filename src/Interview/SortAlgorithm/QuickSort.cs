using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{

    public class QuickSort : SortBase
    {
        public override int[] Sort(int[] array, int n)
        {
            DoSort(array, 0, n - 1);
            return array;
        }

        private void DoSort(int[] array, int low, int high)
        {
            if (low >= high) return;

            var first = low;
            var last = high;
            var key = array[first];
            while (first < last)
            {
                while (first < last && array[last] >= key)
                {
                    last--;
                }
                array[first] = array[last];
                while (first < last && array[first] <= key)
                {
                    first++;
                }

                array[last] = array[first];
            }

            array[first] = key;
            DoSort(array, low, first - 1);
            DoSort(array, first + 1, high);

        }
    }
}
