using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akroma.Domain.Addressess.Model;

namespace Akroma.Persistence.SQL.Model
{
    public class AddressEntity
    {
        [Key]
        public string Address { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal ToValue { get; set; }
        public int ToCount { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal FromValue { get; set; }
        public int FromCount { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalValue { get; set; }
        public int TotalCount { get; set; }

        public Address ToAddress()
        {
            return new Address(Address, TotalValue, 0, TotalCount, FromCount, FromValue, ToCount, ToValue);
        }
    }
}
