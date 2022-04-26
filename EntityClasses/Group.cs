using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public class Group
    {
        private string groupName { set; get; }
        private int groupID { set; get; }

       

        public string GroupName { get => groupName; set => groupName = value; }
        public int GroupID { get => groupID; set => groupID = value; }
    }
}
