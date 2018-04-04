namespace Akroma.Domain.Prices.Models
{
    public class Price
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Value { get; set; }
        public string Usd { get; set; }

        public decimal UsdRaw { get; set; }
        public decimal UsdDayAgoRaw { get; set; }
    }
}
