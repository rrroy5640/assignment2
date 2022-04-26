using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public interface MeetingControlInterface
    {
        void addMeeting();
        void deleteMeeting();
        void updateMeeting();
        List<Meeting> listMeeting();
    }
}
