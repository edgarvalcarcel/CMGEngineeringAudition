using CMGEngineeringAudition.Application.Features.Commands;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.Shared.Services
{
    public class MathService : IMathService
    {
        public double Maximum(IEnumerable<double> values)
        {
            return values.Max();
        }

        public double Median(List<Measurements.MeasuresDetails> details)
        {
            int count = details.Count;
            var ordereddevices = details.OrderBy(p => p.Precision);
            double median = ordereddevices.ElementAt(count / 2).Precision + ordereddevices.ElementAt((count - 1) / 2).Precision;
            return (median /= 2);
        }

        public double Minimum(IEnumerable<double> values)
        {
            return values.Min();
        }

        public double StdDev(IEnumerable<double> values)
        {
            double mean = 0.0;
            double sum = 0.0;
            double stdDev = 0.0;
            int n = 0;
            foreach (double val in values)
            {
                n++;
                double delta = val - mean;
                mean += delta / n;
                sum += delta * (val - mean);
            }
            if (1 < n)
                stdDev = Math.Sqrt(sum / (n - 1));

            return stdDev;
        }
    }
}
