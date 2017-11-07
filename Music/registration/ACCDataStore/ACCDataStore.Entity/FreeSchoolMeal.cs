using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.SchoolProfiles.Census.Entity
{
    public class FreeSchoolMeal
    {
        public YearInfo year { get; set; }
        public List<GenericSPFSM> ListGenericSchoolData { get; set; }
    }
}
