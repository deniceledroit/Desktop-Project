using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class TransitDAO
    {
        public static void Create(Transit transit)
        {
            var productFields = new Dictionary<string, string>();
            productFields.Add("product_id", transit.Product.Id.ToString());
            productFields.Add("storageFrom_id", transit.StorageFrom.Id.ToString());
            productFields.Add("storageTo_id", transit.StorageTo.Id.ToString());
            productFields.Add("number", transit.Number.ToString());
            productFields.Add("arriveDate", transit.DateTime.ToString());
            Api.PostWithToken("transit", productFields);
        }
    }
}
