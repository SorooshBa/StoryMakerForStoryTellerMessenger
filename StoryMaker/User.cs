using ChatRoomStoryTeller.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ChatRoomStoryTeller
{
    public class User
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool isNewMeesage {  get; set; }
        public List<ChatMessage> Messages { get; set; }=new List<ChatMessage>();
        public Dialogue LatestDialogue {  get; set; }
    }
}
