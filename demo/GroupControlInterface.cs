using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal interface GroupControlInterface
    {
        void addGroup();
        void deleteGroup();
        void updateGroup();
        List<Group> listGroup();
    }
}
