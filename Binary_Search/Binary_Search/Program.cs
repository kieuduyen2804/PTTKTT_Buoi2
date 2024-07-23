using System;

namespace BinarySearch
{
    internal class Program
    {
        public static int BinarySearch(int[] a, int b)
        {

            int left = 0;
            int right = a.Length - 1;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (a[mid] == b)
                    return mid;
                if (a[mid] > b)
                    right = mid - 1;
                else
                    left = mid + 1;
                if (left == right)
                    return left;
            }
            return -1;

        }
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7, 9, 11, 15, 17 };
            Array.Sort(arr);
            int target = 9;
            int result = BinarySearch(arr, target);
            if (result == -1)
                Console.WriteLine("Can't found index {0} in array", target);
            else
                Console.WriteLine("Index ({0}) is found in position: {1}", target, result);
        }
    }
}