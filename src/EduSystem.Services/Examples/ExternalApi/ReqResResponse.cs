using System.Collections.Generic;
using Newtonsoft.Json;

namespace EduSystem.Services.Examples.ExternalApi;

public class ReqResResponse<T>
{
    [JsonProperty("data")]
    public T? Data { get; set; }
}