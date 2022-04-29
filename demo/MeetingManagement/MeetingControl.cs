using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal class MeetingControl : MeetingControlInterface
    {
        private List<Meeting> meetings;

        public List<Meeting> Meetings { get { return meetings; } set { } }
        private ObservableCollection<Meeting> viewableMeetings;
        public ObservableCollection<Meeting> ViewableMeetings { get { return viewableMeetings; } set { } }

        public MeetingControl()
        {
            meetings = Agency.ListMeeting();
            viewableMeetings = new ObservableCollection<Meeting>(meetings);
        }

        public ObservableCollection<Meeting> GetViewableList()
        {
            return ViewableMeetings;
        }

        public List<Meeting> ListMeeting()
        {
            return Agency.ListMeeting();
        }

        public void AddMeeting()
        {
            Agency.AddMeeting();
            meetings = ListMeeting();
            viewableMeetings = new ObservableCollection<Meeting>(meetings);
        }

        public void DeleteMeeting(int id)
        {
            Agency.DeleteMeeting(id);
            meetings = ListMeeting();
            viewableMeetings = new ObservableCollection<Meeting>(meetings);
        }

        public void UpdateMeeting(int meetingID, int groupID, string day, DateTime start, DateTime end, string room)
        {
            Meeting meeting = new Meeting(meetingID, groupID, day, start, end, room);
            Agency.UpdateMeeting(meeting);
            meetings = ListMeeting();
            viewableMeetings = new ObservableCollection<Meeting>(meetings);
        }
    }
}