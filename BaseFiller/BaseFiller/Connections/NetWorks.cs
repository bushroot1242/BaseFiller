using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Threading;



namespace BaseFiller.Connections
{
    /// <summary>
    /// В перспективе для универсализации работы с удаленным сервером SQL
    /// </summary>
    public static class NetWorks
    {
        private static DataTable dataTable;//буферная табличка
        static NetWorks()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;//получает все экземпляры SQL серверов В сети
            dataTable = instance.GetDataSources();
        }

        /// <summary>
        /// Вычислить IP по имени
        /// </summary>
        /// <param name="hostName"> имя компа</param>
        /// <returns></returns>
        public static string ServersIp(string hostName)
        {
            return ((IPAddress)(Dns.GetHostAddresses(hostName)[0])).ToString();
        }

        /// <summary>
        /// Вычислить имя по IP
        /// </summary>
        /// <param name="ip"> ip адрес</param>
        /// <returns></returns>
        public static string ServersName(IPAddress ip)
        {
            return Dns.GetHostEntry(ip).HostName;
        }
        /// <summary>
        /// Массив имен SQL серверов
        /// </summary>
        public static string[] SQLServerNames
        {
            get
            {
                if (sqlServerNames == null)
                {
                    Thread t = new Thread(delegate ()
                    {
                        sqlServerNames = GetSQLServerNames();
                    });
                    t.Start();
                    while (t.IsAlive)
                    {

                    }
                }
                    return sqlServerNames;
            }

        }

        private static string[] sqlServerNames;
        private static string[] GetSQLServerNames()
        {

            string[] mas = new string[dataTable.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                mas[i] = dr[0].ToString();
                i++;
            }
            return mas;
        }
        /// <summary>
        /// Получить список экземпляров БД с сервера
        /// </summary>
        /// <param name="serverName">Имя сервера</param>
        /// <returns></returns>
        public static string[] GetSQLInstance(string serverName)
        {

            List<string> list = new List<string>();
            foreach (DataRow dr in dataTable.Rows)
            {
                if(dr[0].ToString().Equals(serverName))
                    list.Add(dr[1].ToString());
            }

            return list.ToArray();

        }
    }
}
