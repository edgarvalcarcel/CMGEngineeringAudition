using Audit.WebApi;
using CMGEngineeringAudition.Api.Models;
using CMGEngineeringAudition.API.Controllers;
//using CMGEngineeringAudition.Application.Features.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace CMGEngineeringAudition.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [AuditApi(EventTypeName = "{controller}/{action} ({verb})", IncludeHeaders = true, IncludeResponseBody = true, IncludeRequestBody = true, IncludeModelState = true)]
    public class QualityControlController : BaseApiController<QualityControlController>
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public QualityControlController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("upload")]
        public string Upload([FromForm] UploadFile obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\images\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\images\\" + obj.files.FileName))
                    {
                        obj.files.CopyTo(filestream);
                        filestream.Flush();
                        return "\\images\\" + obj.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}
