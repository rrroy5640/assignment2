using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal interface ClassControlInterface
    { 
        void AddClass();
        void DeleteClass(int class_id);
        List<Class> ListClassess();
    }
}
