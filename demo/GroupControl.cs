using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demo
{
    internal class GroupControl : GroupControlInterface
    {
        public Agency conn = null;

       
        public void addGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.addGroup(group);
        }

        public void deleteGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.deleteGroup(group);
        }

        public List<Group> listGroup()
        {
            return Agency.ListGroups();
        }

        public void updateGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.updateGroup(group);
        }
    }
}
