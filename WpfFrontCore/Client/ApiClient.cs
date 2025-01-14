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
                return await _httpClient.GetFromJsonAsync<List<T>>("") ?? [];
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
                return await _httpClient.GetFromJsonAsync<T>($"/{id}") ?? throw new Exception($"Record with Id = {id} not found.");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error requesting data by Id = {id}: {ex.Message}", ex);
            }
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("", entity);
                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to create the record.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while creating the record: {ex.Message}", ex);
            }
        }

        public async Task UpdateAsync(int id, T entity)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/{id}", entity);
                response.EnsureSuccessStatusCode(); 

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to update the record with Id = {id}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while updating the record with Id = {id}: {ex.Message}", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/{id}");
                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to delete the record with Id = {id}.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error occurred while deleting the record with Id = {id}: {ex.Message}", ex);
            }
        }
    }

}
