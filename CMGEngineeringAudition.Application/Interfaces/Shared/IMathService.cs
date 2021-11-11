using CMGEngineeringAudition.Application.Features.Commands;
using System.Collections.Generic;

namespace CMGEngineeringAudition.Application.Interfaces.Shared
{
    public interface IMathService
    {
        double StdDev(IEnumerable<double> values);
        double Median(List<Measurements.MeasuresDetails> details);
    }
}
