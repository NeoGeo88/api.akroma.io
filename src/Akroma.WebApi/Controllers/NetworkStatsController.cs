using System.Threading.Tasks;
using Akroma.Domain.NetworkStats.Models;
using Akroma.Domain.NetworkStats.Queries;
using Brickweave.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace Akroma.WebApi.Controllers
{
    public class NetworkStatsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public NetworkStatsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [ProducesResponseType(typeof(Stats), 200)]
        [HttpGet]
        [Route("network")]
        [ResponseCache(Duration = 60)]
        public async Task<Stats> Get()
        {
            return await _dispatcher.DispatchQueryAsync(new GetNetworkStats());
        }


        /// <summary>
        ///     Current supply, requested by coinmarketcap.com
        /// </summary>
        [ProducesResponseType(typeof(Supply), 200)]
        [HttpGet]
        [Route("network/supply")]
        [ResponseCache(Duration = 60)]
        public async Task<Supply> Supply()
        {
            return await _dispatcher.DispatchQueryAsync(new GetSupply());
        }


        /// <summary>
        ///     Current supply, value only, requested by coinmarketcap.com
        /// </summary>
        [ProducesResponseType(typeof(string), 200)]
        [HttpGet]
        [Route("network/supply/value")]
        [ResponseCache(Duration = 60)]
        public async Task<string> SupplyValue()
        {
            var supply = await _dispatcher.DispatchQueryAsync(new GetSupply());
            return "{" + supply.Circulating + "}";

        }
    }
}
