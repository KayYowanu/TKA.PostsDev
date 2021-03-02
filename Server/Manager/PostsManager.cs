using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using TKA.Posts.Models;
using TKA.Posts.Repository;

namespace TKA.Posts.Manager
{
    public class PostsManager : IInstallable, IPortable
    {
        private IPostsRepository _PostsRepository;
        private ISqlRepository _sql;

        public PostsManager(IPostsRepository PostsRepository, ISqlRepository sql)
        {
            _PostsRepository = PostsRepository;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "TKA.Posts." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "TKA.Posts.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.Posts> Postss = _PostsRepository.GetPostss(module.ModuleId).ToList();
            if (Postss != null)
            {
                content = JsonSerializer.Serialize(Postss);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.Posts> Postss = null;
            if (!string.IsNullOrEmpty(content))
            {
                Postss = JsonSerializer.Deserialize<List<Models.Posts>>(content);
            }
            if (Postss != null)
            {
                foreach(var Posts in Postss)
                {
                    _PostsRepository.AddPosts(new Models.Posts { ModuleId = module.ModuleId, Name = Posts.Name });
                }
            }
        }
    }
}