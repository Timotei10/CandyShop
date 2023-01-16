using System.Security.Policy;
using CandyShop.Models;

namespace CandyShop.Models.ViewModels
{
    public class OriginIndexData
    {
        public IEnumerable<Origin> Origins { get; set; }
        public IEnumerable<Product> Products{ get; set; }

    }
}
