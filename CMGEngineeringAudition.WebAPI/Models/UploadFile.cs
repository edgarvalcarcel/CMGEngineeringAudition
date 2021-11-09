using Microsoft.AspNetCore.Http;

namespace CMGEngineeringAudition.Api.Models
{
    public class UploadFile
    {
        public int Id { get; set; }
        public IFormFile files { get; set; }
        public string Name { get; set; }
    }
}
