using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseFiller
{
    public partial class FAddToTable : Form
    {
        private FAddToTable()
        {
            InitializeComponent();
        }

        private static FAddToTable addForm;

        public static FAddToTable getAddForm()
        {
            if (addForm == null)
                addForm = new FAddToTable();
            return addForm;
        }

    }
}
