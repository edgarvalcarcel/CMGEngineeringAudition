using Audit.WebApi;
using CMGEngineeringAudition.API.Controllers;
using CMGEngineeringAudition.Application.Features.Queries.GetCodeTableContentQuery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Api.Controllers.v1
{
    [Route("api/configuration")]
    [ApiController]
    //[Authorize]
    [AuditApi(EventTypeName = "{controller}/{action} ({verb})", IncludeHeaders = true, IncludeResponseBody = true, IncludeRequestBody = true, IncludeModelState = true)]
    public class ConfigurationController : BaseApiController<ConfigurationController>
    {
        [Route("getcodetablecontent")]
        [HttpGet]
        public async Task<IActionResult> GetCodeTableContent([FromQuery] string codeTableName)
        {
            if (ModelState.IsValid)
            {
                var properties = await _mediator.Send(new GetCodeTableContentQuery() { CodeTableName = codeTableName});
                return Ok(properties);
            }
            else
                return StatusCode(400, "Bad request");
        }
    }
}
