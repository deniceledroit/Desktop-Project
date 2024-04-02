using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public Supplier(int id, string name, string streetAddress, string city, string postalCode) 
        {
            Id = id;
            Name = name;
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
        }
    }
}
