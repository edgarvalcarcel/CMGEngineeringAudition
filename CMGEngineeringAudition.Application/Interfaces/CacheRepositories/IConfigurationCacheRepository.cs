using CMGEngineeringAudition.Application.DTOs.GetCodeTableContent;
using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMGEngineeringAudition.Application.Interfaces.CacheRepositories
{
    public interface IConfigurationCacheRepository
    {
        Task<List<DTOCodeTableContent>> GetCodeTableContentAsync(GetCodeTableContentQuery query);
     
    }
}
