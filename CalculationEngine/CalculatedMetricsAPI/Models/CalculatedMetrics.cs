using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatedMetricsAPI.Models
{
    public class CalculatedMetrics
    {
        public int CalMetricID { get; set; }
        public String Value { get; set; }
        public String Name { get; set; }
        public String Timestamp { get; set; }
        public int DeviceType { get; set; }
        public bool Old { get; set; }
    }
}