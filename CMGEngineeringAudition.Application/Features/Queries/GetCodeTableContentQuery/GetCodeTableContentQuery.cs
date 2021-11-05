using AspNetCoreHero.Results;
using AutoMapper;
using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery;

namespace CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery
{
    public class GetCodeTableContentQuery : IRequest<Result<GetCodeTableContentResponse>>
    {
        public string CodeTableName { get; set; }
        public class GetCodeTableContentQueryHandler : IRequestHandler<GetCodeTableContentQuery, Result<GetCodeTableContentResponse>>
        {
            private readonly IConfigurationCacheRepository codeTableContentCache;
            private readonly IMapper _mapper;
            public GetCodeTableContentQueryHandler(IConfigurationCacheRepository ordersCache, IMapper mapper, IDateTimeService dateTime)
            {
                codeTableContentCache = ordersCache;
                _mapper = mapper;
            }
          
            public async Task<Result<GetCodeTableContentResponse>> Handle(GetCodeTableContentQuery request, CancellationToken cancellationToken)
            {
                GetCodeTableContentResponse mappedCodeTableContent = new GetCodeTableContentResponse
                {
                    CodeTableItems = new List<CodeTableItem>()
                };

                List<DTOCodeTableContent>decisionMakersItems = await codeTableContentCache.GetCodeTableContentAsync(request);
                for (var i = 0; i < decisionMakersItems.Count; i++)
                {
                    CodeTableItem item = _mapper.Map<CodeTableItem>(decisionMakersItems[i]);
                    mappedCodeTableContent.CodeTableItems.Add(item);
                }
                return Result<GetCodeTableContentResponse>.Success(mappedCodeTableContent);
            }
        }
    }
}
