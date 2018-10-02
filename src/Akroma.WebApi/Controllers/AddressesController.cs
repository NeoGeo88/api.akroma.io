using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Queries;
using Brickweave.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace Akroma.WebApi.Controllers
{

    public class AddressesController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public AddressesController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - List transactions
        /// </summary>
        /// <param name="address">The address to return [0x]ADDRESS</param>
        [ProducesResponseType(typeof(Address), 200)]
        [HttpGet]
        [Route("addresses/{address}")]
        [ResponseCache(Duration = 30, VaryByQueryKeys = new[] { "address"})]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<Address> Get(string address)
        {
            return await _dispatcher.DispatchQueryAsync(new GetAddress(address));
        }

        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - List transactions
        /// </summary>
        /// <param name="address">The address to return [0x]ADDRESS</param>
        /// <param name="filter">all/to/from</param>
        /// <param name="page"></param>
        [ProducesResponseType(typeof(AddressTransactions), 200)]
        [HttpGet]
        [Route("addresses/{address}/transactions")]
        [ResponseCache(Duration = 30, VaryByQueryKeys = new[] { "address", "filter", "page" })]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<AddressTransactions> GetTransactions(string address, string filter = "all", int page = 0)
        {
            return await _dispatcher.DispatchQueryAsync(new GetAddressTransactions(address, filter, page));
        }


        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - List addresses order by balance, requested by coinmarketcap.com
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<Address>), 200)]
        [HttpGet]
        [Route("addresses")]
        [ResponseCache(Duration = 6000)]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _dispatcher.DispatchQueryAsync(new GetAddresses());
        }
    }
}
