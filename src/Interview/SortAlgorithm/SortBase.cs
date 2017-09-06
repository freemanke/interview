using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.SortAlgorithm
{
    public abstract class SortBase : ISort
    {
        public abstract int[] Sort(int[] array, int n);
        public void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
