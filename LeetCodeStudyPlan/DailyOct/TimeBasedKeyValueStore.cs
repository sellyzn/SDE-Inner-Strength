using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml;

namespace LeetCodeStudyPlan.DailyOct
{
    internal class TimeBasedKeyValueStore
    {
    }
    public class TimeMap
    {
        /*
        key       timestamp   value
        "foo"        1         "bar"
                     4         "bar2"
                     4         "too1"       update
                     6         "bar3"
        "foo1"       2         "too"
                     5         "too2"
                     7         "too3"
         */
        public Dictionary<string, Dictionary<int, string>> timeMap { get; set; }

        // M is the number of set function calls,
        // N is the number of get function calls,
        // L is average length of key and value strings.
        // T: O(M * L), in each call, we store a value at (key, timestamp) location, which takes O(L) time to hash the string.
        //              Thus, for M calls overall it will take, O(M⋅L) time.
        // S: O(M * L), in each call we store one value string of length L, which takes O(L) space.
        //              Thus, for M calls we may store M unique values, so overall it may take O(M⋅L) space.
        public TimeMap()
        {
            timeMap = new Dictionary<string, Dictionary<int,string>>();
        }
        public void Set(string key, string value, int timestamp)
        {
            if (timeMap.ContainsKey(key))
            {                
                var timestampValuePair = timeMap[key];
                if (timestampValuePair.ContainsKey(timestamp))
                {
                    timestampValuePair[timestamp] = value;
                }
                else
                {                    
                    timestampValuePair.Add(timestamp, value);
                }

                timeMap[key] = timestampValuePair;
            }
            else
            {                
                var timestampValuePair = new Dictionary<int, string>();
                timestampValuePair.Add(timestamp, value);               
                timeMap.Add(key, timestampValuePair);
            }
        }

        // T: O(N * timestamp * L), in each call, we iterate linearly from timestamp to 1 which takes O(timestamp) time and again to hash the string it takes O(L) time.
        //                          Thus, for N calls overall it will take, O(N⋅timestamp⋅L) time.
        // S: O(N), we are not using any additional space. Thus, for all N calls it is a constant space operation.
        public string Get(string key, int timestamp)
        {
            if (timeMap.ContainsKey(key))
            {
                var timestampValuePairs = timeMap[key];
                //if (timestampValuePairs.ContainsKey(timestamp))
                //{
                //    return timestampValuePairs[timestamp];
                //}
                //else
                //{
                //    // find the largest timestamp_prev
                //    var largestTimestampPrev = 0;
                //    foreach(var item in timestampValuePairs)
                //    {
                //        if(item.Key < timestamp)
                //        {
                //            largestTimestampPrev = Math.Max(largestTimestampPrev, item.Key);
                //        }
                //    }
                //    return largestTimestampPrev == 0 ? "" : timestampValuePairs[largestTimestampPrev];
                //}
                for(int curTime = timestamp; curTime >= 1; curTime--)
                {
                    if(timestampValuePairs.ContainsKey(curTime))
                        return timestampValuePairs[curTime];
                }
            }
            return "";
        }
    }
}
