using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class TaskItem
    {
        public TaskType Type { get; set; } = TaskType.None;
        public int  userid { get; set; }
        public string userename { get; set; }
        public string image { get; set; }

        public int useridToSendMessage { get; set; }
        public string messageTextTosend { get; set; }
        public Dialogue param4 { get; set; }
        public Dialogue param5 { get; set; }
    }
    public enum TaskType
    {
        None,
        NewUser,
        RemoveChat,
        ReturnToThisDialogue,
        AddQuestionToDialogue,
        MakeAnotherUserSendMessage
    }
}
