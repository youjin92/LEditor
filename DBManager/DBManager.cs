using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager
{
    public class DBManager
    {
        public readonly string DBServerIP = "192.168.75.196";
        public readonly string Database = "member";
        public readonly string id = "root";
        public readonly string Pwd = "1q2w3e4r!!";

        MySqlConnection connection;

        public void Connect()
        {
            connection = new MySqlConnection($"Server={DBServerIP};Database={Database};Uid={id};Pwd={Pwd};");
        }

        public bool ExcuteCommand(string insertQuery, string name, int mmr)
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(insertQuery, connection);

            bool ret = false;

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine($"{new StackFrame(1, true).GetMethod().Name} Success => name : {name}, mmr : {mmr}");
                    ret = true;
                }
                else
                {
                    Console.WriteLine($"{new StackFrame(1, true).GetMethod().Name} Error => name : {name}, mmr : {mmr}"); 
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                ret = false;
            }

            connection.Close();
            return ret;
        }


        public void Insert(string name, int mmr)
        {
            string insertQuery = $"INSERT INTO member_table(name,mmr) VALUES('{name}', {mmr})";

            ExcuteCommand(insertQuery, name, mmr);
        }

        public void WriteMMR(string name, int mmr)
        {
            string insertQuery = $"UPDATE member.member_table SET mmr={mmr} WHERE name='{name}'";

            ExcuteCommand(insertQuery, name, mmr);
        }

        public void ReadDB(Action<string,int> action)
        {
            try
            {
                connection.Open();
                string sql = $"SELECT name, mmr FROM member.member_table";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    action(rdr[0].ToString(),Convert.ToInt32(rdr[1]));
                }

                rdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
