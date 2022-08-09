using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Contest
{
    internal class No6124
    {
        public char RepeatedCharacter(string s)
        {
            // IList<char, IList<int>>
            var index = -1;
            var map = new Dictionary<char, IList<int>>();
            for(int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    var list = new List<int>();
                    list.Add(i);
                    map[s[i]] = list;
                }
                else
                {
                    index = map[s[i]][0];
                    break;
                }
                
            }
            return s[index];
        }
        public int EqualPairs(int[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                int j = 0;
                int index = 0;
                while (index < grid.Length)
                {
                    for (j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] != grid[j][index])
                            break;
                    }
                    if (j == grid[i].Length)
                        count++;
                    index++;
                }

            }
            return count;
        }

        public long CountExcellentPairs(int[] nums, int k)
        {
            // num1 & num2
            // num1 | num2
            // 求一个二进制数中1的个数

        }
        public int GetCount(int num)
        {

        }
    }
    public class FoodRatings
    {
        public string[] Foods { get; set; }
        public string[] Cuisines { get; set; }
        public int[] Ratings { get; set; }
        
        public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
        {
            this.Foods = foods;
            this.Cuisines = cuisines;
            this.Ratings = ratings;
        }

        public void ChangeRating(string food, int newRating)
        {
            for(int i = 0; i < Foods.Length; i++)
            {
                if(Foods[i] == food)
                    Ratings[i] = newRating;
            }
        }

        public string HighestRated(string cuisine)
        {
            var index = -1;
            var highestRating = int.MinValue;
            for(int i = 0; i < Cuisines.Length; i++)
            {
                if(Cuisines[i] == cuisine)
                {
                    if(highestRating > Ratings[i])
                    {
                        highestRating = Ratings[i];
                        index = i;
                    }

                }
            }
            return Foods[index];
        }
    }
}
