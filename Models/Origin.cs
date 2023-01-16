namespace CandyShop.Models
{
    public class Origin
    {
       
        public int ID { get; set; }

        public string OriginName { get; set; }
        public ICollection<Product>? Products{ get; set; }
    }
}
