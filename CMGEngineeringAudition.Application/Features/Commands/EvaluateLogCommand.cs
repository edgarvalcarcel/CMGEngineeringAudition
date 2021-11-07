using MediatR;
using AspNetCoreHero.Results;
using System.Threading.Tasks;
using System.Threading;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using System.Collections.Generic;

namespace CMGEngineeringAudition.Application.Features.Commands
{
    public class EvaluateLogCommand : IRequest<Result<EvaluateResponse>>
    {
        public string ContentFile { get; set; }
    }
    public class EvaluateLogCommandHandler : IRequestHandler<EvaluateLogCommand, Result<EvaluateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditionRepository _auditRepository;
        public EvaluateLogCommandHandler(IUnitOfWork unitOfWork, IAuditionRepository auditRepository)
        {
            _unitOfWork = unitOfWork;
            _auditRepository = auditRepository;
        }
        public async Task<Result<EvaluateResponse>> Handle(EvaluateLogCommand request, CancellationToken cancellationToken)
        {
            var orderObj =  _auditRepository.EvaluateLogFile(request.ContentFile);
            EvaluateResponse evaluateResponse = new();
            return Result<EvaluateResponse>.Success();
        }
    }
}
