using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consume.Api.Services
{
    public interface IProducerService
    {
        Task<String> GetDataAsync();
    }

    public class ProducerService : IProducerService
    {
        private readonly HttpClient httpClient = null;

        public ProducerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<string> IProducerService.GetDataAsync()
        {
            using var response = await httpClient.GetAsync("api/demo/get");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}