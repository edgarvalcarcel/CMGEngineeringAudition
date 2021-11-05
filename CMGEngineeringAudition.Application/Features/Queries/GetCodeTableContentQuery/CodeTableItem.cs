using Newtonsoft.Json;

namespace CMGEngineeringAudition.Application.Features.Orders.Queries.GetCodeTableContentQuery
{
    public class CodeTableItem
    {
        [JsonProperty(PropertyName = "caption")]
        public string Caption { get; set; }

        [JsonProperty(PropertyName = "externalId")]
        public int ExternalId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}