using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.Shared
{
    public interface IListService
    {
        bool IsNullOrEmpty<T>(IEnumerable<T> source);
    }
}
