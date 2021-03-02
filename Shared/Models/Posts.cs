using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace TKA.Posts.Models
{
    [Table("TKAPosts")]
    public class Posts : IAuditable
    {
        public int PostsId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
