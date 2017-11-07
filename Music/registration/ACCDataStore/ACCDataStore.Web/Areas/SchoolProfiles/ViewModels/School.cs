using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACCDataStore.Web.Areas.SchoolProfiles.ViewModels
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public School(int SchoolID, string SchoolName) {

            this.SchoolID = SchoolID;
            this.SchoolName = SchoolName;
        }
        public School()
        {
        }
    }
}