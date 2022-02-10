using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Microsoft.Easy
{
    public class ThirdMax
    {
        public int ThirdMaxElement(int[] nums)
        {
            int first = int.MinValue, second = int.MinValue, third = int.MinValue;
            foreach (int num in nums)
            {
                if(num > first)
                {
                    third = second;
                    second = first;
                    first = num;
                }else if(num > second)
                {
                    third = second;
                    second = num;
                }else if(num > third)
                {
                    third = num;
                }
            }
            if (nums.Length < 3)
                return first;
            return third;
        }

        //Top k frequent
        //map+list.sort()  :  O(nlogn)
        public int[] TopKFrequent(int[] nums, int k)
        {
            var cnt = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (cnt.ContainsKey(num))
                    cnt[num]++;
                else
                    cnt.Add(num, 1);
            }
            var rec = new List<int>();
            foreach (var item in cnt)
            {
                rec.Add(item.Key);
            }
            rec.Sort(
                delegate(int num1, int num2)
                {
                    return cnt[num1] == cnt[num2] ? num1.CompareTo(num2) : cnt[num2] - cnt[num1];
                }
                );
            return rec.GetRange(0, k).ToArray();
        }

        public int[] TopKFrequent_QSort(int[] nums, int k)
        {
            //occurences： key:nums[i], value: nums[i]出现的次数
            var occurrences = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (occurrences.ContainsKey(num))
                    occurrences[num]++;
                else
                    occurrences.Add(num, 1);
            }
            //转换成List数组形式
            var values = new List<int[]>();
            foreach (var item in occurrences)
            {
                int num = item.Key, count = item.Value;
                values.Add(new int[] { num, count });
            }
            //前k个高频元素
            var ret = new int[k];
            QSort(values, 0, values.Count - 1, ret, 0, k);
            return ret;
        }
        public void QSort(List<int[]> values, int start, int end, int[] ret, int retIndex, int k)
        {
            int p = Partition(values, start, end);
            if(k <= p - start)
            {
                QSort(values, start, p - 1, ret, retIndex, k);
            }
            else
            {
                for(int i = start; i <= p; i++)
                {
                    ret[retIndex++] = values[i][0];
                }
                if(k > p - start + 1)
                {
                    QSort(values, p + 1, end, ret, retIndex, k - (p - start + 1));
                }
            }
            
        }
        public int Partition(List<int[]> values, int start, int end)
        {
            int pivot = values[start][1];           
            int st = start, ed = end + 1;
            while (true)
            {
                while (++st <= end && values[st][1] > pivot) ;
                while (--ed >= start && values[ed][1] < pivot) ;
                if(st < ed)
                {
                    int[] temp = values[st];
                    values[st] = values[ed];
                    values[ed] = temp;
                }
                else
                {
                    break;
                }
            }
            int[] tmp = values[start];
            values[start] = values[ed];
            values[ed] = tmp;
            return ed;
        }


        public int[] TopKFrequent_BucketSort(int[] nums, int k)
        {
            int[] res = new int[k];
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                    dict[num]++;
                else
                    dict.Add(num, 1);
            }

            var list = new List<List<int>>();
            foreach (var key in dict.Keys)
            {
                int i = dict[key];
                if (list[i] == null)
                    list[i] = new List<int>();
                list[i].Add(key);
            }

            int resIndex = 0;
            for(int i = list.Count - 1; i >= 0 && resIndex < k; i--)
            {
                if (list[i] == null)
                    continue;
                //foreach (var item in list[i])
                //{
                //    res[resIndex++] = item;
                //}
                for (int j = 0; j < list[i].Count - 1 && resIndex < k; j++)
                {
                    res[resIndex++] = list[i][j];
                }

            }
            return res;
        }


        //TopK (Heap Sort) -- Min Heap


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //Max Heap Sort
        public void HeapAdjust(int[] nums, int i, int len)
        {
            //parent node index: i
            //left child node index: 2 * i + 1
            //right child node index: 2 * i + 2
            //Max Heap: the largest element if the heap is the root node element
            int left = 2 * i + 1,
                right = 2 * i + 2,
                largest = i;

            // find the largest value index among the parent, left child and right child
            if (left < len && nums[left] > nums[largest])
                largest = left;
            if (right < len && nums[right] > nums[largest])
                largest = right;
            if(largest != i)   //judge if the largest value is the parent node value
            {
                //if the largest value is not the parent node value, swap the root value and largest value
                int tmp = nums[i];
                nums[i] = nums[largest];
                nums[largest] = tmp;

                //recursively call the function to adjust the heap to a max heap
                HeapAdjust(nums, largest, len);          ///??????
            }
        }

        public void BuildMaxHeap(int[] nums, int len)
        {
            for(var i = nums.Length / 2; i >= 0; i--)
            {
                HeapAdjust(nums, i, len);
            }
        }
        public void HeapSort(int [] nums)
        {
            var len = nums.Length;
            BuildMaxHeap(nums, len);        //build heap
            for(var i = len - 1; i > 0; i--)
            {
                //swap(nums[0], nums[i]): delete max 
                int tmp = nums[0];
                nums[0] = nums[i];
                nums[i] = tmp;

                len--;
                HeapAdjust(nums, 0, len);
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

        public void PercDown(int[] nums, int start, int N)
        {
            int parent;
            int child;
            int temp = nums[start];
            for(parent = start; (parent * 2 + 1) < N; parent = child)
            {
                //left child node
                child = parent * 2 + 1;

            }



            

        }

        
        





    }
}
 