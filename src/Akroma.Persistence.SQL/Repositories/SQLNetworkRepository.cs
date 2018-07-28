using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLNetworkRepository : INetworkRepository
    {
        private readonly AkromaContext _context;

        public SQLNetworkRepository(AkromaContext context)
        {
            _context = context;
        }

        public async Task<Stats> GetNetworkAsync()
        {
            var current =  await _context
                .Network
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => x.ToViewModel())
                .FirstAsync();
            return current;
        }

        public async Task<Supply> GetSupplyAsync()
        {
            var network = await GetNetworkAsync();
            return new Supply(network.CirculatingSupply);
            
        }

        public async Task<IEnumerable<Stats>> GetNetworkHistoryAsync()
        {
            return await _context
                .Network
                .AsNoTracking()
                .Take(10)
                .OrderByDescending(x => x.Id)
                .Select(x => x.ToViewModel())
                .ToListAsync();
        }
    }
}
