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
        StatusStrip console;
        Label display;

        private FAddToTable(string tableName)
        {
            InitializeComponent();
            TableName = tableName;
            Text = SQlToHumanTranslater.TranslateToHuman(tableName);
            StartPosition = FormStartPosition.CenterParent;
            table = SQLWorks.ExecuteQuery(string.Format("SELECT * FROM {0}", tableName));
            lastConrolPosition = new Point(10, -20);
            CreateForm();
        }
        /// <summary>
        /// Генерируем текстовые поля ввода пользовательских данных с жирной кнопкой в конце
        /// </summary>
        private void CreateForm()
        {

            ColumnNames = SQLWorks.ExecuteQuery(string.Format("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME != 'id' AND TABLE_NAME = '{0}'", tableName)).
               Rows.Cast<DataRow>().Select(row => row[0].ToString()).ToArray();
            editableControlList = new List<Control>();
            for (int i = 0; i < ColumnNames.Length; i++) AddField(ColumnNames[i]);
            Button insert = new Button()
            {
                Text = "Добавить",
                Location = LastConrolPosition,
                Size = new Size(this.Width - 10, 200),
                Font = new Font(Font.FontFamily,30)
            };
            insert.Click += new EventHandler(btnInsert_Click);
            Controls.Add(insert);

            display = new Label();
            console = new StatusStrip()
            {
                Dock = DockStyle.Bottom,
                Size = new Size(this.Width, 20),

            };
            console.Items.Add(new ToolStripControlHost(display));
            Controls.Add(console);
            AutoSize = true;
            Size += new Size(0, 50);//потому что статусбар не влазиет(
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            /*string s = string.Empty;
            s += editableControlList.Cast<Control>().Select(i =>SQlToHumanTranslater.TranslateToHuman(i.Name)).Aggregate((i, j) => i + "\r\n" + j);*/


           // MessageBox.Show(s);

            foreach(Control c in editableControlList)
            {
                if (string.IsNullOrWhiteSpace(c.Text))
                {
                    DisplayStatus(string.Format("Поле {0} не заполнено, ай - яй - яй", SQlToHumanTranslater.TranslateToHuman(c.Name)));
                    return;
                }
                if(c is ComboBox)
                {
                    if (!((ComboBox)c).Items.Contains(c.Text))
                    {
                        DisplayStatus(string.Format("Поле {0} не соответствует предложенному списку\n(нет в базе такой профессии, отдела и т.д.).\n Сперва туда внеси. А пока все плохо.", SQlToHumanTranslater.TranslateToHuman(c.Name)));
                        return;
                    }
                }
                DisplayStatus("Ладно, пойдет");
            }
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
        private static FAddToTable addForm;//тупо для хранения одиночки

        public static FAddToTable getAddForm(string tableName)
        {
            if (addForm == null || TableName != tableName)
                addForm = new FAddToTable(tableName);

            return addForm;
        }

        private static Point lastConrolPosition;
        /// <summary>
        /// положение последне добавленного конторола
        /// </summary>
        private static Point LastConrolPosition
        {
            get
            {
                Point.Add(lastConrolPosition, new Size(0, lastConrolPosition.Y += 35));
                return lastConrolPosition;
            }
        }

        List<Control> editableControlList;//список контролов на валидацию
        /// <summary>
        /// вставляет пару лэйбл - текстбокс аналогичный полю в БД
        /// </summary>
        /// <param name="name">Имя аналогичного столбца из БД</param>
        private void AddField(string name)//необходимо как то привести к паттерну стратегия
        {
            Label l = new Label()
            {
                Text = SQlToHumanTranslater.TranslateToHuman(name),
                Location = LastConrolPosition,
                Size = Size = new Size(500, 30)
            };
            string type = SQLWorks.ExecuteQuery(
                string.Format("SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", TableName, name)).Rows[0][0].ToString();
            Control c;
            if (name.ToUpper().Contains("ID") || type == "bit")//для поля пол в таблице Юзерс
            {
                c = new ComboBox()//вместо текстбокса - комбобокс
                {
                    AutoCompleteMode = AutoCompleteMode.Append,
                    AutoCompleteSource = AutoCompleteSource.ListItems
                 };

                if (name.ToLower() == "isman")//плохо
                {
                    ((ComboBox)c).Items.AddRange(new string[] { "муж", "жен" });
                }

                else
                {
                    ((ComboBox)c).Items.AddRange(
                          SQLWorks.getRelatedTable(name).Rows.Cast<DataRow>().Select(r => r[1].ToString()).ToArray<string>()
                    );
                }

            }

            else
            {
                c = new TextBox();

            }
            c.Name = name;
            c.Size = new Size(500, 30);
            c.Location = LastConrolPosition;
            c.Enabled = true;
            c.Font = new Font(Font.FontFamily, 15);

            editableControlList.Add(c);

            this.Controls.AddRange(new Control[] { l, c });

        }
        /// <summary>
        /// Вывод в статусбар (внизу формочки) сообщеньки
        /// </summary>
        /// <param name="message">сообщенька для показа</param>
        void DisplayStatus(string message)
        {
            display.Text = message;
        }

        bool CheckWritableControls()
        {
            bool flag = true;
            foreach(Control c in Controls)
            {
                if(c is TextBox || c is ComboBox)
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        
                        return false;
                    }
                }
            }
            return flag;
        }
    }
}
