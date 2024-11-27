using System.Threading.Tasks;

namespace EduSystem.Services.Examples.ExternalApi;

public interface IReqResService
{
    Task<ReqResListResponse?> GetListUsersAsync(int page = 1);

    Task<ReqResResponseSingle?> GetSingleUserAsync(int id);

    Task<ReqResMutationResponse?> CreateUserAsync(ReqResMutationRequest request);

    Task<ReqResMutationResponse?> UpdateUserAsync(int id, ReqResMutationRequest request);

    Task<bool?> DeleteUserAsync(int id);
}