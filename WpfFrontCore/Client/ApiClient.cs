using System.Net.Http;
using System.Net.Http.Json;

namespace WpfFrontCore.Client
{
    public class ApiClient<T>(HttpClient httpClient) where T : class
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var a = await _httpClient.GetFromJsonAsync<List<T>>("") ?? [];
                return a;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Error: {ex.Message}");
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task CreateAsync(T entity)
        {
            var response = await _httpClient.PostAsJsonAsync("", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"/{id}", entity);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
