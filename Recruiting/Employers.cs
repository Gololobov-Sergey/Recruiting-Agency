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

    public partial class Employers : Form, IMenu
    {
        public int IndexID { set; get; }
        public int IndexRow { set; get; }
        public DataTable DT { set; get; }
        public enum FormMode { Add, Edit}
        FormMode Mode;
        EmployerTable empl;

        public Employers()
        {
            InitializeComponent();
            this.Load += Employers_Load;
            ChangeID += Employers_ChangeID;

        }

        private void Employers_ChangeID(object sender, EventArgs e)
        {
            IndexRow = dataGridView1.CurrentRow.Index;

            if (IndexRow < DT.Rows.Count)
            {
                IndexID = (int)dataGridView1.Rows[IndexRow].Cells["ID"].Value;
                txtID.Text = IndexID.ToString();
                txtName.Text = (string)dataGridView1.Rows[IndexRow].Cells["Name"].Value;
                txtAdress.Text = (string)dataGridView1.Rows[IndexRow].Cells[2].Value;
                txtEmail.Text = (string)dataGridView1.Rows[IndexRow].Cells[3].Value;
                txtPhone.Text = (string)dataGridView1.Rows[IndexRow].Cells[4].Value;
                txtSite.Text = (string)dataGridView1.Rows[IndexRow].Cells[5].Value;
                txtDescription.Text = (string)dataGridView1.Rows[IndexRow].Cells[6].Value;
            }
        }

        public event EventHandler EmployerEvent;
        public event EventHandler VacancyEvent;
        public event EventHandler ChangeID;

        private void Employers_Load(object sender, EventArgs e)
        {
            BindingSource bs1 = new BindingSource();
            bs1.DataSource = DT;
            bindingNavigator1.BindingSource = bs1;
            dataGridView1.DataSource = bs1;

            if (ChangeID != null)
                ChangeID(sender, EventArgs.Empty);
        }

        public void RefreshForm()
        {
            BindingSource bs1 = new BindingSource();
            bs1.DataSource = DT;
            bindingNavigator1.BindingSource = bs1;
            dataGridView1.DataSource = bs1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChangeID != null)
                ChangeID(sender, EventArgs.Empty);
        }

        private void Employers_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void vacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (this.MdiParent as MainForm).vacancyToolStripMenuItem_Click(IndexID, e);
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (ChangeID != null)
                ChangeID(sender, EventArgs.Empty);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (ChangeID != null)
                ChangeID(sender, EventArgs.Empty);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Add;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            txtID.Text = (DT.Rows.Count+1).ToString();
            txtName.Text = null;
            txtAdress.Text = null;
            txtEmail.Text = null;
            txtPhone.Text = null;
            txtSite.Text = null;
            txtDescription.Text = null;
            butOk.Visible = true;
            butCancel.Visible = true;

        }

        private void butOk_Click(object sender, EventArgs e)
        {
            empl = new EmployerTable(Convert.ToInt32(txtID.Text), txtName.Text, txtAdress.Text, txtEmail.Text, txtPhone.Text, txtSite.Text, txtDescription.Text);

            switch (Mode)
            {
                case FormMode.Add:
                    (this.MdiParent as MainForm).MainForm_AddEmployer(empl, e);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    (this.MdiParent as MainForm).employersToolStripMenuItem_Click(sender, e);
                    break;
                case FormMode.Edit:
                    (this.MdiParent as MainForm).MainForm_EditEmployer(empl, e);
                    tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
                    (this.MdiParent as MainForm).employersToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
            butCancel_Click(sender, e);

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            if (ChangeID != null)
                ChangeID(sender, EventArgs.Empty);
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Edit;
            txtID.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            (this.MdiParent as MainForm).MainForm_DelEmployer(IndexID, e);

        }
    }
}
