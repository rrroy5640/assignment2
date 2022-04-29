using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    public class Student
    {

        private string firstName;
        private string lastName;
        private int id;
        private int groupId = 0;
        private string title;
        private string phoneNumber;
        private string email;
        private string campus;
        private string category;
        private System.Windows.Media.ImageSource photo;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Id { get => id; set => id = value; }
        public int GroupId { get => groupId; set => groupId = value; }
        public string Title { get => title; set => title = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        public string Campus1 { get => campus; set => campus = value; }
        public string Category1 { get => category; set => category = value; }


        public Student(string firstName, string lastName, int id, int groupId, string title, string phoneNumber, string email, string campus, string category)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.id = id;
            this.groupId = groupId;
            this.title = title;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.campus = campus;
            this.category = category;
        }

        public override string ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
