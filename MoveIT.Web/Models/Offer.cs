namespace MoveIT.Web
{
    public class Offer : IOffer
    {
        public Guid OfferId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public float Distance { get; set; }
        public int LivingSpace { get; set; }
        public int StorageSpace { get; set; }
        public bool HeavyItem { get; set; }
        public decimal OfferPrice { get; set; }
    }
}