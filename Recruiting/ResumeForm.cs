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
    public partial class ResumeForm : Form
    {
        public string FilterString { set; get; }
        List<string> listFilter = new List<string>();
        public DataTable DT { set; get; }
        public DataTable DTAppl { set; get; }
        public DataTable DTPos { set; get; }
        public DataTable DTEduc { set; get; }
        public DataTable DTWork { set; get; }
        public DataTable DTSex { set; get; }
        public int ID { get; private set; }

        BindingSource bsResume;

        public enum FormMode { Add, Edit, Filter }
        FormMode Mode;
        Resume resume;

        public ResumeForm()
        {
            InitializeComponent();
            this.Load += ResumeForm_Load;
        }

        private void ResumeForm_Load(object sender, EventArgs e)
        {
            RefreshForm();

            txtID.DataBindings.Add("Text", bsResume, "ID");

            cmbApplicant.DataSource = DTAppl;
            cmbApplicant.ValueMember = "ID";
            cmbApplicant.DisplayMember = "FIO";
            cmbApplicant.DataBindings.Add("Text", bsResume, "FIO");

            cmbPosition.DataSource = DTPos;
            cmbPosition.ValueMember = "ID";
            cmbPosition.DisplayMember = "NamePosition";
            cmbPosition.DataBindings.Add("Text", bsResume, "NamePosition");

            txtSalary.DataBindings.Add("Text", bsResume, "Salary");

            cmbEducation.DataSource = DTEduc;
            cmbEducation.ValueMember = "ID";
            cmbEducation.DisplayMember = "Education";
            cmbEducation.DataBindings.Add("Text", bsResume, "Education");

            cmbWorkTime.DataSource = DTWork;
            cmbWorkTime.ValueMember = "ID";
            cmbWorkTime.DisplayMember = "WorkTime";
            cmbWorkTime.DataBindings.Add("Text", bsResume, "WorkTime");

            txtSkill.DataBindings.Add("Text", bsResume, "Skill");

            cmbSex.DataSource = DTSex;
            cmbSex.ValueMember = "ID";
            cmbSex.DisplayMember = "Sex";
            cmbSex.DataBindings.Add("Text", bsResume, "Sex");

            txtDescription.DataBindings.Add("Text", bsResume, "Description");
            dtPicDatePost.DataBindings.Add("Value", bsResume, "DatePost", true);
            dtPicTimePost.DataBindings.Add("Value", bsResume, "TimePost", true);
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
            ID = (int)((DataRowView)bsResume.Current).Row.ItemArray[0];
            bsResume.CancelEdit();
            (this.MdiParent as MainForm).MainForm_DelResume(ID, e);
            (this.MdiParent as MainForm).resumeToolStripMenuItem_Click(sender, e);
        }

        private void toolStripEditItem_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Edit;
            txtID.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
        }	
		
        private void toolStripFilter_Click(object sender, EventArgs e)
        {
            bsResume.AddNew();
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
                    resume = new Resume(Convert.ToInt32(txtID.Text), (int)cmbApplicant.SelectedValue, (int)cmbPosition.SelectedValue, Convert.ToInt32(txtSalary.Text),
                             (int)cmbWorkTime.SelectedValue, (int)cmbEducation.SelectedValue, Convert.ToInt32(txtSkill.Text),
                             (int)cmbSex.SelectedValue, txtDescription.Text, Convert.ToDateTime(dtPicDatePost.Value.Date), Convert.ToDateTime(dtPicTimePost.Value.Date));
                    (this.MdiParent as MainForm).MainForm_AddResume(resume, e);
                    break;
                case FormMode.Edit:
                    resume = new Resume(Convert.ToInt32(txtID.Text), (int)cmbApplicant.SelectedValue, (int)cmbPosition.SelectedValue, Convert.ToInt32(txtSalary.Text),
                             (int)cmbWorkTime.SelectedValue, (int)cmbEducation.SelectedValue, Convert.ToInt32(txtSkill.Text),
                             (int)cmbSex.SelectedValue, txtDescription.Text, Convert.ToDateTime(dtPicDatePost.Value.Date), Convert.ToDateTime(dtPicTimePost.Value.Date));
                    (this.MdiParent as MainForm).MainForm_EditResume(resume, e);
                    break;
                case FormMode.Filter:
                    SetFilterString();
                    break;
                default:
                    break;
            }
            butCancel_Click(sender, e);
            (this.MdiParent as MainForm).resumeToolStripMenuItem_Click(sender, e);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
        }
		
        private void ResumeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            (this.MdiParent as MainForm).resumeToolStripMenuItem1.Visible = false;
            FilterString = null;
            e.Cancel = true;
            this.Hide();
        }

        private void applicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = string.Format("FIO = '{0}'", (string)((DataRowView)bsResume.Current).Row.ItemArray[1]);
            (this.MdiParent as MainForm).applicantToolStripMenuItem_Click(FilterString, e);
        }

        private void vacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = string.Format("NamePosition = '{0}'", (string)((DataRowView)bsResume.Current).Row.ItemArray[2]);
            (this.MdiParent as MainForm).vacancyToolStripMenuItem_Click(FilterString, e);
        }
		
        public void RefreshForm()
        {
            if (bsResume == null)
                bsResume = new BindingSource();
            bsResume.DataSource = DT;
            DT.DefaultView.RowFilter = FilterString;
            bindingNavigator1.BindingSource = bsResume;
            dataGridView1.DataSource = bsResume;
            if (FilterString != null)
                this.Text = "Resume (Filter: " + FilterString + ")";
            else
                this.Text = "Resume";
        }

		private void SetFilterString()
        {
            listFilter.Clear();

            if (cmbPosition.Text != "")
            {
                FilterString = string.Format("NamePosition = '{0}'", (string)cmbPosition.Text);
                listFilter.Add(FilterString);
            }
            if (cmbApplicant.Text != "")
            {
                FilterString = string.Format("Applicant = {0}", (int)cmbApplicant.SelectedValue);
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
            if (txtDescription.Text != "")
            {
                FilterString = string.Format("Description LIKE '{0}'", txtDescription.Text);
                listFilter.Add(FilterString);
            }
            FilterString = string.Empty;
            for (int i = 0; i < listFilter.Count - 1; i++)
            {
                FilterString = listFilter[i] + " AND ";
            }
            if (listFilter.Count > 0)
                FilterString += listFilter[listFilter.Count - 1];
        }
    }
}
