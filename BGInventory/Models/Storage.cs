using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class Storage
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public Storage(int id, string streetAddress,string city,string postalCode) 
        {
            Id = id;
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
        }
    }
}
