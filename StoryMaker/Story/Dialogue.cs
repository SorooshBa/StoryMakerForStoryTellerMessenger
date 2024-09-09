using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomStoryTeller.Story
{
    public class Dialogue
    {
        public ChatMessage Message {  get; set; }
        public int UserId {  get; set; }
        public List<Question> Questions { get; set; }=new List<Question>();
        public List<TaskItem> Tasks { get; set; } =new List<TaskItem>();
        public bool isStartPoint {  get; set; } = true;
        public Dialogue()
        {
            Tasks.Add(new TaskItem() {Type=TaskType.None });
        }
        public async void DoTasks()
        {
           
        }
    }
}
