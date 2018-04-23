using System.Threading.Tasks;
using Akroma.Domain.Prices.Models;

namespace Akroma.Domain.Prices.Services
{
    public interface IPriceRepository
    {
        Task<Price> GetPriceAsync(string symbol);
    }
}
