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
    public static class NetWorks
    {
        private static DataTable dataTable;
        static NetWorks()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            dataTable = instance.GetDataSources();
        }

       
        public static string ServersIp(string hostName)
        {
            return ((IPAddress)(Dns.GetHostAddresses(hostName)[0])).ToString();
        }
        public static string ServersName(IPAddress ip)
        {
            return Dns.GetHostEntry(ip).HostName;
        }

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
