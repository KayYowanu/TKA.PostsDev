using System.Collections.Generic;
using System.Threading.Tasks;
using TKA.Posts.Models;

namespace TKA.Posts.Services
{
    public interface IPostsService 
    {
        Task<List<Models.Posts>> GetPostssAsync(int ModuleId);

        Task<Models.Posts> GetPostsAsync(int PostsId, int ModuleId);

        Task<Models.Posts> AddPostsAsync(Models.Posts Posts);

        Task<Models.Posts> UpdatePostsAsync(Models.Posts Posts);

        Task DeletePostsAsync(int PostsId, int ModuleId);
    }
}
