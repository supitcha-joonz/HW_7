using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace ProblemNotififation.Client.Services.SystemProblemService
{
    public class SystemNoticeService : ISystemNoticeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SystemNoticeService(HttpClient http, NavigationManager navigationManager) {
            _http = http;
            _navigationManager = navigationManager;


        }
        public List<Problem> Problems { get; set; } = new List<Problem>();

        public async Task CreateProblem(Problem pro)
        {
            var result = await _http.PostAsJsonAsync("api/problemnotice", pro);
            await SetProblems(result);
        }

        public async Task DeleteProblem(int id)
        {
            var result = await _http.DeleteAsync($"api/problemnotice/{id}");
            await SetProblems(result);
          
        }

        private async Task SetProblems(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Problem>>();
            Problems = response;
            _navigationManager.NavigateTo("information");
        }

        public async Task GetProblem()
        {
            var result = await _http.GetFromJsonAsync<List<Problem>>("api/problemnotice");
            if (result != null) {
                Problems = result;
            }
        }

        public async Task<Problem> GetSingleProblem(int id)
        {
            var result = await _http.GetFromJsonAsync<Problem>($"api/problemnotice/{id}");
            if (result != null)
                return result;
            throw new Exception("Not Found!");
            
        }

        public async Task UpdateProblem(Problem pro)
        {
            var result = await _http.PutAsJsonAsync($"api/problemnotice/{pro.Id}", pro);
            await SetProblems(result);
        }
    }
}
