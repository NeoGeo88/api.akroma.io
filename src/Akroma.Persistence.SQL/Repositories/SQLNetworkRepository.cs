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
                .FirstOrDefaultAsync();
            return current ?? new Stats();
        }

        public async Task<Supply> GetSupplyAsync()
        {
            //12,000,000 created during Akroma epoc.
            double result = 12000000;

            var current = await _context.Network.AsNoTracking().OrderByDescending(x => x.Id).FirstAsync();
            var height = current.Height;
            var bEpoc = height - 1200000;
            var cEpoc = height - 2200000;
            var dEpoc = height - 3200000;
            
            if (bEpoc > 0)
            {
                var bAmount = bEpoc * 6;
                result = result + bAmount;
            }

            if (cEpoc > 0)
            {
                var cAmount = cEpoc * 5.5;
                result = result + cAmount;
            }

            if (dEpoc > 0)
            {
                var dAmount = dEpoc * 5;
                result = result + dAmount;
            }

            return new Supply(result);
            
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
