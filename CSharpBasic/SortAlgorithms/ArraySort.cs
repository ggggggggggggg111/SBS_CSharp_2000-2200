using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal static class ArraySort
    {
        /// <summary>
        /// 거품 정렬 
        /// O(N^2)
        /// Stable. 
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            int i, j;
            for (i = 0; i < arr.Length - 1; i++)
            {
                for (j = 0; j < arr.Length -1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }
        /// <summary>
        /// 선택 정렬
        /// o(N^2)
        /// Unstable
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            int i, j, minIdx;
            for ( i = 0; i <arr.Length;i++ )
            {
                minIdx = i;
                for ( j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx= j;
                }

                Swap(ref arr[i],ref arr[minIdx]);
            }
        }
        /// <summary>
        /// 삽입정렬
        /// O(N^2)
        /// Stable
        /// </summary>
        /// <param name="arr"></param>

        public static void InsertionSort(int[] arr)
        {
            int i, j;
            int key;
            for ( i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j>= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] =key;
            }
        }

        public static void MergeSort(int[] arr)
        {
            int length = arr.Length;

            for (int mergeSize = 1; mergeSize < length; mergeSize *=2)
            {
                for (int start = 0; start < length; start += 2* mergeSize)
                {
                    int mid = Math.Min(start + mergeSize - 1, length - 1);
                    int end = Math.Min( start + 2 * mergeSize - 1,length -1);

                    Merge(arr, start, mid, end);
                }
            }
        }

        private static void Merge(int[]arr,int start,int mid,int end)
        {
            int part1 = start;
            int part2 = mid +1;
            int Length1 = mid - start + 1;
            int Length2 = end - mid;

            int i, j;

            int[] copy1 = new int[Length1];
            int[] copy2 = new int[Length2];

            for ( i = 0; i < Length1; i++)
                copy1[i] = arr[start + i];
            for ( j = 0; j < Length2; j++)
                copy2[j] = arr[mid +1 + j];

            int index = start;           

            i = 0;
            j = 0;

            while (i < Length1 && j < Length2)
            {
                if (copy1[i] <= copy2[j])
                    arr[index++] = copy1[i++];
                else 
                    arr[index++] = copy2[j++];
            }

            while (i < Length1)
                arr[index++] = copy1[i++];
        }

        public static void RecursiveMergeSort(int[] arr)
        {
            RecursiveMergeSort(arr, 0, arr.Length - 1);
        }

        private static void RecursiveMergeSort(int[] arr,int start,int end)
        {
            if (start < end)
            {
                int mid =  end + (start - end) / 2 - 1;// == (start + end) /2 - 1, Overflow 방자용
                RecursiveMergeSort(arr,start, mid);
                RecursiveMergeSort(arr,mid +1, mid);

                Merge(arr,start, mid, end);
            }
        }

        

        // ref : 인자를 변수의 참조로 받아야할때 사용하는 키워드
        public static void Swap(ref int a, ref int b)
        {
            int tmp = b;
            b = a;
            a = tmp;
        }
    }
}
