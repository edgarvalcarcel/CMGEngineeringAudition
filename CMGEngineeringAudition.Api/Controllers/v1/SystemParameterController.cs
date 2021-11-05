using Audit.WebApi;
using CMGEngineeringAudition.API.Controllers;
using CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery;
using CMGEngineeringAudition.Application.Features.Queries.GetSystemParameter;
using CMGEngineeringAudition.Application.Interfaces.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace CMGEngineeringAudition.Api.Controllers.v1
{

    [Route("api/configuration")]
    [ApiController]
    //[Authorize]
    [AuditApi(EventTypeName = "{controller}/{action} ({verb})", IncludeHeaders = true, IncludeResponseBody = true, IncludeRequestBody = true, IncludeModelState = true)]
    public class SystemParameterController : BaseApiController<SystemParameterController>
    {
        [Route("getsystemparameter")]  
        [HttpGet]
        public async Task<IActionResult> GetSystemParameter([FromQuery] string KeyName)
        {
            if (ModelState.IsValid)
            {
                var properties = await _mediator.Send(new SystemParameterContentQuery() { KeyName = KeyName });
                return Ok(properties);
            }
            else
                return StatusCode(400, "Bad request");
        }
    }
}
