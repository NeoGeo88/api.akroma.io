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
        public async Task<Address> GetAddressAsync(string address, int page = 0)
        {
            var transacionCount = await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.From == address || x.To == address)
                .CountAsync();

            var mined = await _context
                .Blocks
                .AsNoTracking()
                .Where(x => x.Miner == address)
                .CountAsync();

            var adddress = new Address(address, "", mined, transacionCount);
            return adddress;
        }
    }
}
