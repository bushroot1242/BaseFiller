using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseFiller.View;
using BaseFiller.Connections;


namespace BaseFiller
{
    /// <summary>
    /// Форма добавления чего то в базу. Поля генерирует динамически. Одиночка. Инициализировать через GetAddForm.
    /// </summary>
    public partial class FAddToTable : Form
    {

        private FAddToTable(string tableName)
        {
            InitializeComponent();
            TableName = tableName;
            Text = SQlToHumanTranslater.TranslateToHuman(tableName);
            StartPosition = FormStartPosition.CenterParent;
            table = SQLWorks.ExecuteQuery(string.Format("SELECT * FROM {0}", tableName));
            lastConrolPosition = new Point(10, 10);
            ColumnNames = SQLWorks.ExecuteQuery(string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME != 'id' AND TABLE_NAME = '{0}'", tableName)).
                Rows.Cast<DataRow>().Select(row => row[0].ToString()).ToArray();
            for (int i = 0; i < ColumnNames.Length; i++) CreateForm(ColumnNames[i]);
            Size = new Size(600, (Controls.Count * 50)+200);

        }
        private string[] ColumnNames;
        DataTable table;
        private static string tableName;
        private static string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }
        private static FAddToTable addForm;

        public static FAddToTable getAddForm(string tableName)
        {
            if (addForm == null || TableName != tableName)
                addForm = new FAddToTable(tableName);

            return addForm;
        }

        private static Point lastConrolPosition;
        private static Point LastConrolPosition
        {
            get
            {
                Point.Add(lastConrolPosition, new Size(0, lastConrolPosition.Y += 35));
                return lastConrolPosition;
            }
        }

        void CreateForm(string name)
        {
            Label l = new Label()
            {
                Text = SQlToHumanTranslater.TranslateToHuman(name),
                Location = LastConrolPosition,
            };
            string type = SQLWorks.ExecuteQuery(
                string.Format("SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", TableName, name)).Rows[0][0].ToString();
            Control c;
            if (type != "bit")
            {
                c = new TextBox()
                {
                    Size = new Size(500, 30),
                    Location = LastConrolPosition,
                    Enabled = true,
                    //AutoSize = false,
                    Font = new Font(Font.FontFamily, 15)

                };
            }
            else
            {
                c = new ComboBox()
                {
                    Size = new Size(500, 30),
                    Location = LastConrolPosition,
                    Enabled = true,
                    Font = new Font(Font.FontFamily, 15)
                };
                ((ComboBox)c).Items.AddRange((new string[] { "муж", "жен" }));
            }

            this.Controls.Add(l);
            this.Controls.Add(c);
        }

    }
}
