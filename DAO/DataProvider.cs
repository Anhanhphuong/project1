using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TrungNguyenCoffee.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance 
        { 
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }  
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private string connectionString = @"Data Source=LAPTOP-S7TLI0E9;Initial Catalog=Cf;Integrated Security=True;Trust Server Certificate=True";


        public DataTable ExecuteQuery(string query, object[]? parameter = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand command = new SqlCommand(query, cn);
                if (parameter != null)
                {
                    string[] Listpara = query.Split(' ');
                    int i = 0;
                    foreach (string s in Listpara)
                    {
                        if (s.Contains("@"))
                        {
                            command.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
                cn.Close();                
            }
            return dt;
        }
        public int ExecuteNonQuery(string query, object[]? parameter = null)
        {
            int dt = 0;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand command = new SqlCommand(query, cn);
                if (parameter != null)
                {
                    string[] Listpara = query.Split(' ');
                    int i = 0;
                    foreach (string s in Listpara)
                    {
                        if (s.Contains("@"))
                        {
                            command.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = command.ExecuteNonQuery();
                cn.Close();
            }
            return dt;
        }
        public object ExecuteScalar(string query, object[]? parameter = null)
        {
            object dt = 0;
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand command = new SqlCommand(query, cn);
                if (parameter != null)
                {
                    string[] Listpara = query.Split(' ');
                    int i = 0;
                    foreach (string s in Listpara)
                    {
                        if (s.Contains("@"))
                        {
                            command.Parameters.AddWithValue(s, parameter[i]);
                            i++;
                        }
                    }
                }
                dt = command.ExecuteScalar();
                cn.Close();
            }
            return dt;
        }
    }
}
