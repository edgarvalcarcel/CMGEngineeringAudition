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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditionRepository _auditRepository;
        public EvaluateLogCommandHandler(IUnitOfWork unitOfWork, IAuditionRepository auditRepository)
        {
            _unitOfWork = unitOfWork;
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
                        int count = item.Details.Count;
                        var ordereddevices = item.Details.OrderBy(p => p.Precision);
                        double median = ordereddevices.ElementAt(count / 2).Precision + ordereddevices.ElementAt((count - 1) / 2).Precision;
                        median /= 2;

                        //var ordereddevicesSD = item.Details.OrderBy(p => p.Precision).Average;

                        if ((orderObj.Temperature-0.5) <= median && median == ((orderObj.Temperature + 0.5)) && )
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
