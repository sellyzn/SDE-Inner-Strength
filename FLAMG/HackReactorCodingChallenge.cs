using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG
{
    public class HackReactorCodingChallenge
    {
        public Dictionary<string, IList<string>> OrganizeItems(IList<Dictionary<string, string>> items)
        {
            var result = new Dictionary<string, IList<string>>();
            if (items == null)
                return result;
            // 1. 遍历items，
            // 如果result的key中包含item["category"]的值,则将item[key]对应的value添加到result[key]的value list中去
            // 如果result的key中不包含item["category"]的值， 则将item的key添加到result的key中，将item[key]对应的value，添加到result[key]的value list中去

            // 如果item是onsale， 则添加item[key]对应的value时，要将value值后面添加'($)'字符串, 
            foreach (var item in items)
            {
                if (result.Count > 0 && result.ContainsKey(item["category"]))
                {
                    if(item["onSale"] == "true")
                        result[item["category"]].Add(item["itemName"] + "($)");
                    else
                        result[item["category"]].Add(item["itemName"]);
                }
                else
                {
                    if(item["onSale"] == "true")
                        result.Add(item["category"], new List<string> { item["itemName"] + "($)" });
                    else
                        result.Add(item["category"], new List<string> { item["itemName"] });
                }                
            }
            return result;
        }
    }
}
