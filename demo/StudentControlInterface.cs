using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demo
{
    internal interface StudentControlInterface
    {
        void addStudent();
        void deleteStudent();
        void updateStudent();
        List<Student> listStudent();
        
    }
}
