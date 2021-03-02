using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using TKA.Posts.Models;

namespace TKA.Posts.Repository
{
    public class PostsContext : DBContextBase, IService
    {
        public virtual DbSet<Models.Posts> Posts { get; set; }

        public PostsContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
