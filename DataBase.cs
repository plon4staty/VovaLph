﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace VovaLph
{
    public class DataBase : IDisposable
    {
        // private string _connectionString = @"Server = db.edu.cchgeu.ru;DataBase = 193_Mescheryakov;User = 193_Mescheryakov;Password = Itodor_23@";
        private string _connectionString = @"Data Source = DESKTOP-F5IFSAN\SQLEXPRESS; Initial Catalog = ecz; Integrated Security = True";
        private SqlConnection _connection;

        public DataBase()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        private void OpenConnection()
        {
            _connection.Open();
        }

        private void CloseConnection()
        {
            _connection.Close();
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(sql, _connection);
            table.Load(command.ExecuteReader());

            return table;
        }

        public void ExecuteNonQuery(string sql)
        {
            SqlCommand command = new SqlCommand(sql, _connection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
