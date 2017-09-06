using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{
    public class ShellSort : SortBase
    {
        public override int[] Sort(int[] array, int n)
        {
            var gap = n / 2;
            while (1 <= gap)
            {
                for (var i = gap; i < n; i ++)
                {
                    var current = array[i];
                    int j = i - gap;
                    while (j >= 0 && array[j] > current)
                    {
                        array[j + gap] = array[j];
                        j -= gap;
                    }

                    array[j + gap] = current;
                }

                gap /= 2;
            }

            return array;
        }
    }
}
