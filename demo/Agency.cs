using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace demo
{
    internal class Agency
    {
        private const string db = "gmis";
        private const string user = "kit206g4";
        private const string pass = "group4";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;//instantiate a connection object

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

        public static List<Group> ListGroups()
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

        public static void addGroup (Group group)
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
            catch (MySqlException e)
            {

            }

            finally
            {
                conn.Close();
            }
        }

        public static void updateGroup (Group group)
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
            catch (MySqlException e)
            {

            }

            finally
            {
                conn.Close();
            }
        }

        public static void deleteGroup (Group group)
        {
            MySqlConnection conn = GetConnection();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from studentGroup where group_id = ?id", conn);
                cmd.Parameters.AddWithValue("id", group.GroupID);
                cmd.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {

            }

            finally
            {
                conn.Close();
            }
        }
        
    }
}
