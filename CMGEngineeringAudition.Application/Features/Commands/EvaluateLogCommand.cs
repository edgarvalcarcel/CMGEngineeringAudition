using MediatR;
using AspNetCoreHero.Results;
using System.Threading.Tasks;
using System.Threading;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using System.Collections.Generic;
using static CMGEngineeringAudition.Application.Features.Commands.Measurements;
using System.Linq;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CMGEngineeringAudition.Application.Features.Commands
{
    public class EvaluateLogCommand : IRequest<Result<List<EvaluateResponse>>>
    {
        public string ContentFile { get; set; }
    }
    public class EvaluateLogCommandHandler : IRequestHandler<EvaluateLogCommand, Result<List<EvaluateResponse>>>
    {
        private const double tempConst = 0.5;
        private readonly IAuditionRepository _auditRepository;
        private readonly IMathService _mathService;
        public EvaluateLogCommandHandler(IMathService mathService, IAuditionRepository auditRepository)
        {
            _mathService = mathService;
            _auditRepository = auditRepository;
        }
        public async Task<Result<List<EvaluateResponse>>> Handle(EvaluateLogCommand request, CancellationToken cancellationToken)
        {
            List<EvaluateResponse> evalResponseList = new();
            MeasureReference orderObj = _auditRepository.EvaluateLogFile(request.ContentFile);

            foreach (var item in orderObj.Devices)
            {
                double median = _mathService.Median(item.Details);
                double stdev = _mathService.StdDev(item.Details.Select(o => o.Precision));
                double max = _mathService.Maximum(item.Details.Select(o => o.Precision));
                double min = _mathService.Minimum(item.Details.Select(o => o.Precision));
                EvaluateResponse responseItem = new();
                responseItem.DeviceName = item.DeviceId;
                switch (item.DeviceName)
                {
                    case "thermometer":
                        responseItem.Precision = TemperaturePrecision(median, stdev, orderObj.Temperature);
                        break;
                    case "humidity":
                        responseItem.Precision = HumidityPrecision(min, max);                        
                        break;
                    case "monoxide":
                        responseItem.Precision = MonoxidePrecision(min, max, median);
                        break;
                    default:
                        responseItem.Precision = "No device";
                        break;
                }
                evalResponseList.Add(responseItem);
            }
            return Result<List<EvaluateResponse>>.Success(evalResponseList);
        }

        private string MonoxidePrecision(double min, double max, double median)
        {
            if (median - min <= 3 && median - max <=3)
            {
                return "keep";
            }
            else return "discard";
        }

        private static string HumidityPrecision(double min, double max)
        {
            if (max - min<=1)
            {
                return "keep";
            }
            else return "discard";
        }

        private static string TemperaturePrecision(double median, double stdev, double temperature)
        {
            string result;
            if ((temperature - tempConst <= median && median <= (temperature + 0.5)) && stdev < 3)
            {
                result = "ultra precise";
            }
            else if ((temperature - tempConst) <= median && median <= (temperature + 0.5) && (3 <= stdev && stdev <= 5))
            {
                result = "very precise";
            }
            else
            {
                result = "precise";
            };
            return result;
        }
    }
}
