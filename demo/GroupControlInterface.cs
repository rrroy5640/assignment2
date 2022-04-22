using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal interface GroupControlInterface
    {
        void addGroup(string name, int id);
        void deleteGroup(string name, int id);
        void updateGroup(string name, int id);
        List<Group> listGroup();
    }
}
