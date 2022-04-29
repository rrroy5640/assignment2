using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;
using demo;

namespace demo
{
    /// <summary>
    /// Interaction logic for StudentManagement.xaml
    /// </summary>
    public partial class StudentManagement : Window
    {
        private StudentControl studentControl;
        private string STUDENT_LIST_KEY = "studentList";


        public StudentManagement()
        {
            InitializeComponent();
            studentControl = (StudentControl)(Application.Current.FindResource(STUDENT_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void student_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                FirstNamePanel.DataContext = e.AddedItems[0];
                LastNamePanel.DataContext = e.AddedItems[0];
                IdPanel.DataContext = e.AddedItems[0];
                GroupIdPanel.DataContext = e.AddedItems[0];
                TitlePanel.DataContext = e.AddedItems[0];
                PhonePanel.DataContext = e.AddedItems[0];
                EmailPanel.DataContext = e.AddedItems[0];
                CampusPanel.DataContext = e.AddedItems[0];
                CategoryPanel.DataContext = e.AddedItems[0];
            }
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            studentControl.AddStudent();
            student_list.ItemsSource = null;
            //student_list.ItemsSource = studentControl.GetViewableList();
            //StudentManagement newWindow = new StudentManagement();
            //newWindow.student_list.ItemsSource = studentControl.GetViewableList();
            //newWindow.Show();
            StudentControl newStudentControl = new StudentControl();
            newStudentControl = (StudentControl)(Application.Current.FindResource(STUDENT_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            student_list.ItemsSource = newStudentControl.GetViewableList();
            //this.Close();
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = (int)int.Parse(IDText.Text);
            studentControl.DeleteStudent(id);
            student_list.ItemsSource = null;
            student_list.ItemsSource = studentControl.GetViewableList();
            //StudentManagement newWindow = new StudentManagement();
            //newWindow.student_list.ItemsSource = studentControl.GetViewableList();
            //newWindow.Show();
            //this.Close();
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            string givenName = FirstNameText.Text;
            string familyName = LastNameText.Text;
            int id = int.Parse(IDText.Text);
            int groupID = int.Parse(GroupIDText.Text);
            string title = TitleText.Text;
            string campus = CampusText.Text;
            string phone = PhoneText.Text;
            string email = EmailText.Text;
            string category = CategoryText.Text;
            studentControl.UpdateStudent(givenName, familyName, id, groupID, title, campus, phone, email, category);
            student_list.ItemsSource = null;
            student_list.ItemsSource = studentControl.GetViewableList();
            //StudentManagement newWindow = new StudentManagement();
            //newWindow.student_list.ItemsSource = studentControl.GetViewableList();
            //newWindow.Show();
            //this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
