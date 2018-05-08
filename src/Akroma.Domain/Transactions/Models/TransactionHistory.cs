using System;

namespace Akroma.Domain.Transactions.Models
{
    public class TransactionHistory
    {
        public DateTime Date { get; }
        public int Amount { get; }
        public int Total { get; }

        public TransactionHistory(DateTime date, int amount, int total)
        {
            Date = date;
            Amount = amount;
            Total = total;
        }
    }
}
