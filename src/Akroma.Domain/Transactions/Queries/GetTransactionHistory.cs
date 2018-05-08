using System.Collections.Generic;
using Akroma.Domain.Transactions.Models;
using Brickweave.Cqrs;

namespace Akroma.Domain.Transactions.Queries
{
    public class GetTransactionHistory : IQuery<IEnumerable<TransactionHistory>>
    {
        
    }
}
