using ACCDataStore.Entity.SchoolProfiles.Census.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class SchoolInfo : BaseEntity
    {
        public string SeedCode { get; set; }
        public string SchoolName { get; set; }
        public SchoolRoll SchoolRoll { get; set; }
        public List<NationalityIdentity> listNationalityIdentity { get; set; }
        public NationalityIdentity NationalityIdentity { get; set; }
        public List<LevelOfEnglish> listLevelOfEnglish { get; set; }
        public LevelOfEnglish LevelOfEnglish { get; set; }
        public List<Ethnicbackground> listEthnicbackground { get; set; }
        public Ethnicbackground Ethnicbackground { get; set; }
        public List<StudentStage> listStudentStage { get; set; }
        public StudentStage StudentStage { get; set; }
        public List<LookedAfter> listLookedAfter { get; set; }
        public LookedAfter LookedAfter { get; set; }
        public List<SPPIPS> listPIPS { get; set; }
        public SPPIPS PIPS { get; set; }
        public SPSchoolRollForecast SchoolRollForecast { get; set; }
        public List<SPInCAS> listInCASP2 { get; set; }
        public List<SPInCAS> listInCASP4 { get; set; }
        public List<SPInCAS> listInCASP6 { get; set; }
        public SPInCAS InCASP2 { get; set; }
        public SPInCAS InCASP4 { get; set; }
        public SPInCAS InCASP6 { get; set; }
        public List<SPSIMD> listSIMD { get; set; }
        public SPSIMD SIMD { get; set; }
        public List<FreeSchoolMeal> listFSM { get; set; }
    }
}
