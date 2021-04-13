using System;
using System.Collections.Generic;
using System.IO;

namespace Algorithms_lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Out.WriteLine("kkkk");
            LengthLessHundredTest();
        }

        void LengthLessHundredTest()
        {
            List<string> array = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                array.Add(new string(i));
            }
        } 
    }

    public static class RadixSort
    {
        private static readonly int k = 256;
            
        public static void MakeRadixSort(List<string> array)
            => MakeRadixSort(array, 0, array.Count - 1, 0, new string[array.Count]);

        private static void MakeRadixSort(List<string> array, int left, int right, int d, string[] temp)
        {
            if (left >= right)
                return;

            var count = new int[k + 2];
            for (var i = left; i <= right; i++)
                count[Key(array[i]) + 2]++;

            for (var i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            for (var i = left; i <= right; i++)
                temp[count[Key(array[i]) + 1]++] = array[i];

            for (var i = left; i <= right; i++)
                array[i] = temp[i - left];

            for (var i = 0; i < k; i++)
                MakeRadixSort(array, left + count[i], left + count[i + 1] - 1, d + 1, temp);

            int Key(string s) => d >= s.Length ? -1 : s[d];
        }
    }

    public static class BubbleSort
    {
        public static void MakeBubbleSort(List<string> collection, Func<string, string, int> comparator = default)
        {
            if (comparator == null)
                comparator = string.CompareOrdinal;
            for (var i = 0; i < collection.Count; ++i)
            for (var j = 0; j < collection.Count - 1 - i; ++j)
                if (comparator(collection[j], collection[j + 1]) > 0)
                {
                    var temp = collection[j];
                    collection[j] = collection[j + 1];
                    collection[j + 1] = temp;
                }
        }
    }

}