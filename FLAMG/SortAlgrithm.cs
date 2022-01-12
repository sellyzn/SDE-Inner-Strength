using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG
{
    public class SortAlgrithm
    {
        
        public static int[] BubbleSort1(int[] sourceArray)
        {
            //对arr进行拷贝，不改变参数内容
            int[] arr = new int[sourceArray.Length];
            sourceArray.CopyTo(arr, 0);

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Boolean flag = false;
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                        flag = true;
                    }
                }
                if (flag == false)
                    break;
            }
            return arr;
        }

        public static void Swap(int a, int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        /******************************************************************/
        /******************************Bubble Sort*************************/
        /******************************************************************/

        /*
         * Bubble Sort:
         * 1. compare the adjacent elements. If the first element is larger than the second element, then exchange this two elements.
         * 2. for each two adjacent elements, do the same work. from the first pair elements to the last pair elements. At the result, the last element is the largest element.
         * 3. repeat the former two steps for every elements, except the last one.
         * 4. repeat step 1, 2, and 3, till the sort is completed.
         * 
         * Average Time complexity: O(n^2)
         */
        public static void BubbleSort(int[] sourceArray)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                return;
            for (int i = sourceArray.Length - 1; i >= 0; i--)
            {
                Boolean flag = false;
                for (int j = 0; j < i; j++)    //一趟冒泡
                {
                    if (sourceArray[j] > sourceArray[j + 1])
                    {
                        Swap(sourceArray[j], sourceArray[j + 1]);
                        flag = true;    //标识发生了交换
                    }
                }
                if (flag == false)    //全程无交换
                    break;
            }

        }

        /******************************************************************/
        /******************************Insert Sort*************************/
        /******************************************************************/

        /*
         * Insert Sort:
         * 1. start at the first element. this element can be can be considered as sorted.
         * 2. Get the next element, then scan the sorted element array from back to the front.
         * 3. If the sorted element is bigger than the new element, then move the sorted element to the next place.
         * 4. Repeat the step 3, untill find a sorted element which is not larger than the new element.
         * 5. Insert the new element behind the sorted element.
         * 6. repeat step 2 to step 5 untill the sort finished.
         * 
         * 
         */
        public static void InsertSort(int[] sourceArray)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                return;
            int i, j, tmp;
            for (i = 1; i < sourceArray.Length; i++)  //unsorted elements. the index of the first element, which is considered as sorted, is 0.
            {
                tmp = sourceArray[i];    //element to be inserted，取出未排序序列中的第一个元素，摸下一张牌
                for (j = i; j > 0 & sourceArray[j - 1] > tmp; j--)    //j is for scanning the sorted elements.
                {
                    sourceArray[j] = sourceArray[j - 1];     //compare with the sorted elements, and move right. 依次与已排序序列中元素比较并右移，移出空位
                }
                sourceArray[j] = tmp;    //Insert the new element to the correct place. 新牌落位
            }
        }


        /******************************************************************/
        /******************************Shell Sort**************************/
        /******************************************************************/

        /*
         * Shell Sort:
         * 1. Define an incremental sequence: Dm > Dm-1 > ... > D1 = 1.
         * 2. Do "Dk-Gap" sort for each Dk( k = m, m-1, ... ,1). Do m groups of sort
         * 3. 
         * 
         * The original incremental sequence: 
         * Hibbart incremental sequence: Dk = 2^k - 1. The adjacent elements are coprime.
         * 
         * 
         */
        public static void ShellSort(int[] sourceArray)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                return;
            for (int D = sourceArray.Length / 2; D > 0; D /= 2)    // The original Shell Sort
            {
                for (int i = D; i < sourceArray.Length; i++)    // Insert Sort
                {
                    int j;
                    int tmp = sourceArray[i];
                    for (j = i; j >= D & sourceArray[j - D] > tmp; j -= D)
                    {
                        sourceArray[j] = sourceArray[j - D];
                    }
                    sourceArray[j] = tmp;
                }
            }
        }


        /******************************************************************/
        /****************************Selection Sort************************/
        /******************************************************************/

        /*
         * Selection Sort:
         * 1. Find the minimum element in the unsorted sequence, put it in the beginning place of the sorted sequence.
         * 2. Continue to find the minimum element among the unsorted sequence, then put it in the end of the sorted sequence.
         *  
         * Average Time complexity: O(n^2) 
         * 
         */
        public static void SelectionSort(int[] sourceArray)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                return;
            for (int i = 0; i < sourceArray.Length; i++)
            {
                int minIndex = i;    //Define the place of the first element of the unsorted sequence as the index of the minimum element.
                for (int j = i + 1; j < sourceArray.Length; j++)    // Compare elements of the unsorted sequence with the original minIndex element, redefine the minIndex constantly until find the minimum element, and define the minimum element index as the final minIndex.
                {
                    if (sourceArray[j] < sourceArray[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (i != minIndex)
                {
                    int tmp = sourceArray[i];
                    sourceArray[i] = sourceArray[minIndex];
                    sourceArray[minIndex] = tmp;
                }
            }

        }


        /******************************************************************/
        /*******************************Heap Sort**************************/
        /******************************************************************/

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


        public static void BuildMaxHeap(int[] sourceArray, int len)
        {
            for (int i = sourceArray.Length / 2; i >= 0; i--)    // ??
            {
                HeapAdjust(sourceArray, i, len);
            }
        }

        public static void HeapAdjust(int[] sourceArray, int i, int len)
        {
            //parent node index: i
            //left child node index: 2 * i + 1
            //right child node index: 2 * i+ 2
            //the largest element of the heap is the root node element.
            int left = 2 * i + 1,
                right = 2 * i + 2,
                largest = i;

            // find the largest value index among the parent, left child and right child.
            if (left < len && sourceArray[left] > sourceArray[largest])
            {
                largest = left;
            }

            if (right < len && sourceArray[right] > sourceArray[largest])
            {
                largest = right;
            }

            if (largest != i)  //judge if the largest value is the parent node value 
            {
                Swap(sourceArray[i], sourceArray[largest]);    //if not, swap the value
                HeapAdjust(sourceArray, largest, len);       //recursively call the function to adjust the heap to a max heap
            }
        }

        public static void HeapSort(int[] sourceArray)
        {
            int len = sourceArray.Length;

            BuildMaxHeap(sourceArray, len);      //build heap

            for (int i = len - 1; i > 0; i--)
            {
                Swap(sourceArray[0], sourceArray[i]);    //delete max
                len--;
                HeapAdjust(sourceArray, 0, len);
            }
        }




        /*
         * 传统常规做法：
         * 如果以第 0 个位置开始标记树根节点，则第 i 个结点的左右孩子分别为：
         *   LeftChild: 2i+1
         *   RightChild: 2i+2
         * 
         * 反之，如果一个结点的标号为 i，则其父节点为：
         *   i/2：i 为左孩子结点；
         *   i/2-1：i 为右孩子结点；
         *   
         * 若换个方式存储这些根上的结点的话，比如，根节点在索引为 1，而不是为 0 的地方，这样 结点 i 的左右孩子分别为：
         *   2*i
         *   2*i+1
         *   这种方式的真正好处在于：当结点为 i 时，不论为左还是右孩子结点，其父节点总是，i/2；
        */


        /*
        public static void PercDown(int[] sourceArray, int start, int N)
        {
            //An array, which includes ]
            int Parent, Child;
            int temp = sourceArray[start];      // get the value of the root node
            for(Parent = start; (Parent * 2 + 1) < N; Parent = Child)
            {
                //left child node:
                Child = Parent * 2 + 1;
                if ((Child != N - 1) && (sourceArray[Child] < sourceArray[Child + 1]))
                    Child++;      //Child points to the larger one of left node and right node
                if (temp >= sourceArray[Child])
                    break;      //Find the correct place
                else      //
                    sourceArray[Parent] = sourceArray[Child];
            }
            sourceArray[Parent] = temp;
        }

        public static void HeapSort(int[] sourceArray)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                return;

            for(int i = sourceArray.Length / 2 - 1; i >= 0; i--)  //build max heap
            {
                PercDown(sourceArray, i, sourceArray.Length);
            }

            for(int i = sourceArray.Length - 1; i > 0; i--)
            {
                //
                Swap(sourceArray[0], sourceArray[i]);      //DeleteMax
                PercDown(sourceArray, 0, i);
            }
        }
        */






        /******************************************************************/
        /******************************Merge Sort**************************/
        /******************************************************************/

        /*
         * Merge Sort:
         * Divide and Conquer
         * **divide one sequence which length is n to two subsequences which length are n/2. 
         * **for the two subsequences, do merge sort. 
         * **merge the two sorted subsequences to one sorted sequence.
         * 
         * 
         * 1. apply for new space, which is for the merge sequence. The size is the sum of the two sorted sequence size.
         * 2. define two pointers. the original places of the two pointers are the begining index of the two sorted sequence.
         * 3. compare the two element value which pointed by the two pointers. place the smaller one to the merge place, and move the pointer to the next index.
         * 4. repeat step 3, until one of the pointers points to its sequence tail.
         * 5. copy the left elements of the other sequence to the merge sequence tail.
         * 
         * 
         */

        /***************recursive algorithm************/
        /* merge the sorted sequence sourceArray[L] ~ sourceArray[R-1] and sorted sequence sourceArray[R] ~ sourceArray[RightEnd] to one sorted sequence*/
        /* L = Left original index, R = Right original index, RightEnd = Right end index*/
        public static void Merge(int[] sourceArray, int[] TmpArray, int L, int R, int RightEnd)
        {
            int LeftEnd, Tmp, NumElements;

            LeftEnd = R - 1;    //Left end index
            Tmp = L;            //original index of the sorted sequence
            NumElements = RightEnd - L + 1;

            while (L <= LeftEnd & R <= RightEnd)
            {
                if (sourceArray[L] < sourceArray[R])
                    TmpArray[Tmp++] = sourceArray[L++];    // copy the left element to TmpArray
                else
                    TmpArray[Tmp++] = sourceArray[R++];    // copy the right element to TmpArray
            }

            while (L <= LeftEnd)
                TmpArray[Tmp++] = sourceArray[L++];      // directly copy the remainned elements of the left sequence to TmpArray
            while (R <= RightEnd)
                TmpArray[Tmp++] = sourceArray[R++];      // directly copy the remainned elements of the right sequence to TmpArray

            for (int i = 0; i < NumElements; i++, RightEnd--)
                sourceArray[RightEnd] = TmpArray[RightEnd];    // copy the TmpArray back to sourceArray
        }

        public static void Msort(int[] sourceArray, int[] TmpArray, int L, int RightEnd)
        {
            /*key recursive sort function*/
            // divide and conquer
            if (L < RightEnd)
            {
                int Center = (L + RightEnd) / 2;
                Msort(sourceArray, TmpArray, L, Center);    //recursively solve left side
                Msort(sourceArray, TmpArray, Center + 1, RightEnd);    // recursively solve right side
                Merge(sourceArray, TmpArray, L, Center + 1, RightEnd);    // Merge two sorted sequence
            }
        }

        public static void MergeSort(int[] sourceArray, int N)
        {
            int[] TmpArray = new int[sourceArray.Length];
            if (TmpArray != null)
            {
                Msort(sourceArray, TmpArray, 0, N - 1);
            }
            else
                Console.WriteLine("Insufficient space");
        }


        /*************circulation algorithm************/

        /*The Merge function is the same as the recursive algorithm, the difference is no copy back to sourceArray*/
        /*length = the length of the current sorted sub sequence*/
        public static void Merge_pass(int[] sourceArray, int[] TmpArray, int N, int length)
        {
            int i;
            for (i = 0; i <= N - 2 * length; i += 2 * length)
            {
                Merge(sourceArray, TmpArray, i, i + length, i + 2 * length - 1);
            }
            if (i + length < N)
            {
                Merge(sourceArray, TmpArray, i, i + length, N - 1);
            }
            else
            {
                for (int j = i; j < N; j++)
                {

                }

            }
        }

        public static void Merge_Sort(int[] sourceArray, int N)
        {
            int length = 1;
            int[] TmpArray = new int[sourceArray.Length];
            if (TmpArray != null)
            {
                while (length < N)
                {
                    Merge_pass(sourceArray, TmpArray, N, length);
                    length *= 2;
                    Merge_pass(TmpArray, sourceArray, N, length);
                    length *= 2;
                }
            }
            else
                Console.WriteLine("Insufficient space");
        }


        /******************************************************************/
        /******************************Quick Sort**************************/
        /******************************************************************/

        /*
         * 1. select one element as pivot
         *  ** compare the begining, center and the tail elements, swap the three elements untill the begining < center < tail.
         *  ** select the center elements as the pivot.
         *  ** swap the pivot element with the second last element.
         * 2. Partition:
         *   **resort the sequence, put all elements which are smaller than pivot to the left of the pivot, and the larger elements to the right of the pivot. 
         *   **
         * 3. recursively sort the two sub-sequences, which are the sub-sequence that smaller than the pivot and the sub-sequence that larger than the pivot.
         * 
         * 
         * 
         */


        public static int Median3(int[] sourceArray, int Left, int Right)
        {
            int Center = (Left + Right) / 2;
            if (sourceArray[Left] > sourceArray[Center])
                Swap(sourceArray[Left], sourceArray[Center]);
            if (sourceArray[Left] > sourceArray[Right])
                Swap(sourceArray[Left], sourceArray[Right]);
            if (sourceArray[Center] > sourceArray[Right])
                Swap(sourceArray[Center], sourceArray[Right]);
            /*now, sourceArray[Left] < sourceArray[Center] < sourceArray[Right]*/
            Swap(sourceArray[Center], sourceArray[Right - 1]);    //put the pivot to the right side
            /*we only need to consider sourceArray[Left+1]...sourceArray[Right -2]*/
            return sourceArray[Right - 1];    //return the pivot
        }

        public static void Qsort(int[] sourceArray, int Left, int Right)
        {/*key recursive function*/
            int Pivot, Cutoff, LowIndex, HighIndex;
            //if (Cutoff <= Right - Left)    // If the elements are enough, use quick sort algrithm 
            //{
            Pivot = Median3(sourceArray, Left, Right);    // select pivot
            LowIndex = Left; HighIndex = Right - 1;    // two pointers, the LowIndex if beginning from Left, LowIndex++. the HighIndex is begining from Right-1, HighIndex--
            while (true)       // compare sequence elements with pivot, put the smaller elements to the left of the pivot, put the larger elements to the right of the pivot.
            {
                while (sourceArray[++LowIndex] < Pivot) ;    //If the element is smaller than pivot, shift right, LowIndex++
                while (sourceArray[--HighIndex] > Pivot) ;    //If the element is larger than pivot, shift left, HighIndex--

                if (LowIndex < HighIndex)    //Jump out of the above two loop, if LowIndex < HighIndex, than swap the two element
                    Swap(sourceArray[LowIndex], sourceArray[HighIndex]);
                else
                    break;
            }
            Swap(sourceArray[LowIndex], sourceArray[Right - 1]);    //put the pivot to the correct place
            Qsort(sourceArray, Left, LowIndex - 1);    //recursively resolve the left sub-sequence
            Qsort(sourceArray, LowIndex + 1, Right);    //recursively resolve the right sub-sequence
            //}
            //else
            //    InsertionSort(sourceArray + Left, Right - Left + 1);    //If the elements are two less, than use simple sort algrithm
        }

        public static void QuickSort(int[] sourceArray, int N)
        {/*Unified interface*/
            Qsort(sourceArray, 0, N - 1);
        }



        /******************************************************************/
        /******************************Table Sort**************************/
        /******************************************************************/










        /******************************************************************/
        /****************************Counting Sort*************************/
        /******************************************************************/








        /******************************************************************/
        /******************************Bucket Sort*************************/
        /******************************************************************/










        /******************************************************************/
        /******************************Radix Sort**************************/
        /******************************************************************/












    }
}
