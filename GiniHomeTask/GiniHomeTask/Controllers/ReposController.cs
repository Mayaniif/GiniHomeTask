using GiniHomeTask.Services.Inerfaces;
using GiniTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiniHomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReposController : ControllerBase
    {
        private readonly IReposService _repoService;

        [HttpGet("{searchQuery}")]
        public async Task<RepoInfo> GetRepo(string searchQuery)
        {
            return await _repoService.GetRepo(searchQuery);

        }

    }
}
