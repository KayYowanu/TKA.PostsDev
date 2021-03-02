using System.Collections.Generic;
using TKA.Posts.Models;

namespace TKA.Posts.Repository
{
    public interface IPostsRepository
    {
        IEnumerable<Models.Posts> GetPostss(int ModuleId);
        Models.Posts GetPosts(int PostsId);
        Models.Posts AddPosts(Models.Posts Posts);
        Models.Posts UpdatePosts(Models.Posts Posts);
        void DeletePosts(int PostsId);
    }
}
