using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Core.Helper
{
    public class NumberFormatHelper
    {
        public static object FormatNumber(object oData, int nDecimalPointNumber)
        {
            var nData = 0m;
            if (decimal.TryParse(Convert.ToString(oData), out nData))
            {
                return decimal.Round(Convert.ToDecimal(nData), nDecimalPointNumber, MidpointRounding.AwayFromZero).ToString("#,0.".PadRight(nDecimalPointNumber + 4, '0'));
            }
            else
            {
                return oData;
            }
        }
    }
}
