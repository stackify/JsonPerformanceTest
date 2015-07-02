using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonPerformanceTest.Models
{
    [DataContract]
    public class Monitor2
    {
        [DataMember(Name = "id")]
        public int MonitorID { get; set; }
        [DataMember(Name = "cid")]
        public int ClientID { get; set; }
        [DataMember(Name = "cdid")]
        public int? ClientDeviceId { get; set; }
        [DataMember(Name = "rt")]
        public string ResultText { get; set; }
        [DataMember(Name = "rn")]
        public double? ResultNumeric { get; set; }
        [DataMember(Name = "rs")]
        public string ResultStatus { get; set; }
        [DataMember(Name = "mc")]
        public string MonitorConfig { get; set; }
        [DataMember(Name = "ex")]
        public string ExceptionMessage { get; set; }
        [DataMember(Name = "nc")]
        public DateTimeOffset NextCheck { get; set; }
        [DataMember(Name = "cs")]
        public DateTimeOffset CheckStarted { get; set; }
        [DataMember(Name = "sev")]
        public int? ResultSeverityId { get; set; }
        [DataMember(Name = "sp")]
        public string SparkLineData { get; set; }
        [DataMember(Name = "mt")]
        public int? MonitorTypeId { get; set; }
        [DataMember(Name = "cnt")]
        public int? Count { get; set; }
        [DataMember(Name = "gm")]
        public int GroupMonitorID { get; set; }
        [DataMember(Name = "is")]
        public short? IntervalSeconds { get; set; }

    }

}
