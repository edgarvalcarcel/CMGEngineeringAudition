using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace CMGEngineeringAudition.Infrastructure.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IRepositoryAsync<DTOCodeTableContent> _repositoryGetCodeTableContent;
        private readonly IDistributedCache _distributedCache;
        public ConfigurationRepository(IDistributedCache distributedCache
            , IRepositoryAsync<DTOCodeTableContent> repositoryGetCodeTableContent)
        {
            _distributedCache = distributedCache;
            _repositoryGetCodeTableContent = repositoryGetCodeTableContent;
        }

        public async Task<List<DTOCodeTableContent>> GetCodeTableContentAsync(string codeTableName, string culture = default)
        {
            var resultCodeTablecontent = await _repositoryGetCodeTableContent.ExecWithStoreProcedure(
            "proc_conectus_getcodetablecontent @culture, @codeTableName",
            new SqlParameter("culture", SqlDbType.NVarChar) { Value = string.Empty },
            new SqlParameter("codeTableName", SqlDbType.NVarChar) { Value = codeTableName });

            List<DTOCodeTableContent> codeTableList = (List<DTOCodeTableContent>)resultCodeTablecontent;
            return codeTableList;
        }
    }
}
