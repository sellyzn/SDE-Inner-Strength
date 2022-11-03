namespace LeetCodeStudyPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double MAX_LOAD_FACTOR = 0.67;
            int size = 8;
            int length = 13;
            var res1 = (double)(size + 1) / length;
            bool res = (size + 1) / length > 0.67;
            Console.WriteLine(res);
            Console.WriteLine(res1);
        }
        public static void lsdRadixSort(int[] arr)
        {
            // WRITE YOUR CODE HERE (DO NOT MODIFY METHOD HEADER)!
            int maxPos = 10;
            int len = arr.Length;
            IList<int>[] radixArray = new List<int>[10]; //分为0~9的序列空间

            // allocation分配过程
            for (int pos = 1; pos <= maxPos; pos++) // 从各位开始到最高位数
            {                
                for (int i = 0; i < len; i++) 
                {
                    int num = getNumInPos(arr[i], pos);
                    radixArray[num].Add(arr[i]);
                }

                // collection收集
                for (int i = 0, j = 0; i < 10; i++) {
                    while (radixArray[i] != null)
                    {
                        arr[j++] = radixArray[i][0]; // 取首部元素依次插入原数组
                        radixArray[i].RemoveAt(0); // 移除首部元素
                    }
                }
            }

        }
        private static int getNumInPos(int num, int pos)
        {
            int temp = 1;
            for (int i = 0; i < pos - 1; i++)
            {
                temp *= 10;
            }
            return (num / temp) % 10;
        }






        ///**
        // * 基数排序: LSD(最低位)法
        // */
        //private static int[] radixSortByLSD(int[] array)
        //{
        //    int radix = 10;     // 基数（数位的取值范围为[0,9]）
        //    int size = array.length;
        //    int[] sortedArray = new int[size];  // 排序结果数组

        //    // 计算待排序元素的最大位数 d
        //    int maxDigits = -1;
        //    for (int element : array)
        //    {
        //        maxDigits = Math.max(getDigits(element), maxDigits);
        //    }

        //    // 从最低位开始遍历排序(计数排序)直到最高位为止
        //    for (int i = 1; i <= maxDigits; i++)
        //    {
        //        // 对元素指定位i上的数进行计数排序
        //        int[] counts = new int[radix]; // 创建次数统计数组
        //                                       // 统计次数
        //        for (int element : array)
        //        {
        //            // 获取排序元素第i位上的数
        //            int num = getNumberByIndex(element, i);
        //            counts[num]++;
        //        }
        //        // 计算统计数组的累加值
        //        for (int j = 1; j < radix; j++)
        //        {
        //            counts[j] = counts[j - 1] + counts[j];
        //        }
        //        // 倒序遍历排序数组，保证稳定性
        //        for (int j = size - 1; j >= 0; j--)
        //        {
        //            // 获取排序元素第i位上的数
        //            int num = getNumberByIndex(array[j], i);
        //            // 该排序元素在对第i位进行计数排序后的排序位置, 因为数组索引从0开始计算，故应对排序位置减1
        //            int sortIndex = counts[num] - 1;
        //            // 将原数组元素放入排序后的位置上
        //            sortedArray[sortIndex] = array[j];
        //            // 下一个重复的元素，应排前一个位置，以保证稳定性
        //            counts[num]--;
        //        }
        //        array = sortedArray.clone();    // 本次排序结果用于下一次计数排序
        //    }
        //    return array;
        //}

        ///**
        // * 计算整数位数
        // * @param num
        // * @return
        // */
        //private static int getDigits(int num)
        //{
        //    if (num == 0)
        //    {
        //        return 1;
        //    }
        //    int digits = (int)Math.log10(num) + 1;
        //    return digits;
        //}

        ///**
        // * 取出num中某一数位上的数
        // * @param num
        // * @param index 1: 个位; 2: 十位; 3: 百位...
        // * @return
        // */
        //private static int getNumberByIndex(int num, int index)
        //{
        //    int digits = getDigits(num);
        //    if (index > digits)
        //    {
        //        return 0;   // num不足指定位数，则使用前导零填充
        //    }
        //    int numInIndex = num / (int)Math.pow(10, index - 1) % 10;
        //    return numInIndex;
        //}


        public int[] SortArray(int[] nums)
        {
            int min = 0;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                min = min < nums[i] ? min : nums[i];
                max = max > nums[i] ? max : nums[i];
            }
            min = -1 * min;
            max += min;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] += min;
            }

            int k = 1;
            while (true)
            {
                int[] count = new int[10];
                int[] ans = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    int temp = nums[i] / k;
                    temp = temp % 10;
                    count[temp]++;
                }
                for (int i = 1; i <= 9; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    ans[count[nums[i] / k % 10] - 1] = nums[i];
                    count[nums[i] / k % 10]--;
                }
                nums = ans;
                if (max / k == 0)
                {
                    break;
                }
                k *= 10;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] -= min;
            }
            return nums;
        }
    }
}