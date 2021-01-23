using NerdyUI.Repository.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NerdyUI.Repository
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly IHttpClientFactory _client;
        public Repository(IHttpClientFactory client)
        {
            _client = client;
        }
        public async Task<bool> CreateAsync(string url, T model)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if(model != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");
            }
            else
            {
                return false;
            }

            var client = _client.CreateClient();
            var response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string url, string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete,url + id);

            var client = _client.CreateClient();
            var response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _client.CreateClient();
            var response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonObj = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonObj);
            }
            else
            {
                return null;
            }
        }

        public async Task<T> GetAsync(string url, string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);
            var client = _client.CreateClient();
            var response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonObj = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonObj);
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(string url, T model, string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url + id);
            if (model != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            }
            var client = _client.CreateClient();
            var response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
