using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Prices.Models;
using Akroma.Domain.Prices.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLPriceRepository : IPriceRepository
    {
        private readonly AkromaContext _context;

        public SQLPriceRepository(AkromaContext context)
        {
            _context = context;
        }
        public async Task<Price> GetPriceAsync(string symbol)
        {
            return await _context
                .Prices
                .AsNoTracking()
                .Where(x => x.Symbol == symbol)
                .OrderByDescending(x => x.Id)
                .Select(x => x.ToPrice())
                .FirstOrDefaultAsync();
        }
    }
}
