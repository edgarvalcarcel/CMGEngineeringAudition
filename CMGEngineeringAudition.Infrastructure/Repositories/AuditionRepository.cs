using CMGEngineeringAudition.Application.DTOs.AuditionDevices;
using CMGEngineeringAudition.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Infrastructure.Repositories
{
    public class AuditionRepository: IAuditionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _distributedCache;
        public AuditionRepository(IConfiguration configuration, IDistributedCache distributedCache)
        {
            _configuration = configuration;
            _distributedCache = distributedCache;
        }
        List<DTOAuditionDevice> IAuditionRepository.EvaluateLogFile(string fname)
        {
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fname;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fname,FileMode.Open,FileAccess.Read))
            {
                
            }
            List<DTOAuditionDevice> evaluateLogList = new();
            return evaluateLogList;
        }
    }
}
