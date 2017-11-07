 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity.SchoolProfiles.Census.Entity
{
    public class SchoolRoll
    {
        public YearInfo year {get;set;}
        public int schoolroll { get; set; }
        public int capacity { get; set; }
        public float percent { get; set; }
        public string spercent { get; set; }
 
      
    }
}
