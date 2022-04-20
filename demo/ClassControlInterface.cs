using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal interface ClassControlInterface
    {
        void addClass();
        void deleteClass();
        void updateClass();
        List<Class> listClass();
    }
}
