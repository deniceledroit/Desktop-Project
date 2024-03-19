using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BGInventory.Models
{
    internal class Auth
    {
        public class SuccessMessage
        {
            public string Token { get; set; }
        }

        public SuccessMessage Success { get; set; }

        public static String Login(String email, String pwd)
        {
            Dictionary<String, String> userCredentials = new Dictionary<String, String>();

            userCredentials.Add("email", email);
            userCredentials.Add("password", pwd);

            RestResponse response = Api.Post("login", userCredentials);
            Auth result = JsonSerializer.Deserialize<Auth>(response.Content,Api.jsonOptions);

            Console.WriteLine(response.Content);

            string message = "";
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    message = "Success";
                    Api.Token = result.Success.Token;
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    message = "Unthorized access. Please try again !";
                    break;
                default:
                    message = "Something wrong occured with the connection to database.";
                    break;
            }
            return message;
        }
    }
}
