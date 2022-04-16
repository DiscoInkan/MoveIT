namespace MoveIT.Web.Services
{
    public class OfferService : IOfferService
    {
        public IOffer GetOffer()
        {
            return new Offer();
        }

        public void SaveOffer()
        {

        }

    }
}
