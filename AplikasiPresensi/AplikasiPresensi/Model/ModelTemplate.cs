using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace AplikasiPresensi.Model
{
    class ModelTemplate
    {
        private static SqlConnection conn;
        private SqlCommand command;
        private bool result;

        public static SqlConnection GetConnection()
        {
            conn = new SqlConnection();

            conn.ConnectionString = "Data Source = MSI;" +
                                    "Initial Catalog = presensi;" +
                                    "Integrated Security = True";
            return conn;
        }

        public DataSet Select(string tabel, string kondisi) //function select data (read)
        {
            DataSet dataSet = new DataSet();

            try
            {
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                if (kondisi == null)
                {
                    command.CommandText = "SELECT * FROM " + tabel;
                }
                else
                {
                    command.CommandText = "SELECT * FROM " + tabel + " WHERE " + kondisi;
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataSet, tabel);
            }
            catch (SqlException)
            {
                dataSet = null;
            }

            conn.Close();
            return dataSet;
        }

        public Boolean Insert(string tabel, string data) //insert data (create)
        {
            result = false;
            
            try
            {
                string query = "INSERT INTO " + tabel + " VALUES (" + data + ")";
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        public Boolean Update(string tabel, string data, string kondisi) //update data (update)
        {
            result = false;
            
            try{
                string query = "UPDATE " + tabel + " SET " + data + " WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }

        public Boolean Delete(string tabel, string kondisi) //delete data (delete)
        {
            result = false;

            try
            {
                string query = "DELETE FROM " + tabel + "WHERE " + kondisi;
                conn.Open();
                command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            {
                result = false;
            }
            conn.Close();
            return result;
        }
    }

    
}
