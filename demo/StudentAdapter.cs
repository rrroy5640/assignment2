using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Windows;

namespace demo
{
    //this is the adapter class for student
    internal class StudentAdapter
    {
        private const string db = "gmis";
        private const string user = "kit206g4";
        private const string pass = "group4";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        //public static List<Group> ListGroup()
        //{
        //    List<Group> groups = new List<Group>();
        //    MySqlConnection conn = GetConnection();
        //    MySqlDataReader rdr = null;

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select group_id, group_name from studentGroup", conn);
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            groups.Add(new Group { GroupName = rdr.GetString(1), GroupID = rdr.GetInt32(0) });
        //        }
        //    }

        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        if (rdr != null)
        //        rdr.Close();
        //        if (conn != null)
        //        conn.Close();
        //    }
        //    return groups;
        //}

        //this method is to return a empty string if the reader reads a null value from database
        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        //public static string SafeGetStringCampus(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetString(colIndex);
        //    return "nowhere";
        //}
        //public static string SafeGetStringCategory(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetString(colIndex);
        //    return "nothing";
        //}

        //this method is to return 0 if the reader reads a null value from database
        public static int SafeGetInt(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return 0;
        }

        public static List<Student> ListStudent()
        {
            List<Student> students = new List<Student>();
            List<Student> orderedStudents = new List<Student>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select student_id, given_name, family_name, group_id, title, campus, phone, email, category from student", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Add(new Student(SafeGetString(rdr, 1), SafeGetString(rdr, 2), SafeGetInt(rdr,0), SafeGetInt(rdr, 3),
                        SafeGetString(rdr, 4), SafeGetString(rdr, 6), SafeGetString(rdr, 7), SafeGetString(rdr, 5),
                        SafeGetString(rdr, 8)));
                }
            }

            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (conn != null)
                    conn.Close();
            }
            var ordered = from Student e in students orderby e.FirstName select e; //order student list by linq
            orderedStudents = new List<Student>(ordered);
            return orderedStudents;
        }

        //public static void AddGroup (Group group)
        //{
        //    MySqlConnection conn = GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("insert into studentGroup (group_id, group_name) values (?id, ?name)", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.Parameters.AddWithValue("name", group.GroupName);
        //        cmd.ExecuteNonQuery();
        //    }
            
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}


        //this method is to add a empty student object in database with a random id
        public static void AddStudent()
        {
            MySqlConnection conn = GetConnection();
            Random rd = new Random();
            int id = rd.Next(100000, 999999); //generate a random number for id, this could cause exception if this id already exist in database

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into student (student_id, given_name, family_name, group_id, title, campus, phone, email, photo, category) " +
                    "values ( ?id, '', '', null, null, '', null, null, null, null)", conn);
                cmd.Parameters.AddWithValue("id", id);
                //cmd.Parameters.AddWithValue("givenName",student.FirstName);
                //cmd.Parameters.AddWithValue("familyName", student.LastName);
                //cmd.Parameters.AddWithValue("groupID", student.GroupId);
                //cmd.Parameters.AddWithValue("title", student.Title);
                //cmd.Parameters.AddWithValue("campus", student.Campus1);
                //cmd.Parameters.AddWithValue("phone", student.PhoneNumber);
                //cmd.Parameters.AddWithValue("email", student.Email);
                //cmd.Parameters.AddWithValue("category", student.Category1);
                cmd.ExecuteNonQuery();            
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception occured, details:\n" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        //this method is to update the student info where id is assigned
        public static void UpdateStudent (Student student)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update student set given_name = ?givenName, family_name = ?familyName, group_id = ?groupID, title = ?title, campus = ?campus, phone = ?phone, email = ?email, category = ?category where student_id = ?id", conn);
                cmd.Parameters.AddWithValue("id", student.Id);
                cmd.Parameters.AddWithValue("givenName", student.FirstName);
                cmd.Parameters.AddWithValue("familyName", student.LastName);
                cmd.Parameters.AddWithValue("groupID", student.GroupId);
                cmd.Parameters.AddWithValue("title", student.Title);
                cmd.Parameters.AddWithValue("campus", student.Campus1);
                cmd.Parameters.AddWithValue("phone", student.PhoneNumber);
                cmd.Parameters.AddWithValue("email", student.Email);
                cmd.Parameters.AddWithValue("category", student.Category1);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                ReportSqlError(e);
            }
  
            finally
            {
                conn.Close();
            }
        }

        //public static void UpdateGroup(Group group)
        //{
        //    MySqlConnection conn = GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("update studentGroup set group_name = ?name where group_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.Parameters.AddWithValue("name", group.GroupName);
        //        cmd.ExecuteNonQuery();

        //    }


        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static void DeleteGroup (Group group)
        //{
        //    MySqlConnection conn = GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("delete from studentGroup where group_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.ExecuteNonQuery();

        //    }
            

        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //this method is to delete a student object in database with assigned id
        public static void DeleteStudent(int id)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from student where student_id = ?id", conn);
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception occured, details:\n" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        private static void ReportSqlError(Exception e)
        {
            MessageBox.Show("An SQL related exception occured.\n" +
                "This exception might be caused because null values are entered in some textboxes, or values are not legal.\n"+
                "groupID should be valid existing int, check what id are available in group management.\n" +
                "campus should be Launceston or Hobart, category should be Masters or Bachelors, or just leave them empty\n" +
                "exception details:\n" +
                e);
        }

    }
}
