using System.Threading.Tasks;
using Akroma.Domain.Prices.Models;
using Akroma.Domain.Prices.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Prices.Queries
{
    public class GetPriceHandler : IQueryHandler<GetPrice, Price>
    {
        private readonly IPriceRepository _priceRepository;

        public GetPriceHandler(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task<Price> HandleAsync(GetPrice query)
        {
            return await _priceRepository.GetPriceAsync(query.Symbol);
        }
    }
}
