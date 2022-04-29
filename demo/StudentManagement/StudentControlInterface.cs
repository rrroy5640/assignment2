using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment2
{
    internal interface StudentControlInterface
    {
        void AddStudent();
        void DeleteStudent(int id);
        void UpdateStudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category);
        List<Student> ListStudents();
        
    }
}
