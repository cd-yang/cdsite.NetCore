using System.Collections.Generic;

namespace Model
{
    public class MessageModel<T>
    {
        public bool Success { get; set; }

        public string Msg { get; set; }

        public List<T> Data { get; set; }
    }
}
