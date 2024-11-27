using Newtonsoft.Json;

namespace EduSystem.Services.Examples.ExternalApi;

public class ReqResMutationRequest
{
    [JsonProperty("name")]
    public required string Name { get; set; }

    [JsonProperty("job")]
    public required string Job { get; set; }
}