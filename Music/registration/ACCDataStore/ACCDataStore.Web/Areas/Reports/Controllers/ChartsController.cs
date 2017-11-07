using ACCDataStore.Entity.RenderObject.Charts.ColumnCharts;
using ACCDataStore.Entity.RenderObject.Charts.SplineCharts;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.Reports.Controllers
{
    public class ChartsController : BaseController
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public ChartsController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Reports/Charts/GetChartsData")]
        public JsonResult GetChartsData()
        {
            try
            {
                object oResult = new
                {
                    //LineChartsData = GetLineCharts(),
                    ColumnChartsData = GetColumnCharts()
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        //private SplineCharts GetLineCharts()
        //{
        //    var eSplineCharts = new SplineCharts();
        //    eSplineCharts.SetDefault(false);
        //    eSplineCharts.title.text = "Energy Data";

        //    var listDataTable = this.rpGeneric.FindByNativeSQL("select DataDateTime, CurrentL1, VoltageL1, kW from EnergyData order by DataDateTime");
        //    eSplineCharts.options.yAxis = new List<ACCDataStore.Entity.RenderObject.Charts.SplineCharts.yAxis>();
        //    eSplineCharts.series = new List<ACCDataStore.Entity.RenderObject.Charts.SplineCharts.series>();
        //    if (listDataTable != null && listDataTable.Count > 0)
        //    {
        //        // yAxis
        //        eSplineCharts.options.yAxis.Add(new ACCDataStore.Entity.RenderObject.Charts.SplineCharts.yAxis
        //        {
        //            title = new ACCDataStore.Entity.RenderObject.Charts.Generic.title() { text = "" },
        //            opposite = false,
        //            min = null,
        //            max = null
        //        });

        //        // series
        //        var arrTagName = new string[] { "Current", "Voltage", "kW" };
        //        for (var i = 0; i < 3; i++)
        //        {
        //            var listSeries = new List<float?[]>();
        //            foreach (var rowData in listDataTable)
        //            {
        //                listSeries.Add(new float?[] { (float?)Convert.ToDateTime(rowData[0]).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds, (float?)Convert.ToDouble(rowData[i + 1]) });
        //            }

        //            eSplineCharts.series.Add(new ACCDataStore.Entity.RenderObject.Charts.SplineCharts.series()
        //            {
        //                name = arrTagName[i],
        //                lineWidth = 2,
        //                data = listSeries,
        //                visible = true
        //            });
        //        }
        //    }

        //    return eSplineCharts;
        //}

        private ColumnCharts GetColumnCharts()
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

            return eColumnCharts;
        }
    }
}