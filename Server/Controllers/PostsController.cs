using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using TKA.Posts.Models;
using TKA.Posts.Repository;

namespace TKA.Posts.Controllers
{
    [Route(ControllerRoutes.Default)]
    public class PostsController : Controller
    {
        private readonly IPostsRepository _PostsRepository;
        private readonly ILogManager _logger;
        protected int _entityId = -1;

        public PostsController(IPostsRepository PostsRepository, ILogManager logger, IHttpContextAccessor accessor)
        {
            _PostsRepository = PostsRepository;
            _logger = logger;

            if (accessor.HttpContext.Request.Query.ContainsKey("entityid"))
            {
                _entityId = int.Parse(accessor.HttpContext.Request.Query["entityid"]);
            }
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.Posts> Get(string moduleid)
        {
            return _PostsRepository.GetPostss(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.Posts Get(int id)
        {
            Models.Posts Posts = _PostsRepository.GetPosts(id);
            if (Posts != null && Posts.ModuleId != _entityId)
            {
                Posts = null;
            }
            return Posts;
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Posts Post([FromBody] Models.Posts Posts)
        {
            if (ModelState.IsValid && Posts.ModuleId == _entityId)
            {
                Posts = _PostsRepository.AddPosts(Posts);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Posts Added {Posts}", Posts);
            }
            return Posts;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.Posts Put(int id, [FromBody] Models.Posts Posts)
        {
            if (ModelState.IsValid && Posts.ModuleId == _entityId)
            {
                Posts = _PostsRepository.UpdatePosts(Posts);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Posts Updated {Posts}", Posts);
            }
            return Posts;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.Posts Posts = _PostsRepository.GetPosts(id);
            if (Posts != null && Posts.ModuleId == _entityId)
            {
                _PostsRepository.DeletePosts(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Posts Deleted {PostsId}", id);
            }
        }
    }
}
