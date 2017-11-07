using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ACCDataStore.Core.Helper
{
    public class FileHelper
    {
        public static bool BackupFileWithDateTime(string sOrignalFile)
        {
            try
            {
                var sNow = DateTime.Now.ToString("yyyyMMddHHmmss", new System.Globalization.CultureInfo("en-US"));
                File.Copy(sOrignalFile, sOrignalFile + "." + sNow);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
