﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFiller.Connections
{
    class SQLWorks
    {
        private static string connectionString = @"Data Source=NTC-IT-DIR\INVENTARY;Initial Catalog=Inventary;Integrated Security=true;";

        /// <summary>
        /// Строка подключения
        /// </summary>
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        private static SqlConnection sqlConnection;

        /// <summary>
        /// экземпляр подключения к серверу
        /// </summary>
        public static SqlConnection SQLConnection
        {
            get
            {
                sqlConnection = new SqlConnection(ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            }

        }
        

        /// <summary>
        /// использовать для delete, insert, update, корорче если ничего не возвращаем
        /// </summary>
        /// <param name="command">SQL запрос без возвращаемого значения</param>
        public static void ExecuteCommand(string command)
        {
            using (SQLConnection)
            {
                SqlCommand cmd = new SqlCommand(command, SQLConnection);
                cmd.ExecuteNonQuery();
            }
            #region врядли пригодится
            /*
             while (!result.IsCompleted)
                {
                    
                }

                using (SqlDataReader reader = cmd.EndExecuteReader(result))
                {
                    DataTable table = new DataTable(), table1 = new DataTable();
                    table.Load(reader);

                    //cbTablesList.Items.AddRange(table.Rows.Cast<DataRow>().Select(row => row["table_name"].ToString()).ToArray());

                }*/
            #endregion
        }


        /// <summary>
        /// Если нужно что то вытащить с базы
        /// </summary>
        /// <param name="command">Строка команды ЭСкуЭль</param>
        /// <param name="connection">Экземпляр подключения к базе</param>
        /// <returns></returns>
        public static DataTable ExecuteQuery(string command)
        {
            DataTable table = new DataTable();
            using (SQLConnection)
            {
                SqlCommand cmd = new SqlCommand(command, SQLConnection);
                var result = cmd.BeginExecuteReader();
                while (!result.IsCompleted) { }
               
                using (SqlDataReader reader = cmd.EndExecuteReader(result))
                {
                    table.Load(reader);
                }
            }
            return table;
        }
    }
}
