using CMGEngineeringAudition.Application.DTOs.AuditionDevices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.Repositories
{
    public interface IAuditionRepository
    {
        Task<List<DTOAuditionDevice>> EvaluateLogFile(string filename);
    }
}
