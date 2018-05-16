using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly AkromaContext _context;

        public SQLAddressRepository(AkromaContext context)
        {
            _context = context;
        }
        public async Task<int> GetAddressTransactionCountAsync(string address)
        {
            return await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.From == address || x.To == address)
                .CountAsync();
        }

        public async Task<int> GetAddressMinedAsync(string address)
        {
            return await _context
                .Blocks
                .AsNoTracking()
                .Where(x => x.Miner == address)
                .CountAsync();
        }

        public async Task<AddressTo> GetAddressToAsync(string address)
        {
            return await _context
                .AddressTo
                .AsNoTracking()
                .Where(x => x.To == address)
                .Select(x => x.ToAddressTo())
                .FirstOrDefaultAsync() ?? new AddressTo(address, 0, 0);
        }

        public async Task<AddressFrom> GetAddressFromAsync(string address)
        {
            return await _context
                       .AddressFrom
                       .AsNoTracking()
                       .Where(x => x.From == address)
                       .Select(x => x.ToAddressFrom())
                       .FirstOrDefaultAsync() ?? new AddressFrom(address, 0, 0);
        }
    }
}
