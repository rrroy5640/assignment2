using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace demo
{
    //this is the controller class for student management
    internal class StudentControl :StudentControlInterface
    {
        private List<Student> students;
        public List<Student> Students { get { return students; } set { } }
        private ObservableCollection<Student> viewableStudents;
        public ObservableCollection<Student> ViewableStudents { get { return viewableStudents; } set { } }


        public StudentControl()
        {
            students = StudentAdapter.ListStudent();
            viewableStudents = new ObservableCollection<Student>(students);
        }


        public ObservableCollection<Student> GetViewableList()
        {
            return ViewableStudents;
        }

        public void AddStudent()
        {
            //Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            StudentAdapter.AddStudent();
            students = ListStudents();
            viewableStudents = new ObservableCollection<Student>(students);
        }

        public void DeleteStudent(int id)
        {
            //Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            StudentAdapter.DeleteStudent(id);
            students = ListStudents();
            viewableStudents = new ObservableCollection<Student>(students);
        }

        public List<Student> ListStudents()
        {
            return StudentAdapter.ListStudent();
        }


        public void UpdateStudent(string givenName, string familyName, int id, int groupID, string title, string campus, string phone, string email, string category)
        {

            if (givenName == string.Empty)
            {
                givenName = " ";
            }
            if (familyName == string.Empty)
            {
                familyName = " ";
            }
            //int groupID cannot be set to null, so there will be exception if you enter nothing for groupID when updating student info
            //it has to have a value that matches the existing foreign key values which were not implemented
            //if (groupID == null)
            //{
            //    groupID = 0;
            //}
            if (title == string.Empty)
            {
                title = " ";
            }    
            if (campus != "Hobart" || campus != "Launceston")
            {
                if (campus == string.Empty)
                {
                    campus = "";
                }
                else
                {
                    MessageBox.Show("campus should be Hobart or Launceston");
                }
            }
            if (category != "Bachelors" || category != "Masters")
            {
                if (category == string.Empty)
                {
                    category = "";
                }
                else
                {
                    MessageBox.Show("category should be Masters or Bachelors");

                }
            }
            
            if (phone == string.Empty)
            {
                phone = " ";
            }
            if ( email == string.Empty)
            {
                email = " ";
            }
            Student student = new Student(givenName, familyName, id, groupID, title, phone, email, campus, category);
            StudentAdapter.UpdateStudent(student);
            students = ListStudents();
            viewableStudents = new ObservableCollection<Student>(students);
        }
    }
}
