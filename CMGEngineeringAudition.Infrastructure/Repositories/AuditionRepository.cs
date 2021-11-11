using CMGEngineeringAudition.Application.DTOs.AuditionDevices;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static CMGEngineeringAudition.Application.Features.Commands.Measurements;

namespace CMGEngineeringAudition.Infrastructure.Repositories
{
    public class AuditionRepository: IAuditionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        internal int lineCount;
        public AuditionRepository(IConfiguration configuration, IDistributedCache distributedCache)
        {
            _configuration = configuration;
            _distributedCache = distributedCache;
            lineCount = 0;
    }
        public MeasureReference EvaluateLogFile(string fname)
        {
            const Int32 BufferSize = 1024;
            MeasureReference measureReference = new();
            using (var stream = System.IO.File.Open(fname,FileMode.Open,FileAccess.Read))
            {
                using var streamReader = new StreamReader(stream, Encoding.UTF8, true, BufferSize);
                string[] measuresRef;
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineCount++;
                    measuresRef = line.Split(" ");
                    if (lineCount == 1)
                    {
                        measureReference.Temperature = Convert.ToDouble(measuresRef[1]);
                        measureReference.Humidity = Convert.ToDouble(measuresRef[2]);
                        measureReference.MonoxideC = Convert.ToDouble(measuresRef[3]);
                        Array.Clear(measuresRef, 0, measuresRef.Length);
                    }
                    else
                    {
                        if (IsAlpha(measuresRef[0]))
                        {
                            Device dev = new()
                            {
                                DeviceName = measuresRef[0],
                                DeviceId = measuresRef[1]
                            };
                            measureReference.Devices.Add(dev);
                            Array.Clear(measuresRef, 0, measuresRef.Length);
                        }
                        else {
                            if (IsDateTimeValid(measuresRef[0] + ":00"))
                            {
                                MeasuresDetails measuresDetail = new()
                                {
                                    ReadingTime = Convert.ToDateTime(measuresRef[0] + ":00"),
                                    Precision = Convert.ToDouble(measuresRef[1]),
                                    DeviceId = measureReference.Devices.LastOrDefault().DeviceId,
                                    Device = measureReference.Devices.LastOrDefault()
                                };
                                measureReference.Devices.LastOrDefault().Details.Add(measuresDetail);
                                Array.Clear(measuresRef, 0, measuresRef.Length);
                            }
                        }
                        
                    }
                }
            }
            return measureReference;
        }

        public bool IsAlpha(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z]+$");
        }

        public bool IsAlphaNumeric(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9]+$");
        }
        public bool IsDateTimeValid(string input)
        {
            DateTime fechaValidada;
            var formatos = new[] { "MM/dd/yyyy", "dd/mm/yyyy", "dd/MM/yyyy h:mm:ss", "MM/dd/yyyy hh:mm tt", "yyyy'-'MM'-'dd'T'HH':'mm':'ss" };
            return DateTime.TryParseExact(input, formatos, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaValidada);
        }

        public bool IsAlphaNumericWithUnderscore(string input)
        {
            return Regex.IsMatch(input, "^[a-zA-Z0-9_]+$");
        }
    }
}
