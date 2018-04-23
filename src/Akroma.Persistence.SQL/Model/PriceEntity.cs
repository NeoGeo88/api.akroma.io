using System;
using Akroma.Domain.Prices.Models;

namespace Akroma.Persistence.SQL.Model
{
    public class PriceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Value { get; set; }
        public string Usd { get; set; }
        public decimal UsdRaw { get; set; }
        public decimal UsdDayAgoRaw { get; set; }
        public DateTime CreatedAt { get; set; }

        public Price ToPrice()
        {
            return new Price
            {
                Name = Name,
                Symbol = Symbol,
                UsdRaw = UsdRaw,
                UsdDayAgoRaw = UsdDayAgoRaw,
                Usd = Usd,
                Value = Value
            };
        }
    }
}
