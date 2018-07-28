using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.NetworkStats.Queries
{
    public class GetNetworkStats : IQuery<Stats>
    {
        
    }


    public class GetSupply : IQuery<Supply>
    {

    }

    public class GetSupplyHandler : IQueryHandler<GetSupply, Supply>
    {
        private readonly INetworkRepository _networkRepository;

        public GetSupplyHandler(INetworkRepository networkRepository)
        {
            _networkRepository = networkRepository;
        }


        public async Task<Supply> HandleAsync(GetSupply query)
        {
            return await _networkRepository.GetSupplyAsync();
        }
    }
}
