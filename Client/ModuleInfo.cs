using Oqtane.Models;
using Oqtane.Modules;

namespace TKA.Posts
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Posts",
            Description = "Posts",
            Version = "1.0.0",
            ServerManagerType = "TKA.Posts.Manager.PostsManager, TKA.Posts.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "TKA.Posts.Shared.Oqtane"
        };
    }
}
