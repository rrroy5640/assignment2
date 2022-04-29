using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment2
{
    internal class ClassAdapter
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
        //   List<Group> groups = new List<Group>();
        //   MySqlConnection conn = GetConnection();
        //   MySqlDataReader rdr = null;

        //   try
        //   {
        //       conn.Open();
        //       MySqlCommand cmd = new MySqlCommand("select group_id, group_name from studentGroup", conn);
        //       rdr = cmd.ExecuteReader();

        //       while (rdr.Read())
        //      {
        //          groups.Add(new Group { GroupName = rdr.GetString(1), GroupID = rdr.GetInt32(0) });
        //       }
        //   }

        //  catch (MySqlException e)
        //  {
        //        throw e;
        //    }
        //    finally
        //    {
        //       if (rdr != null)
        //       rdr.Close();
        //       if (conn != null)
        //      conn.Close();
        //  }
        //    return groups;
        //}

        //this method is to return a empty string if the reader reads a null value from database
        //public static string SafeGetString(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetString(colIndex);
        //    return string.Empty;
        //}

        //public static string SafeGetStringCampus(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetString(colIndex);
        //   return "nowhere";
        //}
        //public static string SafeGetStringCategory(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetString(colIndex);
        //    return "nothing";
        //}

        ////this method is to return 0 if the reader reads a null value from database
        //public static int SafeGetInt(MySqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //        return reader.GetInt32(colIndex);
        //    return 0;
        //}


        //public static List<Student> ListStudent()
        //{
        //    List<Student> students = new List<Student>();
        //    MySqlConnection conn = GetConnection();
        //    MySqlDataReader rdr = null;



        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select student_id, given_name, family_name, group_id, title, campus, phone, email, category from student", conn);
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            students.Add(new Student(SafeGetString(rdr, 1), SafeGetString(rdr, 2), SafeGetInt(rdr, 0), SafeGetInt(rdr, 3),
        //                SafeGetString(rdr, 4), SafeGetString(rdr, 6), SafeGetString(rdr, 7), SafeGetString(rdr, 5),
        //                SafeGetString(rdr, 8)));
        //        }
        //    }

        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        if (rdr != null)
        //            rdr.Close();
        //        if (conn != null)
        //            conn.Close();
        //    }
        //    return students;
        //}

        //public static void AddGroup (Group group)
        //{
        //    MySqlConnection conn = GetConnection();

        //   try
        //   {
        //       conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("insert into studentGroup (group_id, group_name) values (?id, ?name)", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.Parameters.AddWithValue("name", group.GroupName);
        //        cmd.ExecuteNonQuery();
        //    }

        //    finally
        //    {
        //        conn.Close();
        //   }
        //}


        ////this method is to add a empty student object in database with a random id
        //public static void AddStudent()
        //{
        //    MySqlConnection conn = GetConnection();
        //    Random rd = new Random();
        //    int id = rd.Next(100000, 999999); //generate a random number for id, this could cause exception if this id already exist in database

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("insert into student (student_id, given_name, family_name, group_id, title, campus, phone, email, photo, category) " +
        //            "values ( ?id, '', '', null, null, '', null, null, null, null)", conn);
        //        cmd.Parameters.AddWithValue("id", id);
        //        //cmd.Parameters.AddWithValue("givenName",student.FirstName);
        //        //cmd.Parameters.AddWithValue("familyName", student.LastName);
        //        //cmd.Parameters.AddWithValue("groupID", student.GroupId);
        //        //cmd.Parameters.AddWithValue("title", student.Title);
        //        //cmd.Parameters.AddWithValue("campus", student.Campus1);
        //        //cmd.Parameters.AddWithValue("phone", student.PhoneNumber);
        //        //cmd.Parameters.AddWithValue("email", student.Email);
        //        //cmd.Parameters.AddWithValue("category", student.Category1);
        //        cmd.ExecuteNonQuery();
        //    }

        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        ////this method is to update the student info where id is assigned
        //public static void UpdateStudent(Student student)
        //{
        //    MySqlConnection conn = GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("update student set given_name = ?givenName, family_name = ?familyName, group_id = ?groupID, title = ?title, campus = ?campus, phone = ?phone, email = ?email, category = ?category where student_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", student.Id);
        //        cmd.Parameters.AddWithValue("givenName", student.FirstName);
        //        cmd.Parameters.AddWithValue("familyName", student.LastName);
        //        cmd.Parameters.AddWithValue("groupID", student.GroupId);
        //        cmd.Parameters.AddWithValue("title", student.Title);
        //        cmd.Parameters.AddWithValue("campus", student.Campus1);
        //        cmd.Parameters.AddWithValue("phone", student.PhoneNumber);
        //        cmd.Parameters.AddWithValue("email", student.Email);
        //        cmd.Parameters.AddWithValue("category", student.Category1);
        //        cmd.ExecuteNonQuery();
        //    }

        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        //public static void UpdateGroup(Group group)
        //{
        //   MySqlConnection conn = GetConnection();

        //   try
        //    {
        //       conn.Open();
        //       MySqlCommand cmd = new MySqlCommand("update studentGroup set group_name = ?name where group_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.Parameters.AddWithValue("name", group.GroupName);
        //        cmd.ExecuteNonQuery();

        //    }


        //    finally
        //   {
        //       conn.Close();
        //    }
        //}

        //public static void DeleteGroup (Group group)
        //{
        //   MySqlConnection conn = GetConnection();

        //   try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("delete from studentGroup where group_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", group.GroupID);
        //        cmd.ExecuteNonQuery();

        //    }


        //   finally
        //   {
        //       conn.Close();
        //   }
        //}

        ////this method is to delete a student object in database with assigned id
        //public static void DeleteStudent(int id)
        //{
        //    MySqlConnection conn = GetConnection();

        //    try
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("delete from student where student_id = ?id", conn);
        //        cmd.Parameters.AddWithValue("id", id);
        //        cmd.ExecuteNonQuery();
        //    }


        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }
        public static int SafeGetInt(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return 0;
        }

        public static void AddClass ()
        {
            MySqlConnection conn = GetConnection();
            Random rd = new Random();
            int ClassId = rd.Next();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into class (class_id, group_id, day, start, end, room) values (?class_ID, null, '', '', '', '' )", conn);
                cmd.Parameters.AddWithValue("classID", ClassId);
                //cmd.Parameters.AddWithValue("groupID", classroom.GroupID);
                //cmd.Parameters.AddWithValue("startTime", classroom.StartTime);
                //cmd.Parameters.AddWithValue("endTime", classroom.EndTime);
                //cmd.Parameters.AddWithValue("room", classroom.Room);
                cmd.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
            }
        }

        //retrive Class List
        public static List<Class> ListClass()
        {
            List<Class> Classes = new List<Class>(); 
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;



            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select class_id, group_id, day, start, end, room from class", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())                                 
                {
                    Classes.Add(new Class { Room = SafeGetString(rdr,5), EndTime = SafeGetString(rdr,4), StartTime = SafeGetString(rdr,3),Day = SafeGetString(rdr,2), GroupID = SafeGetInt(rdr,1), ClassID = SafeGetInt(rdr,0) });
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
            return Classes;
        }

        public static void DeleteClass( int class_id)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from class where class_id = ?class_id", conn);
                cmd.Parameters.AddWithValue("classID", class_id);
                cmd.ExecuteNonQuery();

            }


            finally
            {
                conn.Close();
            }
        }

    }
}

