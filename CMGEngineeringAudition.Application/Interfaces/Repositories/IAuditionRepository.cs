using CMGEngineeringAudition.Application.DTOs.AuditionDevices;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CMGEngineeringAudition.Application.Features.Commands.Measurements;

namespace CMGEngineeringAudition.Application.Interfaces.Repositories
{
    public interface IAuditionRepository
    {
        MeasureReference EvaluateLogFile(string filename);
    }
}
