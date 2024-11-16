using ClientMatterSolution.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaylorWessing.ViewModels;

namespace TaylorWessing.Controllers
{
    public class ClientController : Controller
    {
        private readonly IApiService _apiService;

        public ClientController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("client/search")]
        public async Task<IActionResult> Search(string term="*",int sort=1,int index=0,int offset=10)
        {           
            ViewBag.sort = sort;            
            var clients = await _apiService.SearchClientsAsync(term,sort,index,offset);
            return PartialView("_ClientListPartial", clients);
        }

        [HttpGet]
        [Route("client/{id}")]
        public async Task<IActionResult> ClientDetails(string id, int sort = 1, int index = 0, int offset = 10)
        {
            var viewModel = new ClientDetailsViewModel();
            viewModel.Client = await _apiService.GetClientByIdAsync(id);
            if (viewModel.Client != null)
            {           
                viewModel.Matters = await _apiService.GetMattersByClientIdAsync(id, sort, index, offset);
           
            }
                return View(viewModel);
        }



        [HttpGet]

        [Route("client/{clientId:Guid}/matters")]

        public async Task<IActionResult> Matters(string clientId, int sort = 1, int index = 0, int offset = 10)
        {
            var matters = await _apiService.GetMattersByClientIdAsync(clientId, sort, index, offset);
            return PartialView("_MatterListPartial", matters);
        }



    }
}
