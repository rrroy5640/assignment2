using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public class Meeting
    {
        private int meetingID;
        private int groupID;
        private string day;
        private DateTime startTime;
        private DateTime endTime;
        private string room;

        public Meeting(int meetingID, int groupID, string day, DateTime startTime, DateTime endTime, string room)
        {
            this.MeetingID = meetingID;
            this.GroupID = groupID;
            this.Day = day;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Room = room;
        }

        public int MeetingID { get => meetingID; set => meetingID = value; }
        public int GroupID { get => groupID; set => groupID = value; }
        public string Day { get => day; set => day = value; }
        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public string Room { get => room; set => room = value; }

        public override string ToString()
        {
            return MeetingID.ToString();
        }
    }
}