using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AspNetCoreTodo.Model.Model
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public List<string> Tags { get; set; } // 需要另建一张表存储 List
        public DateTime CreateTime { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

    /// <summary>
    /// 作者
    /// </summary>
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Post> Posts { get; set; }
    }
}