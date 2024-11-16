using Microsoft.AspNetCore.Mvc;
using TaylorWessing.Models;
using ClientMatterSolution.Services;
using System.Threading.Tasks;

namespace TaylorWessing.Controllers
{
    public class MatterController : Controller
    {
        private readonly IApiService _apiService;

        public MatterController(IApiService apiService)
        {
            _apiService = apiService;
        }
   

        [HttpGet]
        [Route("matter/{id:guid}")]
        public async Task<IActionResult> GetMatterById(string id)
        {
            var matter = await _apiService.GetMatterByIdAsync(id);
            return PartialView("_MatterDetails", matter);
        }
    }
}