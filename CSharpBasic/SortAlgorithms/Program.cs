﻿using System.Diagnostics;
using System.Linq;

namespace SortAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random random= new Random();
            int[] arr// = { 1, 4, 3, 3, 9, 8, 7, 2, 5, 0};
                      = Enumerable
                             .Repeat(0, 10000000)
                             .Select(i => random.Next(0, 10000000))
                             .ToArray();
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            //ArraySort.BubbleSort(arr);  
            //ArraySort.SelectionSort(arr);
            //ArraySort.InsertionSort(arr);
            //ArraySort.MergeSort(arr);
            ArraySort.RecursiveMergeSort(arr);
            Console.WriteLine($"소요시간 : {stopwatch.ElapsedMilliseconds}");

            //Console.Write("Result : ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.Write($"{arr[i]}, ");
            //}
            
        }
    }
}