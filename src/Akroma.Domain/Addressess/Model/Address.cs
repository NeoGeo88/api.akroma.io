namespace Akroma.Domain.Addressess.Model
{
    public class Address
    {
        public Address(string hash, string balance, int mined, int totalTransaction)
        {
            Hash = hash;
            Balance = balance;
            Mined = mined;
            TransactionsInitiatedCount = totalTransaction;
        }

        public int TransactionsInitiatedCount { get; }
        public string Hash { get; }
        public string Balance { get; set; } //set in the query handler (does not come from db)
        public int Mined { get; }
      
    }
}
