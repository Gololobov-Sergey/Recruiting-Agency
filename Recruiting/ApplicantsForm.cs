using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Recruiting
{
    public partial class ApplicantsForm : Form
    {
        public string FilterString { set; get; }
        List<string> listFilter = new List<string>();
        public DataTable DT { set; get; }
        public DataTable DTSex { set; get; }
        public int ID { get; private set; }

        public enum FormMode { Add, Edit, Filter }
        FormMode Mode;
        byte[] imageData;
        BindingSource bsApplicant;

        Applicant appl;

        public ApplicantsForm()
        {
            InitializeComponent();
            this.Load += ApplicantsForm_Load;
        }

        private void ApplicantsForm_Load(object sender, EventArgs e)
        {
            RefreshForm();

            txtID.DataBindings.Add("Text", bsApplicant, "ID");
            txtFIO.DataBindings.Add("Text", bsApplicant, "FIO");
            txtAdres.DataBindings.Add("Text", bsApplicant, "Adress");
            txtEmail.DataBindings.Add("Text", bsApplicant, "Email");
            txtPhone.DataBindings.Add("Text", bsApplicant, "Phone");

            cmbSex.DataSource = DTSex;
            cmbSex.ValueMember = "ID";
            cmbSex.DisplayMember = "Sex";
            cmbSex.DataBindings.Add("Text", bsApplicant, "Sex");

            txtDescription.DataBindings.Add("Text", bsApplicant, "Description");

            picPhoto.DataBindings.Add("Image", bsApplicant, "Image", true);

            dt_Birthday.DataBindings.Add("Value", bsApplicant, "Birtday", true);
        }

		private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Add;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
            butAddPhoto.Visible = true;
            txtID.Text = (DT.Rows.Count + 1).ToString();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            ID = (int)((DataRowView)bsApplicant.Current).Row.ItemArray[0];
            bsApplicant.CancelEdit();
            (this.MdiParent as MainForm).MainForm_DelApplicant(ID, e);
            (this.MdiParent as MainForm).applicantToolStripMenuItem_Click(sender, e);
        }
		
		private void toolStripEdit_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Edit;
            txtID.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
            butAddPhoto.Visible = true;
        }
		
        private void butAddPhoto_Click(object sender, EventArgs e)
        {
            if(openFDAddPhoto.ShowDialog() == DialogResult.OK)
            {
                butAddPhoto.Visible = false;
                using (System.IO.FileStream fs = new System.IO.FileStream(openFDAddPhoto.FileName, System.IO.FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }
                picPhoto.Image = Image.FromStream(new System.IO.MemoryStream(imageData));
            }
        }
		
		private void toolStripFilter_Click(object sender, EventArgs e)
        {
            bsApplicant.AddNew();
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
                    appl = new Applicant(Convert.ToInt32(txtID.Text), txtFIO.Text, (int)cmbSex.SelectedValue, txtAdres.Text,
                            txtEmail.Text, txtPhone.Text, txtDescription.Text, dt_Birthday.Value.Date, imageData);
                    (this.MdiParent as MainForm).MainForm_AddApplicant(appl, e);
                    break;
                case FormMode.Edit:
                    appl = new Applicant(Convert.ToInt32(txtID.Text), txtFIO.Text, (int)cmbSex.SelectedValue, txtAdres.Text,
                            txtEmail.Text, txtPhone.Text, txtDescription.Text, dt_Birthday.Value.Date, imageData);
                    (this.MdiParent as MainForm).MainForm_EditApplicant(appl, e);
                    break;
                case FormMode.Filter:
                    SetFilterString();
                    break;
                default:
                    break;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            (this.MdiParent as MainForm).applicantToolStripMenuItem_Click(sender, e);
            butCancel_Click(sender, e);
        }
		
        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            butAddPhoto.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
        }

        private void ApplicantsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FilterString = null;
            e.Cancel = true;
            this.Hide();
        }
		
        private void vacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterString = $"FIO = '{(string)((DataRowView)bsApplicant.Current).Row.ItemArray[1]}'";
            (this.MdiParent as MainForm).resumeToolStripMenuItem_Click(FilterString, e);
        }		

        public void RefreshForm()
        {
            if (bsApplicant == null)
                bsApplicant = new BindingSource();
            bsApplicant.DataSource = DT;
            DT.DefaultView.RowFilter = FilterString;
            bindingNavigator1.BindingSource = bsApplicant;
            dataGridView1.DataSource = bsApplicant;
            if (FilterString != null)
                this.Text = "Applicants (Filter: " + FilterString + ")";
            else
                this.Text = "Applicants";

        }
		
        private void SetFilterString()
        {
            listFilter.Clear();

            if (txtFIO.Text != "")
            {
                FilterString = string.Format("FIO LIKE '{0}'", txtFIO.Text);
                listFilter.Add(FilterString);
            }
            if (cmbSex.Text != "")
            {
                FilterString = string.Format("V_Sex = {0}", (int)cmbSex.SelectedValue);
                listFilter.Add(FilterString);
            }
            if (txtAdres.Text != "")
            {
                FilterString = string.Format("Adress LIKE '{0}'", txtAdres.Text);
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
