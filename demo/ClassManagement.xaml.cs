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

namespace demo
{
    /// <summary>
    /// Interaction logic for ClassManagement.xaml
    /// </summary>
    public partial class ClassManagement : Window, INotifyPropertyChanged
    {
        private ClassControl classControl;
        private string CLASS_LIST_KEY = "classList";

        public event PropertyChangedEventHandler PropertyChanged;
        public ClassManagement()
        {
            InitializeComponent();
            classControl = (ClassControl)(Application.Current.FindResource(CLASS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }





        private void class_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ClassIDPanel.DataContext = e.AddedItems[0];
                GroupIDPanel.DataContext = e.AddedItems[0];
                DayPanel.DataContext = e.AddedItems[0];
                StartTimePanel.DataContext = e.AddedItems[0];
                EndTimePanel.DataContext = e.AddedItems[0];
                RoomPanel.DataContext = e.AddedItems[0];
            }

        }

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            classControl.AddClass();
            //UIList.ItemsSource = null;
            //class_list.ItemsSource = classControl.GetViewableList();
            //ClassManagement newWindow = new ClassManagement();
            //newWindow.class_list.ItemsSource = classControl.GetViewableList();
            //newWindow.Show();
            ClassControl newClassControl = new ClassControl();
            newClassControl = (ClassControl)(Application.Current.FindResource(CLASS_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            //UIList.ItemsSource = newClassControl.GetviewableList();
            //this.Close();

        }

        private void DeleteClass_Click(object sender, RoutedEventArgs e)
        {
            int ID;
            ID = (int)int.Parse(ClassIdText.Text);
            classControl.DeleteClass(ID);
            //UIList.ItemsSource = null;
            //UIList.ItemsSource = classControl.GetviewableList();
            //classManagement newWindow = new ClassManagement();
            //newWindow.UIList.ItemsSource = classControl.GetViewableList();
            //newWindow.Show();
            //this.Close();

        }
    }

}
