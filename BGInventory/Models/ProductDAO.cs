using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class ProductDAO
    {
        public static List<Product> All()
        {
            RestResponse response = Api.GetWithToken("products");
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(response.Content, Api.jsonOptions);

            foreach (Product product in products)
            {
                Console.WriteLine(product.Id + "-" + product.Name);
            }
            return products;
        }
        public static Product Show(int id)
        {
            RestResponse response = Api.GetWithToken("product/"+id);
            Product product = JsonSerializer.Deserialize<Product>(response.Content, Api.jsonOptions);
            Console.WriteLine(product.Id + "-" + product.Name);
            return product;
        }
        public static void Update(Product product)
        {
            var productFields = new Dictionary<string, string>();
            productFields.Add("id",product.Id.ToString());
            productFields.Add("name", product.Name);
            productFields.Add("description", product.Description);
            productFields.Add("quantity", product.Quantity.ToString());
            productFields.Add("position",product.Position);
            Api.PutWithToken("product/"+product.Id, productFields);
        }
        public static void Create(Product product)
        {
            var productFields = new Dictionary<string, string>();
            productFields.Add("reference", product.Reference);
            productFields.Add("name", product.Name);
            productFields.Add("description", product.Description);
            productFields.Add("quantity", product.Quantity.ToString());
            productFields.Add("position", product.Position);
            productFields.Add("supplier_id",product.Supplier.Id.ToString());
            Api.PostWithToken("product", productFields);
        }
    }
}
