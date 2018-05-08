using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Transactions.Queries
{
    public class GetTransactionHistoryHandler : IQueryHandler<GetTransactionHistory, IEnumerable<TransactionHistory>>
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public GetTransactionHistoryHandler(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public async Task<IEnumerable<TransactionHistory>> HandleAsync(GetTransactionHistory query)
        {
            return await _transactionsRepository.GetTransactionHistoryAsync();
        }
    }
}
