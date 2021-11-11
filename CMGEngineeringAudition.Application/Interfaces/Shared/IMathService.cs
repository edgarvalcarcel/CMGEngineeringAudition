using System.Collections.Generic;

namespace CMGEngineeringAudition.Application.Interfaces.Shared
{
    public interface IMathService
    {
        double StdDev(IEnumerable<double> values);
    }
}
