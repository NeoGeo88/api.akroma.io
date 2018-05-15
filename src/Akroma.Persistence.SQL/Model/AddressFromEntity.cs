using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akroma.Domain.Addressess.Model;

namespace Akroma.Persistence.SQL.Model
{
    public class AddressFromEntity
    {
        [Key]
        public string From { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal Value { get; set; }
        public long Count { get; set; }

        public AddressFrom ToAddressFrom()
        {
            return new AddressFrom(From, Value, Count);
        }
    }
}
