using System.Threading.Tasks;
using Akroma.Domain.Prices.Models;
using Akroma.Domain.Prices.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Prices.Queries
{
    public class GetPriceHandler : IQueryHandler<GetPrice, Price>
    {
        private readonly IPriceRepository _priceRepository;
        //private static readonly HttpClient HttpClient = new HttpClient();

        public GetPriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<Price> HandleAsync(GetPrice query)
        {
            return await _priceRepository.GetPriceAsync(query.Symbol);


            //var stocks = await HttpClient.GetStringAsync(new Uri("https://stocks.exchange/api2/ticker"));
            //var stocksPrices = JsonConvert.DeserializeObject<List<StocksPrice>>(stocks);
            //var akaPrice = stocksPrices.FirstOrDefault(x => x.market_name == "AKA_BTC");

            //var coinmarketCap = await HttpClient.GetStringAsync(new Uri("https://api.coinmarketcap.com/v1/ticker/bitcoin/"));
            //var bitcoinPrices = JsonConvert.DeserializeObject<List<Coinmarketcap>>(coinmarketCap);
            //var bitcoin = bitcoinPrices.FirstOrDefault();

            //if (akaPrice == null || bitcoin == null)
            //{
            //    return new List<Price>();
            //}

            //var usd = decimal.Parse(bitcoin.price_usd) * decimal.Parse(akaPrice.ask);
            //var usdDayAgoRaw = decimal.Parse(bitcoin.price_usd) * decimal.Parse(akaPrice.lastDayAgo);

            //return new List<Price>
            //{
            //    new Price
            //    {
            //        Name = "Akroma",
            //        Symbol = "AKA",
            //        Value = decimal.Parse(akaPrice.ask),
            //        Usd = usd.ToString("C"),
            //        UsdRaw = usd,
            //        UsdDayAgoRaw = usdDayAgoRaw
            //    }
            //};
        }
    }
    public class StocksPrice
    {
        public string min_order_amount { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string last { get; set; }
        public string lastDayAgo { get; set; }
        public string vol { get; set; }
        public string spread { get; set; }
        public string buy_fee_percent { get; set; }
        public string sell_fee_percent { get; set; }
        public string market_name { get; set; }
        public string updated_time { get; set; }
        public string server_time { get; set; }
    }

    public class Coinmarketcap
    {
        public string id { get; set; }
        public string name { get; set; }
        public string price_usd { get; set; }
    }
}
