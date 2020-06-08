using System;

namespace CdSite.Model.Model
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public bool IsDone { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? DueAt { get; set; }

        public string UserId { get; set; }
    }
}