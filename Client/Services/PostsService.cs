using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using TKA.Posts.Models;

namespace TKA.Posts.Services
{
    public class PostsService : ServiceBase, IPostsService, IService
    {
        private readonly SiteState _siteState;

        public PostsService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl => CreateApiUrl(_siteState.Alias, "Posts");

        public async Task<List<Models.Posts>> GetPostssAsync(int ModuleId)
        {
            List<Models.Posts> Postss = await GetJsonAsync<List<Models.Posts>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", ModuleId));
            return Postss.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Posts> GetPostsAsync(int PostsId, int ModuleId)
        {
            return await GetJsonAsync<Models.Posts>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PostsId}", ModuleId));
        }

        public async Task<Models.Posts> AddPostsAsync(Models.Posts Posts)
        {
            return await PostJsonAsync<Models.Posts>(CreateAuthorizationPolicyUrl($"{Apiurl}", Posts.ModuleId), Posts);
        }

        public async Task<Models.Posts> UpdatePostsAsync(Models.Posts Posts)
        {
            return await PutJsonAsync<Models.Posts>(CreateAuthorizationPolicyUrl($"{Apiurl}/{Posts.PostsId}", Posts.ModuleId), Posts);
        }

        public async Task DeletePostsAsync(int PostsId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PostsId}", ModuleId));
        }
    }
}
