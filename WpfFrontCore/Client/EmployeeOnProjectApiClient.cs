using CrudApplication.Dto;
using Domain.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace WpfFrontCore.Client
{
    public class EmployeeOnProjectApiClient(HttpClient httpClient) : ApiClient<EmployeeOnProject>(httpClient)
    {
        public async Task<List<EmployeeOnProjectDto>> GetAllDtoAsync()
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<EmployeeOnProjectDto>>($"{HttpClient.BaseAddress}/Dto") ?? [];
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error requesting data: {ex.Message}", ex);
            }
        }
    }
}
