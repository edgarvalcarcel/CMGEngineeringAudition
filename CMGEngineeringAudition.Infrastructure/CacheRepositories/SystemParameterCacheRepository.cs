using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.CacheRepositories
{
    class SystemParameterCacheRepository: IConfigutationParameterCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfigurationSystemPrameterRepository _orderRepository;

        public SystemParameterCacheRepository(IDistributedCache distributedCache, IConfigurationSystemPrameterRepository productRepository)
        {
            _distributedCache = distributedCache;
            _orderRepository = productRepository;
        }


        public async Task<DTOSystemParameter> SystemParameterContentAsync(SystemParameterContentQuery query)
        {
            DTOSystemParameter decisionMakers = await _orderRepository.SystemParameterContentAsync(query.KeyName);
            return decisionMakers;
        }

      
    }
}
