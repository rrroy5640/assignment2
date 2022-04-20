using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo
{
    internal class Student
    {
        public enum Campus { Hobart, Launceston};
        public enum Category { Bachelor, Master};

        private string firstName;
        private string lastName;
        private int id;
        private int groupId;
        private string title;
        private int phoneNumber;
        private string email;
        private Campus campus;
        private Category category;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Id { get => id; set => id = value; }
        public int GroupId { get => groupId; set => groupId = value; }
        public string Title { get => title; set => title = value; }
        public int PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
        internal Campus Campus1 { get => campus; set => campus = value; }
        internal Category Category1 { get => category; set => category = value; }

        public Student(string firstName, string lastName, int id, int groupId, string title, int phoneNumber, string email, Campus campus, Category category)
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
    }
}
