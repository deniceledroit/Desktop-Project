using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class SupplierDAO
    {
        public static List<Supplier> All()
        {
            RestResponse response = Api.GetWithToken("suppliers");
            List<Supplier> suppliers = JsonSerializer.Deserialize<List<Supplier>>(response.Content, Api.jsonOptions);

            foreach (Supplier supplier in suppliers)
            {
                Console.WriteLine(supplier.Id + "-" + supplier.Name);
            }
            return suppliers;
        }
        public static Supplier Show(int id)
        {
            RestResponse response = Api.GetWithToken("supplier/" + id);
            Supplier supplier = JsonSerializer.Deserialize<Supplier>(response.Content, Api.jsonOptions);
            Console.WriteLine(supplier.Id + "-" + supplier.Name);
            return supplier;
        }
    }
}
