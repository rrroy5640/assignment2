using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace demo
{
    internal class StudentControl :StudentControlInterface
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

        public void AddStudent()
        {
            //Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.AddStudent();
            students = ListStudents();
        }

        public void DeleteStudent(int id)
        {
            //Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.DeleteStudent(id);
            students = ListStudents();

        }

        public List<Student> ListStudents()
        {
            return Agency.ListStudent();
        }


        public void UpdateStudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category)
        {
            Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            Agency.UpdateStudent(student);
            students = ListStudents();
        }
    }
}
