using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal interface MeetingControlInterface
    {
        void AddMeeting();
        void DeleteMeeting(int id);
        void UpdateMeeting(int meetingID, int groupID, string day, DateTime start, DateTime end, string room);
        List<Meeting> ListMeeting();
    }
}