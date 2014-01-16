using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201309;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
namespace GoogleAdword
{
    public class ExampleUtilities
    {
        string conStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        MySqlConnection con = null;
        public static string FormatException(Exception ex)
        {
            List<String> messages = new List<string>();
            Exception rootEx = ex;
            while (rootEx != null)
            {
                messages.Add(String.Format("{0} ({1})\n\n{2}\n", rootEx.GetType().ToString(),
                    rootEx.Message, rootEx.StackTrace));
                rootEx = rootEx.InnerException;
            }
            return String.Join("\nCaused by\n\n", messages.ToArray());
        }

        public bool OpenConnection()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                con = new MySqlConnection(conStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    cmd.Connection = con;
                }
                return true;
                
                //con.Open(); 
                //String cmdText = "INSERT INTO myTable(name) VALUES(@name)";
                //MySqlCommand cmd = new MySqlCommand(cmdText, con);
                //cmd.Prepare();
                ////we will bound a value to the placeholder
                //cmd.Parameters.AddWithValue("@name", "your value here");
                //cmd.ExecuteNonQuery(); //execute the mysql command
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
                return false;
            }
            finally
            {
                //if (con != null)
                //{
                //    con.Close(); //close the connection
                //}

            }
        }

        public bool CloseConnection()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                con = new MySqlConnection(conStr);
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    cmd.Dispose();
                }
                return true;
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close(); //close the connection
                }

            }
        }

        public void InsertTrafficKeyWord(string strKeyword)
        {
           // MySqlCommand myCmd = new MySqlCommand();
            try
            {
                OpenConnection();
                string sql = "INSERT INTO KeywordsMatrics(ID_KeywordMatrics, Keyword_TrafficData,FK_KeywordList) VALUES (@id,@Keyword_TrafficData,@FK_KeywordList)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@Keyword_TrafficData", strKeyword);
                cmd.Parameters.AddWithValue("@FK_KeywordList", 1);
                cmd.ExecuteNonQuery();
                //("Inserted");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
