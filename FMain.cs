using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseFiller.Connections;
using System.Net;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading;
using BaseFiller.View;

namespace BaseFiller
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            try
            {
                using (FWait wait = new FWait(new Action(() => getTablesList())))
                    wait.ShowDialog(this);
                cbTablesList.SelectedIndex = 0;

                string mas = string.Join(",",AllColumnsOfTables());

            }
            catch(Exception e)
            {
                DisplayStatus(e.Message);
            }
        }
       

        string[] ColumnsOfTable(string tableName)
        {
            DataTable table = SQLWorks.ExecuteQuery("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS");
            return table.Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToArray();
        }

        string[] AllColumnsOfTables()
        {
            DataTable table = SQLWorks.ExecuteQuery("SELECT DISTINCT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS where table_name <> 'sysdiagrams'");
            return table.Rows.Cast<DataRow>().Select(r => r[0].ToString()).ToArray();
        }
        void getTablesList()
        {
            try
            {
                DataTable table = SQLWorks.ExecuteQuery("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME != 'sysdiagrams'");

                
                
                //string s = string.Join(" ",table.Rows.Cast<DataRow>().Select(row => row["TABLE_NAME"].ToString()).ToArray());

                string[] hardNames = table.Rows.Cast<DataRow>().Select(row => row["TABLE_NAME"].ToString()).ToArray();



               // string[] fn = hardNames.Select(s => SQlToHumanTranslater.Translate(s)).ToArray();

               // List<string> friendlyNames = new List<string>(hardNames.Select(s =>SQlToHumanTranslater.Translate(s)).ToArray());

                cbTablesList.Items.AddRange(hardNames.Select(s => SQlToHumanTranslater.TranslateToHuman(s)).ToArray());

            }
            catch (Exception e)
            {
                DisplayStatus(e.Message);
            }
        }

        
        private void butGetAdress_Click(object sender, EventArgs e)
        {
            try
            {
                using (FWait wait = new FWait(() =>
                 {
                     DataTable srvsNames = SQLWorks.ExecuteQuery("SELECT * FROM Users");
                     dgvTableView.Invoke(new Action(() => dgvTableView.DataSource = srvsNames));
                 }))
                    wait.ShowDialog(this);
            }
            catch (Exception ex)
            {
                DisplayStatus(ex.Message);
            }

            #region
            //tbAdress.Text = NetWorks.ServersIp(tbPcName.Text);
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;


            //DataTable table = instance.GetDataSources();
            //dataGridView1.DataSource = NetWorks.GetSQLServerNames();


            //comboBox2.DataSource = table;
            // comboBox2.ValueMember = table.Columns[0].ColumnName;
            #endregion
        }
        /*
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbAvailableSQLInstaces.Enabled = true;
            string selected = (sender as ComboBox).Text;
            cbAvailableSQLInstaces.Items.AddRange(NetWorks.GetSQLInstance(selected));
            cbAvailableSQLInstaces.SelectedIndex = 0;
        }
        */
 

        private void cbTablesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                DataTable table = SQLWorks.ExecuteQuery(string.Format("SELECT * FROM {0}", SQlToHumanTranslater.TranslateToSQL(((ComboBox)sender).Text)));
                dgvTableView.DataSource = table;
                DataTableDecorator();
            }
           
            catch (Exception ex)
            {
                DisplayStatus(ex.Message);
            }


            /*
                SqlCommand cmd = new SqlCommand(command, connection);

                var result = cmd.BeginExecuteReader();
                while (!result.IsCompleted)
                {


                }

                using (SqlDataReader reader = cmd.EndExecuteReader(result))
                {
                    DataTable table = new DataTable();
                    table.Load(reader);
                    dataGridView1.DataSource = table;
                }*/


            //}



        }

        void DisplayStatus(string status)
        {
            ssConsole.Text = status;
        }
        void DataTableDecorator()
        {
            int colSize = dgvTableView.Width/dgvTableView.Columns.Count;
            foreach (DataGridViewColumn col in dgvTableView.Columns)
            {
                col.Width = colSize;
                col.HeaderText = SQlToHumanTranslater.TranslateToHuman(col.HeaderText);

            }
            
        }
        
    }
}
