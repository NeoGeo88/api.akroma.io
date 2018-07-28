using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;

namespace Akroma.Domain.NetworkStats.Services
{
    public interface INetworkRepository
    {
        Task<Stats> GetNetworkAsync();
        Task<Supply> GetSupplyAsync();

        Task<IEnumerable<Stats>> GetNetworkHistoryAsync();
    }
}
