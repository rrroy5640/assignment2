using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using demo;

namespace demo
{
    /// <summary>
    /// Interaction logic for MeetingManagement.xaml
    /// </summary>
    public partial class MeetingManagement : Window
    {
        private MeetingControl meetingControl;
        private string MeetingListKey = "meetingList";

        public MeetingManagement()
        {
            InitializeComponent();
            meetingControl = (MeetingControl)(Application.Current.FindResource(MeetingListKey) as ObjectDataProvider).ObjectInstance;
        }

        private void meetingListSelectionChanged (object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                MeetingIDPanel.DataContext = e.AddedItems[0];
                GroupIDPanel.DataContext = e.AddedItems[0];
                DayPanel.DataContext = e.AddedItems[0];
                StartTimePanel.DataContext = e.AddedItems[0];
                EndTimePanel.DataContext = e.AddedItems[0];
                RoomPanel.DataContext = e.AddedItems[0];

            }
        }

        private void AddMeeting_Click(object sender, RoutedEventArgs e)
        {
            meetingControl.AddMeeting();
            Meeting_List.ItemsSource = null;
            MeetingControl meeting = new MeetingControl();
            meeting = (MeetingControl)(Application.Current.FindResource(MeetingListKey) as ObjectDataProvider).ObjectInstance;
            Meeting_List.ItemsSource = meeting.GetViewableList();
        }

        private void DeleteMeeting_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = (int)int.Parse(MeetingIdData.Text);
            meetingControl.DeleteMeeting(id);
            Meeting_List.ItemsSource = null;
            Meeting_List.ItemsSource = meetingControl.GetViewableList();
        }

        private void UpdateMeeting_Click(object sender, RoutedEventArgs e)
        {
            int meetingID = int.Parse(MeetingIdData.Text);
            int groupID = int.Parse(GroupIDData.Text);
            string day = DayData.Text;
            DateTime start = DateTime.Parse(StartData.Text);
            DateTime end = DateTime.Parse(EndData.Text);
            int room = int.Parse(RoomData.Text);
            meetingControl.UpdateMeeting(meetingID, groupID, day, start, end, room);
            Meeting_List.ItemsSource = null;
            Meeting_List.ItemsSource = meetingControl.GetViewableList();
        }
    }
}
