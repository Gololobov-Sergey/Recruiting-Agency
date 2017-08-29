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

    public partial class EmployersForm : Form
    {
        public int ID { set; get; }
        public string FilterString { set; get; }
        List<string> listFilter = new List<string>();
        BindingSource bsEmployer;
        public DataTable DT { set; get; }
        public enum FormMode { Add, Edit, Filter}
        FormMode Mode;
        Employer empl;

        public EmployersForm()
        {
            InitializeComponent();
            this.Load += EmployersForm_Load;
        }

        void EmployersForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
            txtID.DataBindings.Add("Text", bsEmployer, "ID");
            txtName.DataBindings.Add("Text", bsEmployer, "Name");
            txtAdress.DataBindings.Add("Text", bsEmployer, "Adress");
            txtEmail.DataBindings.Add("Text", bsEmployer, "Email");
            txtPhone.DataBindings.Add("Text", bsEmployer, "Phone");
            txtSite.DataBindings.Add("Text", bsEmployer, "Site");
            txtDescription.DataBindings.Add("Text", bsEmployer, "Description");
        }
		
		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
		{
			Mode = FormMode.Add;
			tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
			butOk.Visible = true;
			butCancel.Visible = true;
            txtID.Text = (DT.Rows.Count + 1).ToString();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
		{
            ID = (int)((DataRowView)bsEmployer.Current).Row.ItemArray[0];
            bsEmployer.CancelEdit();
            (this.MdiParent as MainForm).MainForm_DelEmployer(ID, e);
            (this.MdiParent as MainForm).employersToolStripMenuItem_Click(sender, e);
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
		{
            Mode = FormMode.Edit;
			txtID.Enabled = false;
			tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
			butOk.Visible = true;
			butCancel.Visible = true;
		}
		
		 private void filterStripButton1_Click(object sender, EventArgs e)
		{

            bsEmployer.AddNew();
            Mode = FormMode.Filter;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case FormMode.Add:
                    empl = new Employer(1, txtName.Text, txtAdress.Text, 
                        txtEmail.Text, txtPhone.Text, txtSite.Text, txtDescription.Text);
                    (this.MdiParent as MainForm).MainForm_AddEmployer(empl, e);
                    break;
                case FormMode.Edit:
                    empl = new Employer(Convert.ToInt32(txtID.Text), txtName.Text, txtAdress.Text,
                        txtEmail.Text, txtPhone.Text, txtSite.Text, txtDescription.Text);
                    (this.MdiParent as MainForm).MainForm_EditEmployer(empl, e);
                    break;
                case FormMode.Filter:
                    SetFilterString();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                    dataGridView1.Refresh();
                    break;
                default:
                    break;
            }
            butCancel_Click(sender, e);
            (this.MdiParent as MainForm).employersToolStripMenuItem_Click(sender, e);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
        }
		
		private void Employers_FormClosing(object sender, FormClosingEventArgs e)
        {
            FilterString = null;
            e.Cancel = true;
            this.Hide();
        }
		
		private void vacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = string.Format("Name = '{0}'", (string)((DataRowView)bsEmployer.Current).Row.ItemArray[1]);
            (this.MdiParent as MainForm).vacancyToolStripMenuItem_Click(FilterString, e);
        }

        public void RefreshForm()
        {
            if (bsEmployer == null)
                bsEmployer = new BindingSource();
            bsEmployer.DataSource = DT;
            DT.DefaultView.RowFilter = FilterString;
            bindingNavigator1.BindingSource = bsEmployer;
            dataGridView1.DataSource = bsEmployer;
            if (FilterString != null)
                this.Text = "Employers (Filter: " + FilterString + ")";
            else
                this.Text = "Employers";
        }

        private void SetFilterString()
        {
            listFilter.Clear();

            if (txtName.Text != "")
            {
                FilterString = string.Format("Name LIKE '{0}'", txtName.Text);
                listFilter.Add(FilterString);
            }
            if (txtAdress.Text != "")
            {
                FilterString = string.Format("Adress LIKE '{0}'", txtAdress.Text);
                listFilter.Add(FilterString);
            }
            if (txtEmail.Text != "")
            {
                FilterString = string.Format("Email LIKE '{0}'", txtEmail.Text);
                listFilter.Add(FilterString);
            }
            if (txtPhone.Text != "")
            {
                FilterString = string.Format("Phone LIKE '{0}'", txtPhone.Text);
                listFilter.Add(FilterString);
            }
            if (txtSite.Text != "")
            {
                FilterString = string.Format("Site LIKE '{0}'", txtSite.Text);
                listFilter.Add(FilterString);
            }

            FilterString = string.Empty;
            for (int i = 0; i < listFilter.Count - 1; i++)
            {
                FilterString = listFilter[i] + " AND ";
            }
            if(listFilter.Count > 0)
                FilterString += listFilter[listFilter.Count - 1];
        }
    }
}
