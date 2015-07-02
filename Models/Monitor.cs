using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JsonPerformanceTest.Models
{
    [DataContract]
    public class Monitor
    {
        [DataMember]
        public int MonitorID { get; set; }
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int? ClientDeviceId { get; set; }
        [DataMember]
        public string ResultText { get; set; }
        [DataMember]
        public double? ResultNumeric { get; set; }
        [DataMember]
        public string ResultStatus { get; set; }
        [DataMember]
        public string MonitorConfig { get; set; }
        [DataMember]
        public string ExceptionMessage { get; set; }
        [DataMember]
        public DateTimeOffset NextCheck { get; set; }
        [DataMember]
        public DateTimeOffset CheckStarted { get; set; }
        [DataMember]
        public int? ResultSeverityId { get; set; }
        [DataMember]
        public string SparkLineData { get; set; }
        [DataMember]
        public int? MonitorTypeId { get; set; }
        [DataMember]
        public int? Count { get; set; }
        [DataMember]
        public int GroupMonitorID { get; set; }
        [DataMember]
        public short? IntervalSeconds { get; set; }

    }

}
