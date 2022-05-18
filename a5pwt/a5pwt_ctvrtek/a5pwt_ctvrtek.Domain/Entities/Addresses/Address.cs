using System;
using System.Collections.Generic;
using System.Text;

namespace a5pwt_ctvrtek.Domain.Entities.Addresses
{
    public class Address : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}