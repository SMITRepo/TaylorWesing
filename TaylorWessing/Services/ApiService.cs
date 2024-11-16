using TaylorWessing.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using ClientMatterSolution.Services;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using TaylorWessing.Persistence.Repos;

namespace TaylorWessing.Contracts
{

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TaylorWessingRepo _taylorWessingRepo;
        private    JsonSerializerOptions _Options;
        
        public ApiService(HttpClient httpClient, TaylorWessingRepo taylorWessingRepo)
        {
            _httpClient = httpClient;
            this._taylorWessingRepo = taylorWessingRepo;
            _Options =new JsonSerializerOptions  {
                PropertyNameCaseInsensitive = true 
        };


        }
        public async Task<Matter> GetMatterByIdAsync(string matterId)
        {
                var response = await _httpClient.GetAsync($"/clientdata/matter/{matterId}");
                response.EnsureSuccessStatusCode();
               var content = await response.Content.ReadAsStringAsync();
           var audit= await this._taylorWessingRepo.CreateAsync(response.RequestMessage.RequestUri.ToString(), content);
              return JsonSerializer.Deserialize<Matter>(content,_Options);

         
        }

        public async Task<ClientSearchesponse> SearchClientsAsync(string searchTerm, int sort,int index,int offset)
        {
           var TupleSort= GetSortType(sort);
           
            var response = await _httpClient.GetAsync($"/clientdata/clientsearch/{searchTerm}/{TupleSort.Item1}/{TupleSort.Item2}/{index}/{offset}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var audit = await this._taylorWessingRepo.CreateAsync(response.RequestMessage.RequestUri.ToString(), content);
            return JsonSerializer.Deserialize<ClientSearchesponse>(content,_Options);

        }

        public async Task<Client> GetClientByIdAsync(string clientId)
        {
            var response = await _httpClient.GetAsync($"/clientdata/client/{clientId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var audit = await this._taylorWessingRepo.CreateAsync(response.RequestMessage.RequestUri.ToString(), content);
            
            return string.IsNullOrEmpty(content)? null: JsonSerializer.Deserialize<Client>(content, _Options);
       

        }

        public async Task<MatterSearchResult> GetMattersByClientIdAsync(string clientId, int sort, int index, int offset)
        {
            var TupleSort = GetSortType(sort);
            var response = await _httpClient.GetAsync($"/clientdata/mattersearch/{clientId}/{TupleSort.Item1}/{TupleSort.Item2}/{index}/{offset}");
             response.EnsureSuccessStatusCode();
             var content = await response.Content.ReadAsStringAsync();
            var audit = await this._taylorWessingRepo.CreateAsync(response.RequestMessage.RequestUri.ToString(), content);
            return JsonSerializer.Deserialize<MatterSearchResult>(content,_Options);

        }

        private Tuple<string, string> GetSortType(int sort) 
        {
            string sortField, sortType;
            switch (sort)
            {
                case 2:
                    sortField = "NAME";
                    sortType = "DESCENDING";
                    break;
                case 3:
                    sortField = "DATE";
                    sortType = "ASCENDING";
                    break;
                case 4:
                    sortField = "DATE";
                    sortType = "DESCENDING";
                    break;
                default:
                    sortField = "NAME";
                    sortType = "ASCENDING";
                    break;
            }
        
        return new Tuple<string,string>(sortField, sortType);
        }
        
    }
}
