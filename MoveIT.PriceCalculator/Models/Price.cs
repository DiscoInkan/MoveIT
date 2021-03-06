using Newtonsoft.Json;

namespace MoveIT.PriceCalculator.Models
{
    public class Price
    {
        public int Distance { get; set; }
        public int LivingSpace { get; set; }
        public int StorageSpace { get; set; }
        public bool HasHeavyItem    { get; set; }
    }
}
