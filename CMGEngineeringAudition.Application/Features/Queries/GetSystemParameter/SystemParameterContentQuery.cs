using AspNetCoreHero.Results;
using AutoMapper;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter
{
    public class SystemParameterContentQuery : IRequest<Result<SystemParameterContentResponse>>
    {
        public string KeyName { get; set; }

        public class SystemParameterContentQueryHandler : IRequestHandler<SystemParameterContentQuery, Result<SystemParameterContentResponse>>
        {
            private readonly IConfigutationParameterCacheRepository SystemParameterContentCache;
            private readonly IMapper _mapper;
            public SystemParameterContentQueryHandler(IConfigutationParameterCacheRepository ordersCache, IMapper mapper, IDateTimeService dateTime)
            {
                SystemParameterContentCache = ordersCache;
                _mapper = mapper;
            }

            public async Task<Result<SystemParameterContentResponse>> Handle(SystemParameterContentQuery request, CancellationToken cancellationToken)
            { 
                DTOSystemParameter result = await SystemParameterContentCache.SystemParameterContentAsync(request);
                SystemParameterContentResponse item = _mapper.Map<SystemParameterContentResponse>(result);
                return Result<SystemParameterContentResponse>.Success(item);
            }
        }
    }

}
