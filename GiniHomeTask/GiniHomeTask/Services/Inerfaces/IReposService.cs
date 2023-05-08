using GiniTask.Models;

namespace GiniHomeTask.Services.Inerfaces
{
    public interface IReposService
    {
        Task<RepoInfo> GetRepo(string searchQuery);
    }
}
