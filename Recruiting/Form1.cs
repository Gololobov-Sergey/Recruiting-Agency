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
    public interface IMenu
    {
        event EventHandler EmployerEvent;
        event EventHandler VacancyEvent;
    }
    public partial class MainForm : Form, IMenu
    {
        public event EventHandler EmployerEvent;
        public event EventHandler VacancyEvent;
        public event EventHandler AddEmployer;
        public event EventHandler EditEmployer;
        public event EventHandler DelEmployer;



        Vacancy vacancy;
        Employers employers;

        public MainForm()
        {
            InitializeComponent();

            employersToolStripMenuItem.Click += (employersToolStripMenuItem_Click);
            vacancyToolStripMenuItem.Click += (vacancyToolStripMenuItem_Click);
            //AddEmployer += AddEmployer;
            
        }

        public void MainForm_DelEmployer(object sender, EventArgs e)
        {
            if (DelEmployer != null)
                DelEmployer(sender, EventArgs.Empty);
        }

        public void MainForm_EditEmployer(object sender, EventArgs e)
        {
            if (EditEmployer != null)
                EditEmployer(sender, EventArgs.Empty);
        }

        public void MainForm_AddEmployer(object sender, EventArgs e)
        {
            if (AddEmployer != null)
                AddEmployer(sender, EventArgs.Empty);
        }

        public void employersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employers == null)
            {
                employers = new Employers();
                employers.MdiParent = this;
            }

            if (EmployerEvent != null)
                EmployerEvent(employers, EventArgs.Empty);
            employers.RefreshForm();
            employers.Show();



            employers.Activate();
        }

        public void vacancyToolStripMenuItem_Click (object sender, EventArgs e)
        {
            if (vacancy == null)
            {
                vacancy = new Vacancy();
                vacancy.MdiParent = this;
            }

            if (VacancyEvent != null)
            {
                if(sender is int)
                vacancy.IndexID = (int)sender;
                VacancyEvent(vacancy, EventArgs.Empty);
            }

            vacancy.RefreshForm();
            vacancy.Show();
            vacancy.Activate();
        }
    }
}
