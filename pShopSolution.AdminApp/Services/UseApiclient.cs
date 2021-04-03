using Newtonsoft.Json;
using pShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public class UseApiclient : IUserApiclient
    {
        private readonly IHttpClientFactory httpClientFactory;
        public UseApiclient(IHttpClientFactory _httpClientFactory)
        {
            httpClientFactory = _httpClientFactory;
        
        }
        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client =  httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.PostAsync("/api/users/authenticate",httpContent);

            var token = await response.Content.ReadAsStringAsync();

            return token;
        }
    }
}
