using ACCDataStore.Entity;
using ACCDataStore.Entity.RenderObject.Charts.ColumnCharts;
using ACCDataStore.Entity.RenderObject.Charts.SplineCharts;
using ACCDataStore.Entity.SchoolProfiles.Census.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Areas.SchoolProfiles.ViewModels;
using ACCDataStore.Web.Controllers;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.SchoolProfiles.Controllers
{
    public class PrimarySchoolController : BaseController
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public PrimarySchoolController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("SchoolProfiles/PrimarySchool/GetCondition")]
        public JsonResult GetCondition()
        {
            try
            {
                object oResult = null;

                oResult = new
                {
                    ListSchool = GetListSchool(rpGeneric) // all school
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        [Route("SchoolProfiles/PrimarySchool/GetSchoolData")]
        public JsonResult GetSchoolData([System.Web.Http.FromUri] List<int> listSchoolID) // get selected list of school's id
        {
            try
            {
                object oResult = null;
                var listSchool = GetListSchool(rpGeneric);

                oResult = new
                {
                    ListSchool = listSchool, // all school
                    ListSchoolSelected = listSchoolID != null && listSchoolID.Count > 0 ? listSchool.Where(x => listSchoolID.Contains(x.SchoolID)) : null, // set selected list of school
                    ListingData = GetSchoolData(),
                    LineChartsData = GetLineCharts(GetSchoolData()),
                    //ColumnChartsData = GetColumnCharts() // charts data
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        [Route("SchoolProfiles/PrimarySchool/GetData")]
        public JsonResult GetData([System.Web.Http.FromUri] List<int> listSchoolID) // get selected list of school's id
        {
            try
            {
                object oResult = null;
                var listSchool = GetListSchool(rpGeneric);

                oResult = new
                {
                    ListSchool = listSchool, // all school
                    ListSchoolSelected = listSchoolID != null && listSchoolID.Count > 0 ? listSchool.Where(x => listSchoolID.Contains(x.SchoolID)) : null, // set selected list of school
                    ListingData = GetListingDataJson(GetListingData()), // table data
                    ColumnChartsData = GetColumnCharts() // charts data
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        private List<School> GetListSchool(IGenericRepository rpGeneric)
        {
            var listResult = rpGeneric.FindByNativeSQL("Select * from user");

            List<School> listdata = new List<School>();
            School temp = null;

            if (listResult != null)
            {
                foreach (var itemRow in listResult)
                {
                    if (itemRow != null)
                    {
                        temp = new School(1, "test");
                        listdata.Add(temp);
                    }
                }
            }
            //return listdata.OrderBy(x => x.SchoolName).ToList();

            return new List<School>()
                {
                    new School() { SchoolID = 1, SchoolName = "School 1" },
                    new School() { SchoolID = 2, SchoolName = "School 2" },
                    new School() { SchoolID = 3, SchoolName = "School 3" },
                    new School() { SchoolID = 4, SchoolName = "School 4" },
                    new School() { SchoolID = 5, SchoolName = "School 5" }
                };
        }

        private object GetListingDataJson(DataTable dtListingData) // convert datatable to json
        {
            return new List<object>(dtListingData.AsEnumerable().Select(x => new
            {
                DateTime = x.Field<DateTime>(0),
                Current = x.Field<double>(1),
                Voltage = x.Field<double>(2),
                kW = x.Field<double>(3)
            }));
        }

        private List<SchoolInfo> GetSchoolData()
        {
            return new List<SchoolInfo>()
            {
                new SchoolInfo()
                {
                    SeedCode = "5230624",
                    SchoolName = "School 1",
                    SchoolRoll = new SchoolRoll(),
                    listNationalityIdentity = new List<NationalityIdentity>(),
                    NationalityIdentity = new NationalityIdentity(),
                    listLevelOfEnglish = new List<LevelOfEnglish>(),
                    LevelOfEnglish = new LevelOfEnglish(),
                    Ethnicbackground = new Ethnicbackground(),
                    listEthnicbackground = new List<Ethnicbackground>(),
                    StudentStage = new StudentStage(),
                    listStudentStage = new List<StudentStage>(),
                    LookedAfter = new LookedAfter(),
                    listLookedAfter = new List<LookedAfter>(),

                    PIPS = new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2016
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "1.1"),
                            new GenericSchoolData("Math", "2.1"),
                            new GenericSchoolData("Phonics", "3.1"),
                            new GenericSchoolData("Total", "4.1")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "43"),
                            new GenericSchoolData("Math", "43"),
                            new GenericSchoolData("Phonics", "43"),
                            new GenericSchoolData("Total", "43")
                        }

                    },
                    listPIPS = new List<SPPIPS>()
                    {
                       new SPPIPS()
                        {
                            year = new YearInfo()
                            {
                                Year = 2016
                            },
                            ListGenericSchoolStart = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "1.1"),
                                new GenericSchoolData("Math", "2.1"),
                                new GenericSchoolData("Phonics", "3.1"),
                                new GenericSchoolData("Total", "4.1")
                            },
                            ListGenericSchoolEnd = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "43"),
                                new GenericSchoolData("Math", "43"),
                                new GenericSchoolData("Phonics", "43"),
                                new GenericSchoolData("Total", "43")
                            }

                        },
                        new SPPIPS()
                        {
                            year = new YearInfo()
                            {
                                Year = 2015
                            },
                            ListGenericSchoolStart = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "1.1"),
                                new GenericSchoolData("Math", "2.1"),
                                new GenericSchoolData("Phonics", "3.1"),
                                new GenericSchoolData("Total", "4.1")
                            },
                            ListGenericSchoolEnd = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "42"),
                                new GenericSchoolData("Math", "42"),
                                new GenericSchoolData("Phonics", "42"),
                                new GenericSchoolData("Total", "41")
                            }

                        },
                       new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2014
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "1.1"),
                            new GenericSchoolData("Math", "2.1"),
                            new GenericSchoolData("Phonics", "3.1"),
                            new GenericSchoolData("Total", "4.1")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "40"),
                            new GenericSchoolData("Math", "40"),
                            new GenericSchoolData("Phonics", "40"),
                            new GenericSchoolData("Total", "40")
                        }

                    },
                        new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2013
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "55"),
                            new GenericSchoolData("Math", "55"),
                            new GenericSchoolData("Phonics", "55"),
                            new GenericSchoolData("Total", "55")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "55"),
                            new GenericSchoolData("Math", "55"),
                            new GenericSchoolData("Phonics", "46"),
                            new GenericSchoolData("Total", "40")
                        }

                    },                    
                    },
                    SchoolRollForecast = new SPSchoolRollForecast(),
                    InCASP2 = new SPInCAS(),
                    InCASP4 = new SPInCAS(),
                    InCASP6 = new SPInCAS(),
                    listInCASP2 = new List<SPInCAS>(),
                    listInCASP4 = new List<SPInCAS>(),
                    listInCASP6 = new List<SPInCAS>(),
                    SIMD = new SPSIMD(),
                    listSIMD = new List<SPSIMD>(),
                    listFSM = new List<FreeSchoolMeal>()
                },
                new SchoolInfo()
                {
                    SeedCode = "1002",
                    SchoolName = "Aberdeen Primary",
                    SchoolRoll = new SchoolRoll(),
                    listNationalityIdentity = new List<NationalityIdentity>(),
                    NationalityIdentity = new NationalityIdentity(),
                    listLevelOfEnglish = new List<LevelOfEnglish>(),
                    LevelOfEnglish = new LevelOfEnglish(),
                    Ethnicbackground = new Ethnicbackground(),
                    listEthnicbackground = new List<Ethnicbackground>(),
                    StudentStage = new StudentStage(),
                    listStudentStage = new List<StudentStage>(),
                    LookedAfter = new LookedAfter(),
                    listLookedAfter = new List<LookedAfter>(),

                    PIPS = new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2016
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "1.1"),
                            new GenericSchoolData("Math", "2.1"),
                            new GenericSchoolData("Phonics", "3.1"),
                            new GenericSchoolData("Total", "4.1")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "43"),
                            new GenericSchoolData("Math", "43"),
                            new GenericSchoolData("Phonics", "43"),
                            new GenericSchoolData("Total", "43")
                        }

                    },
                    listPIPS = new List<SPPIPS>()
                    {
                       new SPPIPS()
                        {
                            year = new YearInfo()
                            {
                                Year = 2016
                            },
                            ListGenericSchoolStart = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "1.1"),
                                new GenericSchoolData("Math", "2.1"),
                                new GenericSchoolData("Phonics", "3.1"),
                                new GenericSchoolData("Total", "4.1")
                            },
                            ListGenericSchoolEnd = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "43"),
                                new GenericSchoolData("Math", "43"),
                                new GenericSchoolData("Phonics", "43"),
                                new GenericSchoolData("Total", "43")
                            }

                        },
                        new SPPIPS()
                        {
                            year = new YearInfo()
                            {
                                Year = 2015
                            },
                            ListGenericSchoolStart = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "1.1"),
                                new GenericSchoolData("Math", "2.1"),
                                new GenericSchoolData("Phonics", "3.1"),
                                new GenericSchoolData("Total", "4.1")
                            },
                            ListGenericSchoolEnd = new List<GenericSchoolData>()
                            {
                                new GenericSchoolData("Reading", "42"),
                                new GenericSchoolData("Math", "42"),
                                new GenericSchoolData("Phonics", "42"),
                                new GenericSchoolData("Total", "41")
                            }

                        },
                       new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2014
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "155"),
                            new GenericSchoolData("Math", "5.1"),
                            new GenericSchoolData("Phonics", "8.2"),
                            new GenericSchoolData("Total", "4.1")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "35"),
                            new GenericSchoolData("Math", "35"),
                            new GenericSchoolData("Phonics", "4350"),
                            new GenericSchoolData("Total", "35")
                        }

                    },
                        new SPPIPS()
                    {
                        year = new YearInfo()
                        {
                            Year = 2013
                        },
                        ListGenericSchoolStart = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "33"),
                            new GenericSchoolData("Math", "33"),
                            new GenericSchoolData("Phonics", "33"),
                            new GenericSchoolData("Total", "33")
                        },
                        ListGenericSchoolEnd = new List<GenericSchoolData>()
                        {
                            new GenericSchoolData("Reading", "2"),
                            new GenericSchoolData("Math", "22"),
                            new GenericSchoolData("Phonics", "22"),
                            new GenericSchoolData("Total", "22")
                        }

                    },                    
                    },
                    SchoolRollForecast = new SPSchoolRollForecast(),
                    InCASP2 = new SPInCAS(),
                    InCASP4 = new SPInCAS(),
                    InCASP6 = new SPInCAS(),
                    listInCASP2 = new List<SPInCAS>(),
                    listInCASP4 = new List<SPInCAS>(),
                    listInCASP6 = new List<SPInCAS>(),
                    SIMD = new SPSIMD(),
                    listSIMD = new List<SPSIMD>(),
                    listFSM = new List<FreeSchoolMeal>()
                }
            };
        }

        private DataTable GetListingData() // query from database and return datatable object
        {
            var dtListingData = new DataTable();
            var listResult = this.rpGeneric.FindByNativeSQL("select DataDateTime, CurrentL1, VoltageL1, kW from EnergyData order by DataDateTime");
            if (listResult != null && listResult.Count > 0)
            {
                dtListingData.Columns.Add("DateTime", typeof(DateTime));
                dtListingData.Columns.Add("Current", typeof(double));
                dtListingData.Columns.Add("Voltage", typeof(double));
                dtListingData.Columns.Add("kW", typeof(double));

                foreach (var rowData in listResult)
                {
                    dtListingData.Rows.Add(Convert.ToDateTime(rowData[0]), Convert.ToDouble(rowData[1]), Convert.ToDouble(rowData[2]), Convert.ToDouble(rowData[3]));
                }
            }

            return dtListingData;
        }

        private ColumnCharts GetColumnCharts() // query from database and return charts object
        {
            var eColumnCharts = new ColumnCharts();
            eColumnCharts.SetDefault(false);
            eColumnCharts.title.text = "Energy Hourly";

            var listResult = rpGeneric.FindByNativeSQL("select DataDateTime, kWh_consume, kW from EnergyDataSummary where AggregateType = 3 group by strftime('%Y-%m-%d %H:00:00', DataDateTime) order by DataDateTime");
            eColumnCharts.series = new List<ACCDataStore.Entity.RenderObject.Charts.ColumnCharts.series>();
            if (listResult != null && listResult.Count > 0)
            {
                eColumnCharts.xAxis.categories = listResult.Select(x => Convert.ToDateTime(x[0]).ToString("HH:mm", new System.Globalization.CultureInfo("en-US"))).ToList();
                var arrTagName = new string[] { "kWh", "kW" };
                for (var i = 0; i < 2; i++)
                {
                    eColumnCharts.series.Add(new ACCDataStore.Entity.RenderObject.Charts.ColumnCharts.series()
                    {
                        name = arrTagName[i],
                        data = listResult.Select(x => (float?)Convert.ToDouble(x[i + 1])).ToList(),
                    });
                }
            }

            eColumnCharts.options.chart.options3d = new Entity.RenderObject.Charts.Generic.options3d() { enabled = true, alpha = 10, beta = 10 }; // enable 3d charts

            return eColumnCharts;
        }

        private SplineCharts GetLineCharts(List<SchoolInfo> listSchoolInfo)
        {
            var eSplineCharts = new SplineCharts();
            eSplineCharts.SetDefault(false);
            eSplineCharts.title.text = "PIPS";
            eSplineCharts.series = new List<ACCDataStore.Entity.RenderObject.Charts.SplineCharts.series>();

            if (listSchoolInfo != null && listSchoolInfo.Count > 0)
            {
                eSplineCharts.xAxis.categories = listSchoolInfo[0].listPIPS.Select(x => x.year.ToString()).ToList(); // year on xAxis
                eSplineCharts.yAxis.title = new Entity.RenderObject.Charts.Generic.title() { text = "Percent" };

                foreach (var eSchoolInfo in listSchoolInfo)
                {
                    var listSeries = eSchoolInfo.listPIPS.Select(x => (float?)float.Parse(x.ListGenericSchoolStart[0].Percent)).ToList(); // get only topic 1

                    eSplineCharts.series.Add(new ACCDataStore.Entity.RenderObject.Charts.SplineCharts.series()
                    {
                        name = eSchoolInfo.SchoolName,
                        color = "#ff0000",
                        lineWidth = 2,
                        data = listSeries,
                        visible = true
                    });
                }
            }

            //eSplineCharts.options.chart.options3d = new Entity.RenderObject.Charts.Generic.options3d() { enabled = true, alpha = 10, beta = 10 }; // enable 3d charts

            return eSplineCharts;
        }
    }
}