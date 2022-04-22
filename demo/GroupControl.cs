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

        public void addGroup(Group g)
        {
            

        }

        public void deleteGroup()
        {
            throw new NotImplementedException();
        }

        public List<Group> listGroup()
        {
            throw new NotImplementedException();
        }

        public void updateGroup()
        {
            throw new NotImplementedException();
        }
    }
}
