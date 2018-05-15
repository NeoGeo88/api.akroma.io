namespace Akroma.Domain.Addressess.Model
{
    public class AddressFrom
    {
        public string Address { get; }
        public decimal Value { get; }
        public long Count { get; }

        public AddressFrom(string address, decimal value, long count)
        {
            Address = address;
            Value = value;
            Count = count;
        }
    }
}
