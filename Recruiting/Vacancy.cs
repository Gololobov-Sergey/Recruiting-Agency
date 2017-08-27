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
    //public interface IVacancy
    //{
    //    DataTable DT { set; get; }
    //}
    public partial class Vacancy : Form, IMenu
    {
        public int IndexID { set; get; }
        public DataTable DT { set; get; }

        public event EventHandler VacancyEvent;
        public event EventHandler EmployerEvent;
        public Vacancy()
        {
            InitializeComponent();
            this.Load += Vacancy_Load;
        }

        void Vacancy_Load(object sender, EventArgs e)
        {
            //BindingSource bs1 = new BindingSource();
            //bs1.DataSource = DT;
            //bindingNavigator1.BindingSource = bs1;
            //dataGridView1.DataSource = bs1;
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
            if (e.RowIndex < DT.Rows.Count)
            {
                IndexID = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                //textBox1.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                //textBox2.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                //textBox3.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                //textBox4.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[4].Value;
                //textBox5.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                //textBox6.Text = (string)dataGridView1.Rows[e.RowIndex].Cells[6].Value;
                txtID.Text = IndexID.ToString();
            }
        }

        private void Vacancy_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
