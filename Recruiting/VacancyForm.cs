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

    public partial class VacancyForm : Form
    {
        List<string> listFilter = new List<string> ();
        public string FilterString { set; get; }
        public DataTable DT { set; get; }
        public DataTable DTEmpl { set; get; }
        public DataTable DTPos { set; get; }
        public DataTable DTEduc { set; get; }
        public DataTable DTWork { set; get; }
        public DataTable DTSex { set; get; }
        public int ID { get; set; }

        BindingSource bsVacancy;

        public enum FormMode { Add, Edit, Filter }
        FormMode Mode;
        Vacancy vacancy;

        public VacancyForm()
        {
            InitializeComponent();
            this.Load += VacancyForm_Load;
        }

        private void VacancyForm_Load(object sender, EventArgs e)
        {
            RefreshForm();

            txtID.DataBindings.Add("Text", bsVacancy, "ID");

            cmbEmployer.DataSource = DTEmpl;
            cmbEmployer.ValueMember = "ID";
            cmbEmployer.DisplayMember = "Name";
            cmbEmployer.DataBindings.Add("Text", bsVacancy, "Name");

            cmbPosition.DataSource = DTPos;
            cmbPosition.ValueMember = "ID";
            cmbPosition.DisplayMember = "NamePosition";
            cmbPosition.DataBindings.Add("Text", bsVacancy, "NamePosition");

            txtSalary.DataBindings.Add("Text", bsVacancy, "Salary");

            cmbEducation.DataSource = DTEduc;
            cmbEducation.ValueMember = "ID";
            cmbEducation.DisplayMember = "Education";
            cmbEducation.DataBindings.Add("Text", bsVacancy, "Education");

            cmbWorkTime.DataSource = DTWork;
            cmbWorkTime.ValueMember = "ID";
            cmbWorkTime.DisplayMember = "WorkTime";
            cmbWorkTime.DataBindings.Add("Text", bsVacancy, "WorkTime");

            txtSkill.DataBindings.Add("Text", bsVacancy, "Skill");
            txtAge.DataBindings.Add("Text", bsVacancy, "Age");

            cmbSex.DataSource = DTSex;
            cmbSex.ValueMember = "ID";
            cmbSex.DisplayMember = "Sex";
            cmbSex.DataBindings.Add("Text", bsVacancy, "Sex");

            txtDescription.DataBindings.Add("Text", bsVacancy, "Description");
            dtPicDatePost.DataBindings.Add("Value", bsVacancy, "DatePost", true);
            dtPicTimePost.DataBindings.Add("Value", bsVacancy, "TimePost", true);
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
            ID = (int)((DataRowView)bsVacancy.Current).Row.ItemArray[0];
            bsVacancy.CancelEdit();
            (this.MdiParent as MainForm).MainForm_DelVacancy(ID, e);
            (this.MdiParent as MainForm).vacancyToolStripMenuItem_Click(sender, e);
        }
		
		private void toolStripButEdit_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Edit;
            txtID.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
        }
		
		private void vacancyFiltertoolStripButton2_Click(object sender, EventArgs e)
        {
            bsVacancy.AddNew();
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
                    vacancy = new Vacancy(Convert.ToInt32(txtID.Text), (int)cmbPosition.SelectedValue, Convert.ToInt32(txtSalary.Text),
                             (int)cmbWorkTime.SelectedValue, (int)cmbEducation.SelectedValue, Convert.ToInt32(txtSkill.Text),
                             (int)cmbSex.SelectedValue, Convert.ToInt32(txtAge.Text), txtDescription.Text, (int)cmbEmployer.SelectedValue,
                             Convert.ToDateTime(dtPicDatePost.Value.Date), Convert.ToDateTime(dtPicTimePost.Value.Date));
                    (this.MdiParent as MainForm).MainForm_AddVacancy(vacancy, e);
                    break;
                case FormMode.Edit:
                    vacancy = new Vacancy(Convert.ToInt32(txtID.Text), (int)cmbPosition.SelectedValue, Convert.ToInt32(txtSalary.Text),
                            (int)cmbWorkTime.SelectedValue, (int)cmbEducation.SelectedValue, Convert.ToInt32(txtSkill.Text),
                            (int)cmbSex.SelectedValue, Convert.ToInt32(txtAge.Text), txtDescription.Text, (int)cmbEmployer.SelectedValue,
                            Convert.ToDateTime(dtPicDatePost.Value.Date), Convert.ToDateTime(dtPicTimePost.Value.Date));
                    (this.MdiParent as MainForm).MainForm_EditVacancy(vacancy, e);
                    break;
                case FormMode.Filter:
                    SetFilterString();
                    break;
                default:
                    break;
            }
            butCancel_Click(sender, e);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            (this.MdiParent as MainForm).vacancyToolStripMenuItem_Click(sender, e);
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
        }
		
		private void Vacancy_FormClosing(object sender, FormClosingEventArgs e)
        {
            (this.MdiParent as MainForm).vacancyToolStripMenuItem1.Visible = false;
            FilterString = null;
            e.Cancel = true;
            this.Hide();
        }

        private void vacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = string.Format("Name = '{0}'", (string)((DataRowView)bsVacancy.Current).Row.ItemArray[9]);
            (this.MdiParent as MainForm).employersToolStripMenuItem_Click(FilterString, e);
        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = string.Format("NamePosition = '{0}'", (string)((DataRowView)bsVacancy.Current).Row.ItemArray[1]);
            (this.MdiParent as MainForm).resumeToolStripMenuItem_Click(FilterString, e);
        }
		
        public void RefreshForm()
        {
            if (bsVacancy == null)
                bsVacancy = new BindingSource();
            bsVacancy.DataSource = DT;
            DT.DefaultView.RowFilter = FilterString;
            bindingNavigator1.BindingSource = bsVacancy;
            dataGridView1.DataSource = bsVacancy;
            if(FilterString != null)
                this.Text = "Vacancy (Filter: " + FilterString + ")";
            else
                this.Text = "Vacancy";
        }
		
        public void SetFilterString()
        {
            listFilter.Clear();

            if (cmbPosition.Text != "")
            {
                FilterString = string.Format("NamePosition = '{0}'", (string)cmbPosition.Text);
                listFilter.Add(FilterString);
            }
            if (cmbEmployer.Text != "")
            {
                FilterString = string.Format("Employer = {0}", (int)cmbEmployer.SelectedValue);
                listFilter.Add(FilterString);
            }
            if (txtSalary.Text != "")
            {
                FilterString = string.Format("Salary >= {0}", Convert.ToInt32(txtSalary.Text));
                listFilter.Add(FilterString);
            }
            if (cmbEducation.Text != "")
            {
                FilterString = string.Format("V_Education = {0}", (int)cmbEducation.SelectedValue);
                listFilter.Add(FilterString);
            }
            if (cmbWorkTime.Text != "")
            {
                FilterString = string.Format("W_Time = {0}", (int)cmbWorkTime.SelectedValue);
                listFilter.Add(FilterString);
            }
            if (cmbSex.Text != "")
            {
                FilterString = string.Format("V_Sex = {0}", (int)cmbSex.SelectedValue);
                listFilter.Add(FilterString);
            }
            if (txtSkill.Text != "")
            {
                FilterString = string.Format("Skill >= {0}", Convert.ToInt32(txtSkill.Text));
                listFilter.Add(FilterString);
            }
            if (txtAge.Text != "")
            {
                FilterString = string.Format("Age <= {0}", Convert.ToInt32(txtAge.Text));
                listFilter.Add(FilterString);
            }

            FilterString = string.Empty;
            for (int i = 0; i < listFilter.Count - 1; i++)
            {
                FilterString += listFilter[i] + " AND ";
            }
            if (listFilter.Count > 0)
                FilterString += listFilter[listFilter.Count - 1];
        }
    }
}
