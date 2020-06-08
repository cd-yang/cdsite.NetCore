using System;

namespace CdSite.Model.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// 上一篇
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// 上一篇id
        /// </summary>
        public int PreviousId { get; set; }

        /// <summary>
        /// 下一篇
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// 下一篇id
        /// </summary>
        public int NextId { get; set; }

        /// <summary>
        /// 类别 
        /// </summary>
        //public string Category { get; set; }

        /// <summary>
        /// 内容 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int Traffic { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public DateTime PubDateUtc { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOnUtc { get; set; }
    }
}