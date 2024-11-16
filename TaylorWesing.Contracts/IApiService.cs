using TaylorWessing.Models;

namespace ClientMatterSolution.Services
{
    public interface IApiService
    {
        Task<ClientSearchesponse> SearchClientsAsync(string searchTerm,int sort,int index, int offset);
        Task<Client> GetClientByIdAsync(string clientId);
        Task<MatterSearchResult> GetMattersByClientIdAsync(string clientId, int sort, int index, int offset);
        Task<Matter> GetMatterByIdAsync(string matterId);
    }
}
