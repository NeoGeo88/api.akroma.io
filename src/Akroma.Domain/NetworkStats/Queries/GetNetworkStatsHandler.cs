using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.NetworkStats.Queries
{
    public class GetNetworkStatsHandler : IQueryHandler<GetNetworkStats, Stats>
    {
        private readonly INetworkRepository _networkRepository;

        public GetNetworkStatsHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }


        public async Task<Stats> HandleAsync(GetNetworkStats query)
        {
            return await _networkRepository.GetNetworkAsync();
        }
    }
}
