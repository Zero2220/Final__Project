using UI.Models;

namespace UI.Services.Interfaces
{
    public interface ICrudService
    {
        Task<PaginatedResponse<TResponse>> GetAllPaginated<TResponse>(string path, int page);
        Task<TResponse> Get<TResponse>(string id);
        Task<CreateResponse> Create<TRequest>(TRequest request, string path);
        Task Update<TRequest>(TRequest request, string id);
        Task<CreateResponse> CreateFromForm<TRequest>(TRequest request, string path);
        Task UpdateFromForm<TRequest>(TRequest request, string path);
        Task Delete(string id);
    }
}
