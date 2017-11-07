using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACCDataStore.Core.Helper
{
    public static class StringHelper
    {
        public static string Between(this string src, string findfrom, string findto)
        {
            int start = src.IndexOf(findfrom);
            int to = src.IndexOf(findto, start + findfrom.Length);
            if (start < 0 || to < 0) return "";
            string s = src.Substring(
                           start + findfrom.Length,
                           to - start - findfrom.Length);
            return s;
        }

        public static List<string> BetweenRange(this string src, string findfrom, string findto)
        {
            var sSrc = src.Clone().ToString();
            var listResult = new List<string>();
            var nStart = 0;
            var nTo = 0;
            do
            {
                nStart = sSrc.IndexOf(findfrom);
                if (nStart < 0)
                {
                    break;
                }
                nTo = sSrc.IndexOf(findto, nStart + findfrom.Length);
                if (nStart >= 0 && nTo >= 0)
                {
                    var sResult = sSrc.Substring(
                                   nStart + findfrom.Length,
                                   nTo - nStart - findfrom.Length);
                    listResult.Add(sResult);
                    sSrc = sSrc.Substring(nTo);
                }
            }
            while (nStart >= 0 && nTo >= 0);

            return listResult;
        }
    }
}
