using CMGEngineeringAudition.Application.Interfaces.Shared;
using System;
using System.Text.RegularExpressions;

namespace CMGEngineeringAudition.Infrastructure.Shared.Services
{
    public class NumberService : IIntegerService
    {
        public bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }
    }
}
