using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACCDataStore.Entity.RenderObject.Charts.Generic;

namespace ACCDataStore.Entity.RenderObject.Charts.SplineCharts
{
    public class SplineCharts : BaseRenderObject
    {
        public options options { get; set; }
        public chart chart { get; set; }
        public title title { get; set; }
        public xAxis xAxis { get; set; }
        public yAxis yAxis { get; set; }
        public tooltip tooltip { get; set; }
        public plotOptions plotOptions { get; set; }
        public List<series> series { get; set; }
        public credits credits { get; set; }

        public void SetDefault(bool bIsCreateConfigFile)
        {
            this.chart = new chart()
            {
                type = "spline",
                zoomType = ""
            };

            this.title = new title()
            {
                text = ""
            };

            this.xAxis = new xAxis()
            {
                categories = null
            };

            this.yAxis = new yAxis()
            {
                title = new title()
                {
                    text = ""
                }
            };

            this.tooltip = new tooltip()
            {
                headerFormat = @"<b>{point.key:%a, %e %b %Y %H:%M:%S}</b><br>",
                crosshairs = new crosshairs() { dashStyle = "solid" },
                shared = true
            };

            this.plotOptions = new plotOptions()
            {
                spline = new spline() { animation = true, marker = new marker() { enabled = false } }
            };

            this.series = null;

            this.credits = new credits()
            {
                enabled = false
            };

            // hightcharts-ng need this
            this.options = new options()
            {
                chart = this.chart,
                plotOptions = this.plotOptions,
                tooltip = this.tooltip,
            };

            if (bIsCreateConfigFile)
            {
                CreateConfigFile("SplineCharts.xml");
            }
        }
    }
}
