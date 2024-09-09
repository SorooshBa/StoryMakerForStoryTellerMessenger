using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller
{
    public class ChatMessage
    {
        public Senders Sender {  get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string Image {  get; 
            set; } = "nap";
        public enum Senders
        {
            me,
            you
        }
    }
}
