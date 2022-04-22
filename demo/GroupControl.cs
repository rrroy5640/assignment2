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

       
        public void AddGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.AddGroup(group);
        }

        public void DeleteGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.DeleteGroup(group);
        }

        public List<Group> ListGroup()
        {
            return Agency.ListGroups();
        }

        public void UpdateGroup(string name, int id)
        {
            Group group = new Group { GroupName = name, GroupID = id };
            Agency.UpdateGroup(group);
        }
    }
}
