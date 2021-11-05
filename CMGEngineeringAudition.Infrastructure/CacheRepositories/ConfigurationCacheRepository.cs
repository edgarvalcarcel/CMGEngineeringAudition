using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Infrastructure.CacheKeys;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.CacheRepositories
{
    public class ConfigurationCacheRepository : IConfigurationCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IConfigurationRepository _orderRepository;

        public ConfigurationCacheRepository(IDistributedCache distributedCache, IConfigurationRepository productRepository)
        {
            _distributedCache = distributedCache;
            _orderRepository = productRepository;
        }

        public async Task<List<DTOCodeTableContent>> GetCodeTableContentAsync(GetCodeTableContentQuery query)
        {
            var decisionMakers = await _orderRepository.GetCodeTableContentAsync(query.CodeTableName);
            return decisionMakers;
        } 
      
    }
}
