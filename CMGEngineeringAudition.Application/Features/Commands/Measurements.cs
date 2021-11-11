using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Features.Commands
{
    public class Measurements
    {
        public class MeasuresDetails
        {
            public DateTime ReadingTime { get; set; }
            public double Precision { get; set; }
            public string DeviceId { get; set; }
            public Device Device { get; set; }
        }

        public class Device
        {
            public string DeviceId { get; set; }
            public string DeviceName { get; set; }
            public List<MeasuresDetails> Details { get; set; }
            public Device()
            {
                DeviceId = null;
                DeviceName = null;
                Details =  new List<MeasuresDetails>();
            }
        }
        public class MeasureReference
        {
            public double Temperature { get; set; }
            public double Humidity { get; set; }
            public double MonoxideC { get; set; }
            public List<Device> Devices { get; set; }
            public MeasureReference()
            {
                Temperature = 0;
                Humidity = 0;
                MonoxideC = 0; 
                Devices = new List<Device>();
            }
        }
    }
}
