using CMGEngineeringAudition.Application.DTOs.GetSystemParameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.Repositories
{
   public interface IConfigurationSystemPrameterRepository
    {
        Task<DTOSystemParameter> SystemParameterContentAsync(string KeyName);
    }
}
