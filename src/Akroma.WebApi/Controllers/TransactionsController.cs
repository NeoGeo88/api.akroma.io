using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Queries;
using Brickweave.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace Akroma.WebApi.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public TransactionsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - List transactions
        /// </summary>
        /// <param name="limit">The number of transactions to return (default: 50, min: 1, max: 100)</param>
        [ProducesResponseType(typeof(IEnumerable<Transaction>), 200)]
        [HttpGet]
        [Route("transactions")]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<IEnumerable<Transaction>> Get(int? limit)
        {
            return await _dispatcher.DispatchQueryAsync(new GetTransactions(limit));
        }

        /// <summary>
        ///    Warning: Deprecated (see https://akroma.io/docs) -  Find transaction by hash
        /// </summary>
        /// <param name="hash">The transaction hash</param>
        [ProducesResponseType(typeof(Transaction), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [HttpGet]
        [Route("transactions/{hash}")]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<Transaction> GetBlock(string hash)
        {
            return await _dispatcher.DispatchQueryAsync(new GetTransaction(hash));
        }

        /// <summary>
        ///     Warning: Deprecated (see https://akroma.io/docs) - List transaction history
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<TransactionHistory>), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [HttpGet]
        [Route("transactions/history")]
        [Obsolete("see https://akroma.io/docs")]
        public async Task<IEnumerable<TransactionHistory>> GetHistory()
        {
            return await _dispatcher.DispatchQueryAsync(new GetTransactionHistory());
        }
    }
}
