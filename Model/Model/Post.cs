using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CdSite.Model.Model
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public string ContentMarkdown { get; set; }
        public bool CommentEnabled { get; set; } = true;
        public DateTime CreateOnUtc { get; set; }
        public DateTime? PubDateUtc { get; set; }
        public string ContentAbstract { get; set; }
        public bool IsPublished { get; set; }
        public bool ExposedToSiteMap { get; set; } = true;
        public bool FeedIncluded { get; set; } = true;
        public string ContentLanguageCode { get; set; }
        //public IList<Tag> Tags { get; set; }
        //public IList<Category> Categories { get; set; }
        //public List<string> Tags { get; set; } // 需要另建一张表存储 List
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