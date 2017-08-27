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
    public partial class MainForm : Form
    {
        public event EventHandler EmployerEvent;
        public event EventHandler VacancyEvent;
        public event EventHandler ApplicantEvent;
        public event EventHandler ResumeEvent;

        public void MainForm_ClearBase(object sender, EventArgs e)
        {
            if (ClearBase != null)
                ClearBase(sender, e);
        }

        public event EventHandler AddEmployer;
        public event EventHandler EditEmployer;
        public event EventHandler DelEmployer;

        public event EventHandler AddVacancy;
        public event EventHandler EditVacancy;
        public event EventHandler DelVacancy;

        public event EventHandler AddApplicant;
        public event EventHandler EditApplicant;
        public event EventHandler DelApplicant;

        public event EventHandler AddResume;
        public event EventHandler EditResume;
        public event EventHandler DelResume;

        public event EventHandler SettingEvent;
        public event EventHandler AddSetting;
        public event EventHandler DelSetting;
        public event EventHandler EditSetting;

        public event EventHandler ClearBase;


        VacancyForm vacancy;
        EmployersForm employers;
        ApplicantsForm applicant;
        ResumeForm resume;
        SettingForm setting;
        ClearBase clearBase;

        public MainForm()
        {
            InitializeComponent();

            employersToolStripMenuItem.Click += employersToolStripMenuItem_Click;
            vacancyToolStripMenuItem.Click += vacancyToolStripMenuItem_Click;
            applicantToolStripMenuItem.Click += applicantToolStripMenuItem_Click;
            resumeToolStripMenuItem.Click += resumeToolStripMenuItem_Click;
        }

        #region Employers
        public void employersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employers == null)
            {
                employers = new EmployersForm();
                employers.MdiParent = this;
            }

            if (EmployerEvent != null)
            {
                if (sender is string)
                    employers.FilterString = (string)sender;
                EmployerEvent(employers, EventArgs.Empty);
            }
            employers.RefreshForm();
            employers.Show();
            
            
            employers.Activate();
            employerToolStripMenuItem.Visible = true;
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
        #endregion

        #region Vacancy
        public void vacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vacancy == null)
            {
                vacancy = new VacancyForm();
                vacancy.MdiParent = this;
            }

            if (VacancyEvent != null)
            {
                if (sender is string)
                    vacancy.FilterString = (string)sender;
                VacancyEvent(vacancy, EventArgs.Empty);
            }

            vacancy.RefreshForm();
            vacancy.Show();
            vacancy.Activate();
        }

        public void MainForm_AddVacancy(object sender, EventArgs e)
        {
            if (AddVacancy != null)
                AddVacancy(sender, EventArgs.Empty);
        }

        public void MainForm_DelVacancy(object sender, EventArgs e)
        {
            if (DelVacancy != null)
                DelVacancy(sender, EventArgs.Empty);
        }

        public void MainForm_EditVacancy(object sender, EventArgs e)
        {
            if (EditVacancy != null)
                EditVacancy(sender, EventArgs.Empty);
        }
        #endregion

        #region Applicants
        public void applicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (applicant == null)
            {
                applicant = new ApplicantsForm();
                applicant.MdiParent = this;
            }

            if (ApplicantEvent != null)
            {
                if (sender is string)
                    applicant.FilterString = (string)sender;
                ApplicantEvent(applicant, EventArgs.Empty);
            }
            applicant.RefreshForm();
            applicant.Show();
            applicant.Activate();
        }

        public void MainForm_EditApplicant(object sender, EventArgs e)
        {
            if (EditApplicant != null)
                EditApplicant(sender, EventArgs.Empty);
        }

        public void MainForm_DelApplicant(object sender, EventArgs e)
        {
            if (DelApplicant != null)
                DelApplicant(sender, EventArgs.Empty);
        }

        public void MainForm_AddApplicant(object sender, EventArgs e)
        {
            if (AddApplicant != null)
                AddApplicant(sender, EventArgs.Empty);
        }

        #endregion

        #region Resume
        public void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (resume == null)
            {
                resume = new ResumeForm();
                resume.MdiParent = this;
            }

            if (ResumeEvent != null)
            {
                if (sender is string)
                    resume.FilterString = (string)sender;
                ResumeEvent(resume, EventArgs.Empty);
            }

            resume.RefreshForm();
            resume.Show();
            resume.Activate();
        }

        public void MainForm_AddResume(object sender, EventArgs e)
        {
            if (AddResume != null)
                AddResume(sender, EventArgs.Empty);
        }

        public void MainForm_DelResume(object sender, EventArgs e)
        {
            if (DelResume != null)
                DelResume(sender, EventArgs.Empty);
        }

        public void MainForm_EditResume(object sender, EventArgs e)
        {
            if (EditResume != null)
                EditResume(sender, EventArgs.Empty);
        }

        #endregion

        public void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting == null)
            {
                setting = new SettingForm();
                setting.MdiParent = this;
            }
            setting.Table = "Positions";
            setting.Field = "[NamePosition]";

            if (SettingEvent != null)
            {
                SettingEvent(setting, EventArgs.Empty);
            }

            setting.RefreshForm();
            setting.Show();
            setting.Activate();
        }

        public void workTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting == null)
            {
                setting = new SettingForm();
                setting.MdiParent = this;
            }
            setting.Table = "WorkTimes";
            setting.Field = "[WorkTime]";

            if (SettingEvent != null)
            {
                SettingEvent(setting, EventArgs.Empty);
            }

            setting.RefreshForm();
            setting.Show();
            setting.Activate();
        }

        public void educationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (setting == null)
            {
                setting = new SettingForm();
                setting.MdiParent = this;
            }
            setting.Table = "Educations";
            setting.Field = "[Education]";

            if (SettingEvent != null)
            {
                SettingEvent(setting, EventArgs.Empty);
            }

            setting.RefreshForm();
            setting.Show();
            setting.Activate();
        }

        public void MainForm_AddSetting(object sender, EventArgs e)
        {
            if (AddSetting != null)
                AddSetting(sender, EventArgs.Empty);
        }

        public void MainForm_DelSetting(object sender, EventArgs e)
        {
            if (DelSetting != null)
                DelSetting(sender, EventArgs.Empty);
        }

        public void MainForm_EditSetting(object sender, EventArgs e)
        {
            if (EditSetting != null)
                EditSetting(sender, EventArgs.Empty);
        }

        public void clearBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clearBase == null)
            {
                clearBase = new ClearBase();
                clearBase.MdiParent = this;
            }
            clearBase.Show();
        }
    }
}
