using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Configuration;

namespace Recruiting
{
    class Presenter
    {
        private readonly MainForm _form;
        private readonly RecruitingManager _manager;

        public Presenter(MainForm form, RecruitingManager manager)
        {
            _form = form;
            _manager = manager;

            _form.EmployerEvent += _form_EmployerEvent;
            _form.VacancyEvent += _form_VacancyEvent;
            _form.ApplicantEvent += _form_ApplicantEvent;
            _form.ResumeEvent += _form_ResumeEvent;

            _form.SettingEvent += _form_SettingEvent;
            _form.AddSetting += _form_AddSetting;
            _form.DelSetting += _form_DelSetting;
            _form.EditSetting += _form_EditSetting;

            _form.AddEmployer += _form_AddEmployer;
            _form.DelEmployer += _form_DelEmployer;
            _form.EditEmployer += _form_EditEmployer;

            _form.AddVacancy += _form_AddVacancy;
            _form.DelVacancy += _form_DelVacancy;
            _form.EditVacancy += _form_EditVacancy;

            _form.AddApplicant += _form_AddApplicant;
            _form.DelApplicant += _form_DelApplicant;
            _form.EditApplicant += _form_EditApplicant;

            _form.AddResume += _form_AddResume;
            _form.DelResume += _form_DelResume;
            _form.EditResume += _form_EditResume;

            _form.ClearBase += _form_ClearBase;

            _manager.OpenConnection(@"Data Source=DESKTOP-S6PRBVA\SQLEXPRESS;Initial Catalog=recruiting;Integrated Security=True");

            //_manager.OpenConnection(ConfigurationManager.ConnectionStrings["DBConection"].ConnectionString);
        }

        private void _form_EditSetting(object sender, EventArgs e)
        {
            _manager.EditSetting((SetTable)sender);
        }

        private void _form_ClearBase(object sender, EventArgs e)
        {
            MessageBox.Show("Удалено " + _manager.ClearBase(((ClearBase)sender).Table, ((ClearBase)sender).dateClear) + " записей", "ClearBase Complit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Setting
        private void _form_DelSetting(object sender, EventArgs e)
        {
            _manager.DelItem(((SettingForm)sender).ID, "ID", ((SettingForm)sender).Table);
        }

        private void _form_AddSetting(object sender, EventArgs e)
        {
            _manager.AddSetting((SetTable)sender);
        }

        private void _form_SettingEvent(object sender, EventArgs e)
        {
            ((SettingForm)sender).DT = _manager.SelectTable((string)((SettingForm)sender).Table);
        }
        #endregion

        #region Employer
        private void _form_EmployerEvent(object sender, EventArgs e)
        {
            ((EmployersForm)sender).DT = _manager.SelectTable("Employers");
        }

        private void _form_AddEmployer(object sender, EventArgs e)
        {
            _manager.AddEmployer((Employer)sender);
        }

        private void _form_DelEmployer(object sender, EventArgs e)
        {
            _manager.DelItem((int)sender, "ID", "Employers");
        }

        private void _form_EditEmployer(object sender, EventArgs e)
        {
            _manager.EditEmployer((Employer)sender);
        }
        #endregion

        #region Vacancy
        void _form_VacancyEvent(object sender, EventArgs e)
        {
            ((VacancyForm)sender).DT = _manager.SelectTable("VacancyView");
            ((VacancyForm)sender).DTEmpl = _manager.SelectTable("Employers");
            ((VacancyForm)sender).DTPos = _manager.SelectTable("Positions");
            ((VacancyForm)sender).DTEduc = _manager.SelectTable("Educations");
            ((VacancyForm)sender).DTSex = _manager.SelectTable("Sex");
            ((VacancyForm)sender).DTWork = _manager.SelectTable("WorkTimes");
        }

        private void _form_AddVacancy(object sender, EventArgs e)
        {
            _manager.AddVacancy((Vacancy)sender);
        }

        private void _form_DelVacancy(object sender, EventArgs e)
        {
            _manager.DelItem((int)sender, "ID", "Vacancy");
        }

        private void _form_EditVacancy(object sender, EventArgs e)
        {
            _manager.EditVacancy((Vacancy)sender);
        }
        #endregion

        #region Applicant
        private void _form_ApplicantEvent(object sender, EventArgs e)
        {
            ((ApplicantsForm)sender).DT = _manager.SelectTable("ApplicantsView");
            ((ApplicantsForm)sender).DTSex = _manager.SelectTable("Sex");
        }

        private void _form_AddApplicant(object sender, EventArgs e)
        {
            _manager.AddApplicant((Applicant)sender);
        }

        private void _form_DelApplicant(object sender, EventArgs e)
        {
            _manager.DelItem((int)sender, "ID", "Applicants");
        }
        
        private void _form_EditApplicant(object sender, EventArgs e)
        {
            _manager.EditApplicants((Applicant)sender);
        }
        #endregion

        #region Resume
        private void _form_ResumeEvent(object sender, EventArgs e)
        {
            ((ResumeForm)sender).DT = _manager.SelectTable("ResumeView");
            ((ResumeForm)sender).DTAppl = _manager.SelectTable("Applicants");
            ((ResumeForm)sender).DTPos = _manager.SelectTable("Positions");
            ((ResumeForm)sender).DTEduc = _manager.SelectTable("Educations");
            ((ResumeForm)sender).DTSex = _manager.SelectTable("Sex");
            ((ResumeForm)sender).DTWork = _manager.SelectTable("WorkTimes");
        }

        private void _form_AddResume(object sender, EventArgs e)
        {
            _manager.AddResume((Resume)sender);
        }

        private void _form_DelResume(object sender, EventArgs e)
        {
            _manager.DelItem((int)sender, "ID", "Resume");
        }

        private void _form_EditResume(object sender, EventArgs e)
        {
            _manager.EditResume((Resume)sender);
        }
        #endregion
    }
}
