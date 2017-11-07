using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.SchoolProfiles.Census.Entity
{
    public class SPInCAS
    {
        public YearInfo year;
        public int yeargroup;
        public List<GenericSchoolData> ListGenericAgeDiffrence { get; set; }
        public List<GenericSchoolData> ListGenericStandardised { get; set; }
    }
}
