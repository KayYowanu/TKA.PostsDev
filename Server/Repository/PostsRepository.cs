using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using TKA.Posts.Models;

namespace TKA.Posts.Repository
{
    public class PostsRepository : IPostsRepository, IService
    {
        private readonly PostsContext _db;

        public PostsRepository(PostsContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Posts> GetPostss(int ModuleId)
        {
            return _db.Posts.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Posts GetPosts(int PostsId)
        {
            return _db.Posts.Find(PostsId);
        }

        public Models.Posts AddPosts(Models.Posts Posts)
        {
            _db.Posts.Add(Posts);
            _db.SaveChanges();
            return Posts;
        }

        public Models.Posts UpdatePosts(Models.Posts Posts)
        {
            _db.Entry(Posts).State = EntityState.Modified;
            _db.SaveChanges();
            return Posts;
        }

        public void DeletePosts(int PostsId)
        {
            Models.Posts Posts = _db.Posts.Find(PostsId);
            _db.Posts.Remove(Posts);
            _db.SaveChanges();
        }
    }
}
