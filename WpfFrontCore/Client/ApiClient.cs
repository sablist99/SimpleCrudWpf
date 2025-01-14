using System.Net.Http;
using System.Net.Http.Json;

namespace WpfFrontCore.Client
{
    public class ApiClient<T>(HttpClient httpClient) where T : class
    {
        public HttpClient HttpClient { get; } = httpClient;

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<T>>("") ?? [];
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error requesting data: {ex.Message}", ex);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<T>($"{HttpClient.BaseAddress}/{id}") ?? throw new Exception($"Record with Id = {id} not found.");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error requesting data by Id = {id}: {ex.Message}", ex);
            }
        }

        public async Task CreateAsync(T entity)
        {
            var response = await HttpClient.PostAsJsonAsync("", entity);
            await GenerateException(response);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var response = await HttpClient.PutAsJsonAsync($"{HttpClient.BaseAddress}/{id}", entity);
            await GenerateException(response);
        }

        public async Task DeleteAsync(int id)
        {
            var response = await HttpClient.DeleteAsync($"{HttpClient.BaseAddress}/{id}");
            await GenerateException(response);
        }

        protected static async Task GenerateException(HttpResponseMessage? response)
        {
            if (response != null && !response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException($"Error: {response.StatusCode}, Content: {errorContent}");
            }
        }
    }

}
