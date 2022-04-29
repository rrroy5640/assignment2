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
    /// Interaction logic for GroupManagement.xaml
    /// </summary>
    public partial class GroupManagement : Window, INotifyPropertyChanged
    {
        private GroupControl GroupControl;
        private string GROUP_LIST_KEY = "GroupList";

        public event PropertyChangedEventHandler PropertyChanged;

        public Management()
        {
            InitializeComponent();
            groupControl = (GroupControl)(Application.Current.FindResource(GROUP_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void group_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                AddGroupPanel.DataContext = e.AddedItems[0];
                GroupNamePanel.DataContext = e.AddedItems[0];
                GroupIdPanel.DataContext = e.AddedItems[0];
               
            }
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            groupControl.AddGroup();
            group_list.ItemsSource = null;
            //group_list.ItemsSource = groupControl.GetViewableList();
            //GroupManagement newWindow = new GroupManagement();
            //newWindow.group_list.ItemsSource = groupControl.GetViewableList();
            //newWindow.Show();
            GroupControl newGroupControl = new GroupControl();
            newGroupControl = (GroupControl)(Application.Current.FindResource(GROUP_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            group_list.ItemsSource = newGroupControl.GetViewableList();
            //this.Close();
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = (int)int.Parse(IDText.Text);
            groupControl.DeleteStudent(id);
            group_list.ItemsSource = null;
            group_list.ItemsSource = groupControl.GetViewableList();
            //GroupManagement newWindow = new GroupManagement();
            //newWindow.group_list.ItemsSource = groupControl.GetViewableList();
            //newWindow.Show();
            //this.Close();
        }

        private void UpdateGroup_Click(object sender, RoutedEventArgs e)
        {
            AddGroupPanel.DataContext = e.AddedItems[0];
            GroupNamePanel.DataContext = e.AddedItems[0];
            GroupIdPanel.DataContext = e.AddedItems[0];
            groupControl.UpdateGroup( name, id);
            group_list.ItemsSource = null;
            group_list.ItemsSource = groupControl.GetViewableList();
            //GropuManagement newWindow = new GroupManagement();
            //newWindow.group_list.ItemsSource = groupControl.GetViewableList();
            //newWindow.Show();
            //this.Close();