using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Silver.SilverII
{
    public class SortColorsII
    {
        // Count sort
        // Time: O(n)
        // Space: O(k)
        public void SortColors2(int[] colors, int k)
        {
            var count = new int[k + 1];
            foreach (var color in colors)
            {
                count[color]++;
            }
            int index = 0;
            for (int color = 1; color <= k; color++)
            {
                for (int t = 0; t < count[color]; t++)
                {
                    colors[index++] = color;
                }
            }
        }



        // k次partition, 每次划分出一种颜色
        // Time: O(nk)
        // Space: O(1)

        public void SortColors2_kPartition(int[] colors, int k)
        {
            if (colors == null || colors.Length == 0)
                return;
            int start = 0;
            for(int c = 1; c <= k; c++)
            {
                start = partition(colors, start, colors.Length - 1, c);
            }
        }

        private int partition(int[] colors, int start, int end, int c)
        {
            int tmp = colors[start];

            int left = start, right = end;
            while (left < right)
            {
                while (left < right && colors[right] != c)
                {
                    right--;
                }
                if (left < right)
                {
                    colors[left++] = colors[right];
                }

                while (left < right && colors[left] == c)
                {
                    left++;
                }
                if (left < right)
                {
                    colors[right--] = colors[left];
                }
            }
            colors[left] = tmp;

            if (tmp == c)
            {
                return left + 1;
            }
            else
            {
                return left;
            }
        }


        // Divide and Conquer
        // logk次partition （最优）
        // Time: O(nlogk)
        // Space: O(logk)


        public void SortColors2_DC(int[] colors, int k)
        {
            if (colors == null || colors.Length == 0)
                return;
            rainbowSort(colors, 0, colors.Length - 1, 1, k);
        }

        private void rainbowSort(int[] colors, int start, int end, int minColor, int maxColor)
        {
            if (start >= end || minColor == maxColor)
            {
                return;
            }

            int tmp = colors[start];

            int midColor = minColor + (maxColor - minColor) / 2;
            int left = start, right = end;
            while (left < right)
            {
                while (left < right && colors[right] > midColor)
                {
                    right--;
                }
                if (left < right)
                {
                    colors[left++] = colors[right];
                }

                while (left < right && colors[left] <= midColor)
                {
                    left++;
                }
                if (left < right)
                {
                    colors[right--] = colors[left];
                }
            }

            colors[left] = tmp;
            int partition = tmp <= midColor ? left : left - 1;

            rainbowSort(colors, start, partition, minColor, midColor);
            rainbowSort(colors, partition + 1, end, midColor + 1, maxColor);
        }

    }
}
