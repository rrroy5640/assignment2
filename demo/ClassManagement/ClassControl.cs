using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo;
using MySql.Data.MySqlClient;


namespace demo
{
    internal class ClassControl
    {
        private List<Class> classes;
        public List<Class> Classess { get { return classes; } set { } }
        private ObservableCollection<Class> viewableClass;
        public ObservableCollection<Class> ViewableClass { get { return viewableClass; } set { } }


    public ClassControl()
        {
            classes = ClassAdapter.ListClass();
            viewableClass = new ObservableCollection<Class>(Classess);
        }

        public void AddClass()
        {
            
            ClassAdapter.AddClass();
        }

        public void DeleteClass (int class_id)
        {
            //Class DelClass = new Class { ClassID = class_id, GroupID = group_id, Day = day, StartTime = start_time, EndTime = end_time, Room = room };
            ClassAdapter.DeleteClass(class_id);
            classes = ListClass();
            viewableClass = new ObservableCollection<Class>(classes);
        }

        public static List<Class> ListClass()
        {
            return ClassAdapter.ListClass();
        }

        public ObservableCollection<Class> GetViewableList()
        {
            return viewableClass;
        }

        
    }
}
    

    

        
    

