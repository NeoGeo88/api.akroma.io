using System;

namespace Akroma.Domain.Addressess.Model
{
    public class AddressTo
    {
        public string Address { get; }
        public decimal Value { get; }
        public long Count { get; }

        public AddressTo(string address, decimal value, long count)
        {
            Address = address;
            Value = value;
            Count = count;
        }
    }
}
