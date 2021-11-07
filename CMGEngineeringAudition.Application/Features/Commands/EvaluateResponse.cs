using Newtonsoft.Json;
using System;

namespace CMGEngineeringAudition.Application.Features.Commands
{
    public class EvaluateResponse
    {
        public EvaluateResponse()
        {
            DeviceName = null;
            Precision = null;
        }
        [JsonProperty(PropertyName = "deviceName")]
        public String DeviceName { get; set; }
        public String Precision { get; set; }
    }
}
