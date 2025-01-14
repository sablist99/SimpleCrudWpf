using CrudApplication.Dto;
using Domain.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace WpfFrontCore.Client
{
    public class ProjectApiClient(HttpClient httpClient) : ApiClient<Project>(httpClient)
    {
        public async Task<List<ProjectDto>> GetAllDtoAsync()
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<ProjectDto>>($"{HttpClient.BaseAddress}/Dto") ?? [];
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error requesting data: {ex.Message}", ex);
            }
        }
    }
}
