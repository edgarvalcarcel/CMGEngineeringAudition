using CMGEngineeringAudition.Application.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.Shared.Services
{
    public class ListService : IListService
    {  
        public bool IsNullOrEmpty<T>(IEnumerable<T> source)
        {
            if (source == null)
            {
                return true;
            }
            return source.Any() == false;
        }
    }
}
