using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal class Group
    {
        private string groupName;
        private int groupID;

        public Group(string groupName, int groupID)
        {
            this.groupName = groupName;
            this.groupID = groupID;
        }

        public string GroupName { get => groupName; set => groupName = value; }
        public int GroupID { get => groupID; set => groupID = value; }
    }
}
