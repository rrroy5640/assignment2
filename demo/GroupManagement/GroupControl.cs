using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assignment2
{
    internal class GroupControl 
    {
        private List<Group> groups;
        public List<Group> Groups { get { return groups; } set { } }
        private ObservableCollection<Group> viewableGroups;
        public ObservableCollection<Group> ViewableGroups { get { return viewableGroups; } set { } }

        public ObservableCollection<Group> GetViewableList()
        {
            return ViewableGroups;
        }

        public void AddGroup(string name, int id)
        {
           Group group = new Group { GroupName = name, GroupID = id };
            GroupAdapter.AddGroup(group);
        }

        public void DeleteGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
             GroupAdapter.DeleteGroup(group);
        }

        public List<Group> ListGroups()
        {
            return GroupAdapter.ListGroup();
        }

        public void UpdateGroup(string name, int id)
        {
           Group group = new Group { GroupName = name, GroupID = id };
            GroupAdapter.UpdateGroup(group);
        }
    }
}
