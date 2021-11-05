using CMGEngineeringAudition.Application.Interfaces.Shared;
using System;

namespace CMGEngineeringAudition.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;

        public DateTime? TryParse(string stringDate)
        {
            DateTime date;
            return DateTime.TryParse(stringDate, out date) ? date : (DateTime?)null;
        }
    }
}
