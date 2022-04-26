using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public interface GroupControlInterface
    {
        void AddGroup(string name, int id);
        void DeleteGroup(string name, int id);
        void UpdateGroup(string name, int id);
        List<Group> ListGroup();
    }
}
