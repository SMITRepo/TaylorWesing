using ClientMatterSolution.Services;
using TaylorWesing.Contracts.Models;

namespace TaylorWessing.Contracts
{
    public interface IAsyncRepo 
    {
        Task<Audit> CreateAsync(string url,string data);

    }
}
