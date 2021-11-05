using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.Repositories
{
    public interface IConfigurationRepository
    {
        Task<List<DTOCodeTableContent>> GetCodeTableContentAsync(string codeTableName, string culture = default);

    }
}
