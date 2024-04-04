using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public Storage Storage { get; set; }
        public User(int id,string name,string email,string streetAddress,string city,string postalCode,string phone,Storage storage) 
        {
            Id = id;
            Name = name;
            Email = email;
            StreetAddress = streetAddress;
            City = city;
            PostalCode = postalCode;
            Phone = phone;
            Storage = storage;
        }
    }
}
