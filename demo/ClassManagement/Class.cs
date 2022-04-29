using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
   
    internal class Class
    {  
        private int classID { get; set; }
        private int groupID { get; set; }
        private string day { get; set; }
        private string startTime { get; set; }
        private string endTime { get; set; }
        private string room { get; set; }

        public Class(int classID, int groupID, string day, string startTime, string endTime, string room)
        {
            this.ClassID = classID;
            this.GroupID = groupID;
            this.Day = day;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Room = room;
        }

        public Class()
        {
        }

        public override string ToString()
        {
            return classID.ToString();
        }

        public int ClassID { get => classID; set => classID = value; }
        public int GroupID { get => groupID; set => groupID = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
        public string Room { get => room; set => room = value; }
        public  string Day { get => day; set => day = value; }
    }

    
}
