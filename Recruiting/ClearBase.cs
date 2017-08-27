using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recruiting
{
    public partial class ClearBase : Form
    {
        public DateTime dateClear { set; get; }
        public string Table { set; get; }

        public ClearBase()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(checkBoxVacancy.Checked == true)
            {
                dateClear = dateTimePicker1.Value.Date;
                Table = "Vacancy";
                (this.MdiParent as MainForm).MainForm_ClearBase(this, EventArgs.Empty);
            }
            if (checkBoxResume.Checked == true)
            {
                dateClear = dateTimePicker2.Value.Date;
                Table = "Resume";
                (this.MdiParent as MainForm).MainForm_ClearBase(this, EventArgs.Empty);
            }
        }
    }
}
