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

namespace CMGEngineeringAudition.Application.Features.Commands
{
    public class EvaluateLogCommand : IRequest<Result<List<EvaluateResponse>>>
    {
        public string ContentFile { get; set; }
    }
    public class EvaluateLogCommandHandler : IRequestHandler<EvaluateLogCommand, Result<List<EvaluateResponse>>>
    {
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
                switch (item.DeviceName)
                {
                    case "thermometer":
                        double median= _mathService.Median(item.Details);
                        double stdev = _mathService.StdDev(item.Details.Select(o => o.Precision));
                        if (((orderObj.Temperature-0.5) <= median && median == (orderObj.Temperature + 0.5)) && stdev < 3)
                        {
                            EvaluateResponse responseItem= new() 
                            {
                                DeviceName = item.DeviceId,
                                Precision = "ultra precise"
                            };
                            evalResponseList.Add(responseItem);
                        }
                        


                        break;
                    case "humidity":
                        // code block
                        break;
                    case "monoxide":
                        // code block
                        break;
                    default:
                        // code block
                        break;
                }
            }
            
            return Result<List<EvaluateResponse>>.Success(evalResponseList);
        }
         
    }
}
