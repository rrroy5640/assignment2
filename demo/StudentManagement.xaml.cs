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

            }
        }
    }
}
