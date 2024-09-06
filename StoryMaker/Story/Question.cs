using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class Question
    {
        public ChatMessage Message { get; set; }
        public Dialogue Answer { get; set; }
        public bool isAlreadyUsed { get; set; } = false;
    }
}
