using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.CacheRepositories;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.SystemParameter
{
    public class ConfigurationSystemParameterRepository : IConfigurationSystemPrameterRepository
    {
        private readonly IRepositoryAsync<DTOSystemParameter> _repositoryGetCodeTableContent;
        private readonly IDistributedCache _distributedCache;
        public ConfigurationSystemParameterRepository(IDistributedCache distributedCache
            , IRepositoryAsync<DTOSystemParameter> repositoryGetCodeTableContent)
        {
            _distributedCache = distributedCache;
            _repositoryGetCodeTableContent = repositoryGetCodeTableContent;
        }

        public async Task<DTOSystemParameter> SystemParameterContentAsync(string KeyName)
        {
            var parameterResult = await _repositoryGetCodeTableContent.ExecWithStoreProcedure(
      "proc_get_system_params @KeyName",
      new SqlParameter("KeyName", SqlDbType.NVarChar) { Value = KeyName.Trim().ToUpper() });


            DTOSystemParameter parameterValue = parameterResult.FirstOrDefault();
            return parameterValue;
        }
    }
}
