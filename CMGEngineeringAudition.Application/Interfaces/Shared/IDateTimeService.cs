using System;

namespace CMGEngineeringAudition.Application.Interfaces.Shared
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
        DateTime? TryParse(string stringDate);
    }
}
