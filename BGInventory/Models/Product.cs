using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string Position { get; set; }
        public Storage Storage { get; set; }
        public Supplier Supplier { get; set; }
        public Product(int id, string reference, string name, string description, string price, string position, Storage storage, Supplier supplier)
        {
            Id = id;
            Reference = reference;
            Name = name;
            Description = description;
            Price = price;
            Position = position;
            Storage = storage;
            Supplier = supplier;
        }
    }
}
