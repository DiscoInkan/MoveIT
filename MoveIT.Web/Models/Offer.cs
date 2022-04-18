using MoveIT.Web.Models;
using System.Text.Json.Serialization;

namespace MoveIT.Web
{
    public class Offer
    {
        public long Id { get; set; }
        public Guid OfferIdentifier { get; set; } = Guid.NewGuid();
        public DateTime OfferDate { get; set; } = DateTime.Now;
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public float Distance { get; set; }
        public int LivingSpace { get; set; }
        public int StorageSpace { get; set; } = 0;
        public bool HeavyItem { get; set; }
        public int OfferPrice { get; set; }
        public virtual Customer Customer { get; set; }  = new Customer();
    }
}