
using System;
using System.Linq;
using ToDo.Shared;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using ToDo.Mobile.Business.DataAbstraction;

namespace ToDo.Mobile.Data
{
    public class DataStore : IDataStore<ToDoItem>
    {
        private List<ToDoItem> _items;

        public async Task<bool> AddItemAsync(ToDoItem item)
        {
            try
            {
                var response = await CreateHttpClient().PostAsync("", new StringContent(JsonSerializer.Serialize(item)));

                response.EnsureSuccessStatusCode();

                var itemId = await response.Content.ReadAsStringAsync();

                item.Id = itemId;

                _items.Add(item);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateItemAsync(ToDoItem item)
        {
            try
            {
                var response = await CreateHttpClient().PutAsync($"{item.Id}", new StringContent(JsonSerializer.Serialize(item)));

                response.EnsureSuccessStatusCode();
                
                var oldItem = _items.First(arg => arg.Id == item.Id);

                oldItem.IsCompleted = item.IsCompleted;
                oldItem.Text = item.Text;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                var response = await CreateHttpClient().DeleteAsync($"{id}");
                response.EnsureSuccessStatusCode();

                var oldItem = _items.FirstOrDefault(arg => arg.Id == id);
                _items.Remove(oldItem);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ToDoItem> GetItemAsync(string id)
        {
            if (_items != null && _items.Any(x => x.Id == id))
            {
                return _items.First(x => x.Id == id);
            }

            var item = await GetResult<ToDoItem>(await CreateHttpClient().GetAsync($"{id}"));

            _items.Add(item);

            return item;
        }

        public async Task<IEnumerable<ToDoItem>> GetItemsAsync(bool forceRefresh = false)
        {
            if (_items != null && _items.Any())
            {
                return _items;
            }

            return await GetResult<List<ToDoItem>>(await CreateHttpClient().GetAsync(""));
        }

        private HttpClient CreateHttpClient()
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            var http = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri("https://10.0.2.2:5001/todo/")
            };

            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return http;
        }

        private async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            try
            {
                response.EnsureSuccessStatusCode();

                var resultString = await response.Content.ReadAsStringAsync();

                return JsonSerializer.Deserialize<T>(resultString,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch
            {
                return default;
            }
        }
    }
}