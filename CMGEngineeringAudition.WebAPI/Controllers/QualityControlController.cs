using Audit.WebApi;
using CMGEngineeringAudition.Application.Features.Commands;
using CMGEngineeringAudition.WebAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.WebAPI.Controllers
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
        public async Task<IActionResult> UploadAsync([FromForm] UploadFile obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {
                    string filename;
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Uploadfiles\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Uploadfiles\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Uploadfiles\\" + obj.files.FileName))
                    {
                        obj.files.CopyTo(filestream);
                        filename = filestream.Name;
                        filestream.Flush();
                        //return "\\Uploadfiles\\" + obj.files.FileName;
                    }
                    var properties = await _mediator.Send(new EvaluateLogCommand() { ContentFile = filename });
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("Upload Failed");
            }

            //if (ModelState.IsValid)
            //{
            //    string filename = $"{hosting.WebRootPath}\\files\\{file.FileName}";
            //    using (FileStream fileStream = System.IO.File.Create(filename))
            //    {
            //        file.CopyTo(fileStream);
            //        fileStream.Flush();
            //    }
            //    var properties = await _mediator.Send(new EvaluateLogCommand() { ContentFile = file.FileName });
            //    return Ok(properties);
            //}
            //else
            //    return StatusCode(400, "Bad request");
        }
    }
}
