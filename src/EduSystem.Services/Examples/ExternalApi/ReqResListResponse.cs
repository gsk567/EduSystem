using System.Collections.Generic;
using Newtonsoft.Json;

namespace EduSystem.Services.Examples.ExternalApi;

public class ReqResListResponse : ReqResResponse<IEnumerable<ReqResUser>>
{
    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }
}