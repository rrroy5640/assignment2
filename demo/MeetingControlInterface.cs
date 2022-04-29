using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal interface MeetingControlInterface
    {
        void AddMeeting();
        void DeleteMeeting(int id);
        void UpdateMeeting(int meetingID, int groupID, string day, DateTime start, DateTime end, int room);
        List<Meeting> ListMeeting();
    }
}
