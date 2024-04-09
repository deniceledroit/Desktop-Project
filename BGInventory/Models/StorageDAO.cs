using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class StorageDAO
    {
        public static List<Storage> All()
        {
            RestResponse response = Api.GetWithToken("storages");
            List<Storage> storages = JsonSerializer.Deserialize<List<Storage>>(response.Content, Api.jsonOptions);

            foreach (Storage storage in storages)
            {
                Console.WriteLine(storage.Id + "-" + storage.StreetAddress);
            }
            return storages;
        }
    }
}
