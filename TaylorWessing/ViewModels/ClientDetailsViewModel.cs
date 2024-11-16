using TaylorWessing.Models;

namespace TaylorWessing.ViewModels
{
    public class ClientDetailsViewModel
    {
        public Client Client { get; set; }
        public MatterSearchResult Matters { get; set; }
    }
}