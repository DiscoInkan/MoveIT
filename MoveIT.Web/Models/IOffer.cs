
namespace MoveIT.Web
{
    public interface IOffer
    {
        Guid OfferId { get; set; }
        float Distance { get; set; }
        string? Email { get; set; }
        string? FirstName { get; set; }
        string? FromAddress { get; set; }
        bool HeavyItem { get; set; }
        string? LastName { get; set; }
        int LivingSpace { get; set; }
        decimal OfferPrice { get; set; }
        int StorageSpace { get; set; }
        string? ToAddress { get; set; }
    }
}