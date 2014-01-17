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
        int a = 10;
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

        public void InsertTrafficKeyWord(string strKeyword , string strSearchVolume , string strKeywordCategory)
        {
           // MySqlCommand myCmd = new MySqlCommand();
            try
            {
                //OpenConnection();
                //string sql = "INSERT INTO KeywordsMatrics(ID_KeywordMatrics, Keyword_TrafficData,FK_KeywordList) VALUES (@id,@Keyword_TrafficData,@FK_KeywordList)";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_InsertKeywordMatrics";
                OpenConnection();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("KeywordTrafficData", strKeyword);
                cmd.Parameters.AddWithValue("FK_KeywordList", 1);
                cmd.Parameters.AddWithValue("Avg_MonthlySearchVolume", strSearchVolume);
                cmd.Parameters.AddWithValue("Keyword_Category", strKeywordCategory);
                cmd.Parameters.AddWithValue("ID_KeywordMatrics", MySqlDbType.Int32);
                cmd.Parameters["@ID_KeywordMatrics"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //("Inserted");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InserBulkTrafficData(string path)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "LOAD DATA LOCAL INFILE 'C:/Users/Canopus/Documents/GitHub/DemoApp/DemoApp/bin/Debug/MatricsData.txt' INTO TABLE googleadword.keywordsmatrics FIELDS TERMINATED BY '_' LINES TERMINATED BY '/r/n'";
                OpenConnection();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
