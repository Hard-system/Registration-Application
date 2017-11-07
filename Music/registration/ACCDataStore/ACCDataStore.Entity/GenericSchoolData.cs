using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class GenericSchoolData
    {
        public GenericSchoolData(string sTopic, string sPercent)
        {
            this.Topic = sTopic;
            this.Percent = sPercent;
        }
        public GenericSchoolData()
        {

        }
        public string Topic { get; set; }
        public string Percent { get; set; }
    }
}
