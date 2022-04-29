using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Assignment2
{
    //this is the adapter class for Group
    internal class GroupAdapter
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

        public static List<Group> ListGroup()
        {
           List<Group> groups = new List<Group>();
           MySqlConnection conn = GetConnection();
           MySqlDataReader rdr = null;

           try
           {
               conn.Open();
               MySqlCommand cmd = new MySqlCommand("select group_id, group_name from studentGroup", conn);
               rdr = cmd.ExecuteReader();

               while (rdr.Read())
               {
                   groups.Add(new Group { GroupName = rdr.GetString(1), GroupID = rdr.GetInt32(0) });
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
            return groups;
        }

        //this method is to return a empty string if the reader reads a null value from database
        public static string SafeGetString(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        //this method is to return 0 if the reader reads a null value from database
        public static int SafeGetInt(MySqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return 0;
        }

        public static void AddGroup (Group group)
        {
            MySqlConnection conn = GetConnection();

            try
            {
               conn.Open();
               MySqlCommand cmd = new MySqlCommand("insert into studentGroup (group_id, group_name) values (?id, ?name)", conn);
              cmd.Parameters.AddWithValue("id", group.GroupID);
              cmd.Parameters.AddWithValue("name", group.GroupName);
              cmd.ExecuteNonQuery();
            }
            
            finally
            {
                conn.Close();
            }
        }

        public static void UpdateGroup(Group group)
        {
           MySqlConnection conn = GetConnection();

           try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("update studentGroup set group_name = ?name where group_id = ?id", conn);
                cmd.Parameters.AddWithValue("id", group.GroupID);
                cmd.Parameters.AddWithValue("name", group.GroupName);
                cmd.ExecuteNonQuery();

            }

            finally
            {
                conn.Close();
            }
        }

        public static void DeleteGroup (Group group)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
               MySqlCommand cmd = new MySqlCommand("delete from studentGroup where group_id = ?id", conn);
             cmd.Parameters.AddWithValue("id", group.GroupID);
                cmd.ExecuteNonQuery();

            }
            
            finally
            {
                conn.Close();
            }
        }  

    }
}
