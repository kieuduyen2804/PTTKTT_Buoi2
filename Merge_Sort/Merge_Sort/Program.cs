using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 8, 4, 1, 3, 2, 5, 9 };
        Console.WriteLine("Original array:");
        PrintArray(arr);

        arr = MergeSort(arr);

        Console.WriteLine("Sorted array:");
        PrintArray(arr);
    }

    static int[] MergeSort(int[] arr)
    {
        if (arr.Length <= 1) return arr;

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                result[k++] = left[i++];
            }
            else
            {
                result[k++] = right[j++];
            }
        }

        while (i < left.Length)
        {
            result[k++] = left[i++];
        }

        while (j < right.Length)
        {
            result[k++] = right[j++];
        }

        return result;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int element in arr)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}