using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace Assignment2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentManagement_Click(object sender, RoutedEventArgs e)
        {
            StudentManagement studentManagement = new StudentManagement();
            studentManagement.Show();
        }

        private void MeetingManagement_Click(object sender, RoutedEventArgs e)
        {
            MeetingManagement meetingManagement = new MeetingManagement();
            meetingManagement.Show();
        }

        private void CLassManagement_Click(object sender, RoutedEventArgs e)
        {
            ClassManagement classManagement = new ClassManagement();
            classManagement.Show();
        }

        private void GroupManagement_Click(object sender, RoutedEventArgs e)
        {
            GroupManagement groupManagement = new GroupManagement();
            groupManagement.Show();
        }
    }
}
