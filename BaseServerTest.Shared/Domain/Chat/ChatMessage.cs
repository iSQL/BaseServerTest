using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseServerTest.Shared.Domain.Chat
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
