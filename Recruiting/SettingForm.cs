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
    public partial class SettingForm : Form
    {
        BindingSource bsSetting;
        public DataTable DT { set; get; }
        public string Table { set; get; }
        public string Field { set; get; }
        public int ID { set; get; }

        public enum FormMode { Add, Edit, Filter }
        FormMode Mode;
        SetTable set;

        public SettingForm()
        {
            InitializeComponent();
            this.Load += SettingForm_Load;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        public void RefreshForm()
        {
            if (bsSetting == null)
                bsSetting = new BindingSource();
            bsSetting.DataSource = DT;
            bindingNavigator1.BindingSource = bsSetting;
            dataGridView1.DataSource = bsSetting;
            if(txtID.DataBindings.Count == 0)
                txtID.DataBindings.Add("Text", bsSetting, "ID");

            switch (Table)
            {
                case "Positions":
                    this.Text = "Positions";
                    label1.Text = "Должности";
                    label3.Text = "Должность";
                    if (txtName.DataBindings.Count == 0)
                        txtName.DataBindings.Add("Text", bsSetting, "NamePosition");
                    break;
                case "WorkTimes":
                    this.Text = "Work Times";
                    label1.Text = "Графики работы";
                    label3.Text = "График работы";
                    if (txtName.DataBindings.Count == 0)
                        txtName.DataBindings.Add("Text", bsSetting, "WorkTime");
                    break;
                case "Educations":
                    this.Text = "Educations";
                    label1.Text = "Образование";
                    label3.Text = "Образование";
                    if (txtName.DataBindings.Count == 0)
                        txtName.DataBindings.Add("Text", bsSetting, "Education");
                    break;
                default:
                    break;
            }
        }

        private void SettingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            e.Cancel = true;
            this.Hide();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Add;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
            txtID.Text = (DT.Rows.Count + 1).ToString();
        }

        private void butOk_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case FormMode.Add:
                    set = new SetTable(Convert.ToInt32(txtID.Text), Field, txtName.Text, Table);
                    (this.MdiParent as MainForm).MainForm_AddSetting(set, e);
                    break;
                case FormMode.Edit:
                    set = new SetTable(Convert.ToInt32(txtID.Text), Field, txtName.Text, Table);
                    (this.MdiParent as MainForm).MainForm_EditSetting(set, e);
                    break;
                default:
                    break;
            }
            butCancel_Click(sender, e);
            ///dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            switch (Table)
            {
                case "Positions":
                    (this.MdiParent as MainForm).positionToolStripMenuItem_Click(sender, e);
                    break;
                case "WorkTimes":
                    (this.MdiParent as MainForm).workTimesToolStripMenuItem_Click(sender, e);
                    break;
                case "Educations":
                    (this.MdiParent as MainForm).educationToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            butOk.Visible = false;
            butCancel.Visible = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage1"];
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            ID = (int)((DataRowView)bsSetting.Current).Row.ItemArray[0];
            bsSetting.CancelEdit();
            (this.MdiParent as MainForm).MainForm_DelSetting(this, e);
            switch (Table)
            {
                case "Positions":
                    (this.MdiParent as MainForm).positionToolStripMenuItem_Click(sender, e);
                    break;
                case "WorkTimes":
                    (this.MdiParent as MainForm).workTimesToolStripMenuItem_Click(sender, e);
                    break;
                case "Educations":
                    (this.MdiParent as MainForm).educationToolStripMenuItem_Click(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void toolStripButEdit_Click(object sender, EventArgs e)
        {
            Mode = FormMode.Edit;
            txtID.Enabled = false;
            tabControl1.SelectedTab = tabControl1.TabPages["tabPage2"];
            butOk.Visible = true;
            butCancel.Visible = true;
        }
    }
}
