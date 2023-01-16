using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace CandyShop.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }
        public string Producer { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public int? OriginID { get; set; }
        public Origin? Origin{ get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}
