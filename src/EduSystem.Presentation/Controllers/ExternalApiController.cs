using System.Threading.Tasks;
using EduSystem.Services.Examples.ExternalApi;
using Microsoft.AspNetCore.Mvc;

namespace EduSystem.Presentation.Controllers;

[Route("/reqres/")]
[ApiController]
public class ExternalApiController : ControllerBase
{
    private readonly IReqResService reqResService;

    public ExternalApiController(IReqResService reqResService)
    {
        this.reqResService = reqResService;
    }

    [HttpGet("users")]
    public async Task<IActionResult> List(int page = 1)
    {
        return this.Ok(await this.reqResService.GetListUsersAsync(page));
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> Get([FromRoute]int id)
    {
        return this.Ok(await this.reqResService.GetSingleUserAsync(id));
    }

    [HttpPost("users")]
    public async Task<IActionResult> Create([FromBody]ReqResMutationRequest request)
    {
        return this.Ok(await this.reqResService.CreateUserAsync(request));
    }

    [HttpPut("users/{id}")]
    public async Task<IActionResult> Update([FromRoute]int id, [FromBody]ReqResMutationRequest request)
    {
        return this.Ok(await this.reqResService.UpdateUserAsync(id, request));
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        return this.Ok(await this.reqResService.DeleteUserAsync(id));
    }
}