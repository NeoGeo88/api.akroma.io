using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akroma.Domain.Addressess.Model;

namespace Akroma.Persistence.SQL.Model
{
    public class AddressToEntity
    {
        [Key]
        public string To { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Value { get; set; }
        public long Count { get; set; }

        public AddressTo ToAddressTo()
        {
            return new AddressTo(To, Value, Count);
        }
    }
}
