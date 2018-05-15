namespace Akroma.Domain.Addressess.Model
{
    public class Address
    {
        public Address(string hash,
            string balance,
            int mined,
            int totalTransaction,
            long sentTransactions,
            decimal sentTotal,
            long receivedTransactions,
            decimal receivedTotal)
        {
            Hash = hash;
            Balance = balance;
            Mined = mined;
            TransactionsInitiatedCount = totalTransaction;
            SentTransactions = sentTransactions;
            SentTotal = sentTotal;
            ReceivedTransactions = receivedTransactions;
            ReceivedTotal = receivedTotal;
        }

        public int TransactionsInitiatedCount { get; }
        public long SentTransactions { get; }
        public decimal SentTotal { get; }
        public long ReceivedTransactions { get; }
        public decimal ReceivedTotal { get; }
        public string Hash { get; }
        public string Balance { get; set; } //set in the query handler (does not come from db)
        public int Mined { get; }
      
    }
}
