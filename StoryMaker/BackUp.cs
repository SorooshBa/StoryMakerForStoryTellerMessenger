using ChatRoomStoryTeller;
using ChatRoomStoryTeller.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoryMaker
{
    public class BackUp
    {
        public string Designer { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Dialogue> Dialogue { get; set; } = new List<Dialogue>();
    }
}
