using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduSystem.Services.Examples.ExternalApi;

internal class ReqResService : IReqResService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<ReqResService> logger;

    public ReqResService(
        IHttpClientFactory httpClientFactory,
        ILogger<ReqResService> logger)
    {
        this.httpClientFactory = httpClientFactory;
        this.logger = logger;
    }

    public async Task<ReqResListResponse?> GetListUsersAsync(int page = 1)
    {
        try
        {
            var client = this.httpClientFactory.CreateClient("ReqRes");
            var response = await client.GetAsync($"/api/users?page={page}");

            response.EnsureSuccessStatusCode();

            var rawBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReqResListResponse>(rawBody);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<ReqResResponseSingle?> GetSingleUserAsync(int id)
    {
        try
        {
            var client = this.httpClientFactory.CreateClient("ReqRes");
            var response = await client.GetAsync($"/api/users/{id}");

            response.EnsureSuccessStatusCode();

            var rawBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReqResResponseSingle>(rawBody);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<ReqResMutationResponse?> CreateUserAsync(ReqResMutationRequest request)
    {
        try
        {
            var client = this.httpClientFactory.CreateClient("ReqRes");

            var body = JsonConvert.SerializeObject(request);

            var response = await client.PostAsync($"/api/users", new StringContent(body, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var rawBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReqResMutationResponse>(rawBody);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<ReqResMutationResponse?> UpdateUserAsync(int id, ReqResMutationRequest request)
    {
        try
        {
            var client = this.httpClientFactory.CreateClient("ReqRes");

            var body = JsonConvert.SerializeObject(request);

            var response = await client.PutAsync($"/api/users/{id}", new StringContent(body, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var rawBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ReqResMutationResponse>(rawBody);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return null;
        }
    }

    public async Task<bool?> DeleteUserAsync(int id)
    {
        try
        {
            var client = this.httpClientFactory.CreateClient("ReqRes");

            var response = await client.DeleteAsync($"/api/users/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, ex.Message);
            return null;
        }
    }
}