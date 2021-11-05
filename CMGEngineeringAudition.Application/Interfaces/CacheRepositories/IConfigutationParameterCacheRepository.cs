using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.CacheRepositories
{
   public interface IConfigutationParameterCacheRepository
    {
        Task<DTOSystemParameter> SystemParameterContentAsync(SystemParameterContentQuery query);
    }
}
