using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Sorting
{
    public class HeapSorting
    {
        /*
         * Heap Sort:
         * 1. Build Max Heap: resort
         * 2. Heap Sort:
         * 
         * 1. Build max heap: H[0,...n-1]
         * 2. exchange the head value(the max value) and tail value of the heap.
         * 3. reduce the heap length: length--. Recal shift_down(0), to adjust the new root value to the correct place.
         * 4. repeat step 2, until the length of the heap is 1.
         * 
         */
        public void HeapAdjust(int[] arr, int i, int len)
        {
            //parent node index: i
            //left child node index: 2 * i + 1
            //right child node index: 2 * i + 2
            int left = 2 * i + 1,
                right = 2 * i + 2,
                largest = i;

            //find the largest value index among the parent, left child and right child
            if (left < len && arr[left] > arr[largest])
                largest = left;
            if (right < len && arr[right] > arr[largest])
                largest = right;
            if(largest != i)
            {
                //if the largest value is not the parent node value, swap the two value
                int tmp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = tmp;

                //recursively call the function to adjust the heap to a max heap
                HeapAdjust(arr, largest, len);    // ???why largest???
            }
        }
        public void BuildMaxHeap(int[] arr, int len)
        {
            for(int i = arr.Length / 2; i >= 0; i--)
            {
                HeapAdjust(arr, i, len);
            }
        }
        public void HeapSort(int[] arr)
        {
            var len = arr.Length;
            //build max heap
            BuildMaxHeap(arr, len);
            
            for(var i = len - 1; i >= 0; i--)
            {
                //exchange the head value(the max value) and tail value of the heap
                int tmp = arr[0];
                arr[0] = arr[i];
                arr[i] = tmp;

                //reduce the heap length
                len--;

                HeapAdjust(arr, 0, len);
            }
        }
    }
}
