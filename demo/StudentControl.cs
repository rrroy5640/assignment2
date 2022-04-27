using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace demo
{
    internal class StudentControl 
    {
        private List<Student> students;
        public List<Student> Students { get { return students; } set { } }
        private ObservableCollection<Student> viewableStudents;
        public ObservableCollection<Student> ViewableStudents { get { return viewableStudents; } set { } }


        public StudentControl()
        {
            students = Agency.ListStudent();
            viewableStudents = new ObservableCollection<Student>(students);
        }


        public ObservableCollection<Student> GetViewableList()
        {
            return ViewableStudents;
        }

        public void Addstudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category)
        {
            Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.AddStudent(student);
        }

        public void Deletestudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category)
        {
            Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.DeleteStudent(student);
        }

        public List<Student> Liststudents()
        {
            return Agency.ListStudent();
        }


        public void Updatestudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category)
        {
            Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.UpdateStudent(student);
        }
    }
}
