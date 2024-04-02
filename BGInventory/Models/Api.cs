using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace BGInventory.Models
{
    internal class Api
    {
        private static String _url = Properties.Resources.API_URL;
        public static String Token { get; set; }
        public static JsonSerializerOptions jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        public static RestResponse Post(String route, Dictionary<String, String> fields = null)
        {
            RestClient clientApi = new RestClient(Api._url);

            RestRequest request = new RestRequest(route, Method.Post);
            request.Resource = route;
            request.AddJsonBody(fields);

            return clientApi.Execute(request);
        }
        public static RestResponse GetWithToken(String route, Dictionary<String, String> fields = null)
        {
            
            OAuth2AuthorizationRequestHeaderAuthenticator authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token,"Bearer");
            RestClientOptions options = new RestClientOptions(Api._url) {
                Authenticator = authenticator,
            };
            RestClient clientApi = new RestClient(options);
            RestRequest request = new RestRequest(route, Method.Get);
            if(null != fields)
            {
                foreach(KeyValuePair<String, String> field in fields )
                {
                    request.AddUrlSegment(field.Key, field.Value);
                }
            }
            
            return clientApi.Execute(request);
        }
        public static RestResponse PutWithToken(String route, Dictionary<String, String> fields = null)
        {

            OAuth2AuthorizationRequestHeaderAuthenticator authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token, "Bearer");
            RestClientOptions options = new RestClientOptions(Api._url)
            {
                Authenticator = authenticator,
            };
            RestClient clientApi = new RestClient(options);
            RestRequest request = new RestRequest(route, Method.Put);
            if (null != fields)
            {
                foreach (KeyValuePair<String, String> field in fields)
                {
                    request.AddParameter(field.Key, field.Value);
                }
            }

            return clientApi.Execute(request);
        }
        public static RestResponse PostWithToken(String route, Dictionary<String, String> fields = null)
        {
            Console.WriteLine("Api - PostWithToken");

            OAuth2AuthorizationRequestHeaderAuthenticator authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(Token, "Bearer");

            RestClientOptions options = new RestClientOptions(Api._url)
            {
                Authenticator = authenticator
            };
            RestClient clientApi = new RestClient(options);

            RestRequest request = new RestRequest(route, Method.Post);
            if (null != fields)
            {
                foreach (KeyValuePair<String, String> field in fields)
                {
                    request.AddParameter(field.Key, field.Value);
                }
            }
            return clientApi.Execute(request);
        }
    }
}
