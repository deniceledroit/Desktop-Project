using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class Transit
    {
        public Storage StorageFrom { get; set; }
        public Storage StorageTo { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }
        public string DateTime { get; set; }
        public Transit(Storage storageFrom,Storage storageTo,Product product,int number,string dateTime) 
        {
            StorageFrom = storageFrom;
            StorageTo = storageTo;
            Product = product;
            Number = number;
            DateTime = dateTime;
        }
    }
}
