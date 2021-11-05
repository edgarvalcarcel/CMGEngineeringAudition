using Newtonsoft.Json;
using System.Collections.Generic;

namespace CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery
{
    public class GetCodeTableContentResponse
    {
        [JsonProperty(PropertyName = "codeTableItems")]
        public List<CodeTableItem> CodeTableItems { get; set; }
    }
}


