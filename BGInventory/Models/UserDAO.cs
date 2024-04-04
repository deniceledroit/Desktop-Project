using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class UserDAO
    {
        public static User Show()
        {
            RestResponse response = Api.GetWithToken("user");
            User user = JsonSerializer.Deserialize<User>(response.Content, Api.jsonOptions);
            Console.WriteLine(user.Id + "-" + user.Name);
            return user;
        }
    }
}
