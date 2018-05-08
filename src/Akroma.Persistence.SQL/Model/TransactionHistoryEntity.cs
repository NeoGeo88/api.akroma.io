using System;
using Akroma.Domain.Transactions.Models;

namespace Akroma.Persistence.SQL.Model
{
    public class TransactionHistoryEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
       

        public TransactionHistory ToTransactionHistory()
        {
            return new TransactionHistory(Date, Amount, Total);
        }
    }
}
