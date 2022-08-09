using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLAMG.Expedia
{
    internal class No468_ValidateIPAdress
    {
        public string ValidIPAddress(string queryIP)
        {
            if (queryIP.IndexOf(".") >= 0 && CheckIPv4(queryIP))
                return "IPv4";
            if (queryIP.IndexOf(":") >= 0 && CheckIPv6(queryIP))
                return "IPv6";
            return "Neither";
        }
        public bool CheckIPv4(string queryIP)
        {
            var queryIPArr = queryIP.Split(".");
            if (queryIPArr.Length != 4)
                return false;
            foreach (var str in queryIPArr)
            {
                if (str == null || str.Length == 0)
                    return false;
                if (str.Length > 3)
                    return false;
                foreach (var ch in str)
                {
                    if (!char.IsDigit(ch))
                        return false;
                }
                if (int.Parse(str) > 255)
                    return false;
                if (str.Length > 1 && str[0] == '0')
                    return false;
            }
            return true;
        }
        public bool CheckIPv6(string queryIP)
        {
            var queryIPArr = queryIP.Split(':');
            if (queryIPArr.Length != 8)
                return false;
            foreach (var str in queryIPArr)
            {
                if (str == null || str.Length == 0)
                    return false;
                if (str.Length > 4)
                    return false;
                foreach (var ch in str)
                {
                    if (!(ch  >= 'a' && ch  <= 'f') && !(ch >= 'A' && ch <= 'F') && !char.IsDigit(ch))
                        return false;
                }
            }
            return true;
        }
    }
}
