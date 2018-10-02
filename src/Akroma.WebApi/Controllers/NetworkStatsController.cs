using System;
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
        [Obsolete("see https://akroma.io/docs")]
        public async Task<Stats> Get()
        {
            return await _dispatcher.DispatchQueryAsync(new GetNetworkStats());
        }


        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - Current supply, requested by coinmarketcap.com
        /// </summary>
        [ProducesResponseType(typeof(Supply), 200)]
        [HttpGet]
        [Route("network/supply")]
        [ResponseCache(Duration = 60)]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<Supply> Supply()
        {
            return await _dispatcher.DispatchQueryAsync(new GetSupply());
        }


        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - Current supply, value only as double, requested by coinmarketcap.com
        /// </summary>
        [ProducesResponseType(typeof(double), 200)]
        [HttpGet]
        [Route("network/supply/value")]
        [ResponseCache(Duration = 60)]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<double> SupplyValue()
        {
            var supply = await _dispatcher.DispatchQueryAsync(new GetSupply());
            return supply.Circulating;

        }
    }
}
