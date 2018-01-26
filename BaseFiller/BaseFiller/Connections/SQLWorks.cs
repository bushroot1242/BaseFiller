using System;
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
        //в перспективе заменить на динамическое формирование
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
        /// <summary>
        /// Получить список пользовательских таблиц
        /// </summary>
        /// <returns></returns>
        public static string[] getUserTablesNames()
        {
            DataTable table = SQLWorks.ExecuteQuery("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME != 'sysdiagrams'");
            //string s = string.Join(" ",table.Rows.Cast<DataRow>().Select(row => row["TABLE_NAME"].ToString()).ToArray());
            string[] hardNames = table.Rows.Cast<DataRow>().Select(row => row["TABLE_NAME"].ToString()).ToArray();
            // string[] fn = hardNames.Select(s => SQlToHumanTranslater.Translate(s)).ToArray();
            // List<string> friendlyNames = new List<string>(hardNames.Select(s =>SQlToHumanTranslater.Translate(s)).ToArray());
            return hardNames.Select(s => s).ToArray();

        }
        /// <summary>
        /// Получаем таблицу, на которую ссылается столбец с ИД
        /// </summary>
        /// <param name="foreignKeyName"></param>
        /// <returns></returns>
        public static DataTable getRelatedTable(string foreignKeyName)
        {
            string foreignKeyRelation, primaryKeyRelation, referentalTableName = string.Empty;
            try
            {
                //TABLE_CONSTRAINTS -> REFERENTIAL_CONSTRAINTS -> TABLE_CONSTRAINTS
                foreignKeyRelation = ExecuteQuery(string.Format("SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE COLUMN_NAME = '{0}'", foreignKeyName)).Rows[0][0].ToString();
                primaryKeyRelation = ExecuteQuery(string.Format("SELECT UNIQUE_CONSTRAINT_NAME FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME = '{0}'", foreignKeyRelation)).Rows[0][0].ToString();
                referentalTableName = ExecuteQuery(string.Format("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME = '{0}'", primaryKeyRelation)).Rows[0][0].ToString();
            }
            catch { }
            if (string.IsNullOrEmpty(referentalTableName))
                    return new DataTable();

            return ExecuteQuery(string.Format("SELECT * FROM {0}", referentalTableName));
        }
       
    }
}

