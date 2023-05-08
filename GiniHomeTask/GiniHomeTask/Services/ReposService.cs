using GiniHomeTask.Services.Inerfaces;
using GiniTask.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GiniHomeTask.Services
{
    public class ReposService:IReposService
    {
        private readonly IOptions<RepoSearch> _REPOURL;

        public ReposService(IOptions<RepoSearch> REPOURL)
        {
            _REPOURL = REPOURL;
        }
        public async Task<RepoInfo> GetRepo(string searchQuery)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(_REPOURL.Value.BaseAddress)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
                client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
                using (var response = await client.GetAsync($"/search/repositories?q={searchQuery}"))
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<RepoInfo>(result);

                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
