using System;

namespace Model.Model
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImgUrl { get; set; }

        public string Url { get; set; }

        public string Remark { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
