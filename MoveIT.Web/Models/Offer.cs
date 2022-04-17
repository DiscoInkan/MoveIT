using MoveIT.Web.Models;

namespace MoveIT.Web
{
    public class Offer
    {
        public long Id { get; set; }
        public DateTime OfferDate { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public float Distance { get; set; }
        public int LivingSpace { get; set; }
        public int StorageSpace { get; set; }
        public bool HeavyItem { get; set; }
        public decimal OfferPrice { get; set; }
        public Customer? Customer { get; set; }  
    }
}