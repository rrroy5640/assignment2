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
using System.Collections.ObjectModel;

namespace demo
{
    /// <summary>
    /// Interaction logic for GroupManagement.xaml
    /// </summary>
    public partial class GroupManagement : Window
    {
        //GroupControl gControl = new GroupControl();
        //private const string GROUP_LIST_KEY = "groupList";
        public GroupManagement()
        {
            InitializeComponent();
            //gControl = (GroupControl)(Application.Current.FindResource(GROUP_LIST_KEY) as ObjectDataProvider).ObjectInstance;

        }
    }
}
