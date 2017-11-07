using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class PIPS
    {
        public YearInfo YearInfo;
        public List<GenericSchoolData> ListGenericSchoolStart { get; set; }
        public List<GenericSchoolData> ListGenericSchoolEnd { get; set; }
    }
}
