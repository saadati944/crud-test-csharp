using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerAggregate
{
    public class Customer
    {
        // There may be an entity in the infrastructure layer which stores the actual data in the database
        // but for simplicity I just use my domain model as an entity.
        public Guid ID { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
