﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Entity
{
    public class LevelOfEnglish
    {
        public YearInfo YearInfo { get; set; }
        public List<GenericSchoolData> ListGenericSchoolData { get; set; }
    }
}
