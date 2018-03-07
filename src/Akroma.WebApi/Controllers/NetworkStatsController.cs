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
        [Route("details")]
        [ResponseCache(Duration = 600)]
        public async Task<Stats> Get()
        {
            return await _dispatcher.DispatchQueryAsync(new GetNetworkStats());
        }
    }
}
