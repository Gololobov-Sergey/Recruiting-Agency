using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Recruiting
{
    class Employer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Site { get; set; }
        public string Description { get; set; }

        public Employer (int id, string name, string adr, string mail, string phone, string sit, string desc)
        {
            ID = id;
            Name = name;
            Adress = adr;
            Email = mail;
            Phone = phone;
            Site = sit;
            Description = desc;
        }

    }

    class Vacancy
    {
        public int ID { get; set; }
        public int Position { get; set; }
        public int Salary { get; set; }
        public int W_Time { get; set; }
        public int Education { get; set; }
        public int Skill { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        public int Employer { get; set; }
        public DateTime DatePost { get; set; }
        public DateTime TimePost { get; set; }

        public Vacancy(int id, int pos, int salary, int w_time, int educ, int skill, int sex, int age, string desc, int empl, DateTime d_p, DateTime t_p)
        {
            ID = id;
            Position = pos;
            Salary = salary;
            W_Time = w_time;
            Education = educ;
            Skill = skill;
            Sex = sex;
            Age = age;
            Description = desc;
            Employer = empl;
            DatePost = d_p;
            TimePost = t_p;
        }
    }

    class Applicant
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public int Sex { get; set; }
        public string Adress { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] Image;

        public Applicant (int id, string fio, int sex, string adres, string email, string phone, string desc, DateTime birth, byte[] im)
        {
            ID = id;
            FIO = fio;
            Sex = sex;
            Adress = adres;
            EMail = email;
            Phone = phone;
            Description = desc;
            Birthday = birth;
            Image = im;
        }
    }

    class Resume
    {
        public int ID { set; get; }
        public int Applicant { set; get; }
        public int Position { set; get; }
        public int Salary { set; get; }
        public int W_Time { get; set; }
        public int Education { get; set; }
        public int Skill { get; set; }
        public int Sex { get; set; }
        public string Description { get; set; }
        public DateTime DatePost { get; set; }
        public DateTime TimePost { get; set; }

        public Resume(int id, int appl, int pos, int salary, int w_time, int educ, int skill, int sex, string desc, DateTime d_p, DateTime t_p)
        {
            ID = id;
            Applicant = appl;
            Position = pos;
            Salary = salary;
            W_Time = w_time;
            Education = educ;
            Skill = skill;
            Sex = sex;
            Description = desc;
            DatePost = d_p;
            TimePost = t_p;
        }
    }

    class SetTable
    {
        public int ID { get; set; }
        public string NameParam { get; set; }
        public string ValueParam { get; set; }
        public string TableName { get; set; }

        public SetTable(int id, string param, string vparam, string tn)
        {
            ID = id;
            NameParam = param;
            ValueParam = vparam;
            TableName = tn;
        }
    }

    class RecruitingManager
    {
        private SqlConnection sqlCon = null;
        private SqlDataAdapter sqlDA = null;
        private DataTable DT = null;

        public void OpenConnection(string connectionString)
        {
            sqlCon = new SqlConnection();
            sqlCon.ConnectionString = connectionString;
            sqlCon.Open();
        }

        public DataTable SelectTable(string selectTable)
        {
            string sql = string.Format("Select * From dbo.{0}", selectTable);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                DT = new DataTable();
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(DT);
                return DT;
            }
        }
        
        ///Setting
        public void EditSetting(SetTable obj)
        {
            string sql = string.Format("UPDATE {0} SET {1} = '{2}' WHERE ID = {3};", obj.TableName, obj.NameParam, obj.ValueParam, obj.ID);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void AddSetting(SetTable obj)
        {
            string sql = string.Format("INSERT INTO {0} VALUES ('{1}');", obj.TableName, obj.ValueParam);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.ExecuteNonQuery();
            }
        }

        ///Emloyer
        public void AddEmployer(Employer obj)
        {
            string sql = string.Format("INSERT INTO Employers VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');", obj.Name, obj.Adress, obj.Email, obj.Phone, obj.Site, obj.Description);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void EditEmployer(Employer obj)
        {
            string sql = string.Format("UPDATE Employers SET [Name] = '{0}', [Adress] = '{1}', [Email] = '{2}', [Phone] = '{3}', [Site] = '{4}', [Description] = '{5}' WHERE ID = {6};", obj.Name, obj.Adress, obj.Email, obj.Phone, obj.Site, obj.Description, obj.ID);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.ExecuteNonQuery();
            }
        }

        ///Vacancy
        public void AddVacancy(Vacancy obj)
        {
            string sql = string.Format("INSERT INTO Vacancy VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', {8}, @DatePost, @TimePost);",
                obj.Position, obj.Salary, obj.W_Time, obj.Education, obj.Skill, obj.Sex, obj.Age, obj.Description, obj.Employer);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@DatePost", SqlDbType.Date);
                cmd.Parameters["@DatePost"].Value = obj.DatePost;
                cmd.Parameters.Add("@TimePost", SqlDbType.Date);
                cmd.Parameters["@TimePost"].Value = obj.TimePost;
                cmd.ExecuteNonQuery();
            }
        }
        public void EditVacancy(Vacancy obj)
        {
            string sql = string.Format("UPDATE Vacancy SET [Position] = {0}, [Salary] = {1}, [W_Time] = {2}, [Education] = {3}, [Skill] = {4}, [Sex] = {5}, [Age] = {6}, [Description] = '{7}', [Employer] = {8}, [DatePost] = @DatePost, [TimePost] = @TimePost WHERE ID = {9};",
                obj.Position, obj.Salary, obj.W_Time, obj.Education, obj.Skill, obj.Sex, obj.Age, obj.Description, obj.Employer, obj.ID);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@DatePost", SqlDbType.Date);
                cmd.Parameters["@DatePost"].Value = obj.DatePost;
                cmd.Parameters.Add("@TimePost", SqlDbType.Date);
                cmd.Parameters["@TimePost"].Value = obj.TimePost;
                cmd.ExecuteNonQuery();
            }
        }

        ///Applicant
        public void AddApplicant(Applicant obj)
        {
            string sql = string.Format("INSERT INTO Applicants VALUES ('{0}', @Birth, {1}, '{2}', '{3}', '{4}', '{5}', @Image);",
                obj.FIO, obj.Sex, obj.Adress, obj.Phone, obj.EMail, obj.Description);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@Birth", SqlDbType.Date);
                cmd.Parameters.Add("@image", SqlDbType.Image, 100000);
                cmd.Parameters["@Birth"].Value = obj.Birthday;
                cmd.Parameters["@Image"].Value = obj.Image;
                cmd.ExecuteNonQuery();
            }
        }
        public void EditApplicants(Applicant obj)
        {
            string sql = string.Format("UPDATE Applicants SET [FIO] = '{0}', [Birtday] = @Birth, [Sex] = {1}, [Adress] = '{2}', [Phone] = '{3}', [Email] = '{4}', [Description] = '{5}', [Image] = @Image WHERE ID = {6};",
                obj.FIO, obj.Sex, obj.Adress, obj.Phone, obj.EMail, obj.Description, obj.ID);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@Birth", SqlDbType.Date);
                cmd.Parameters.Add("@image", SqlDbType.Image, 100000);
                cmd.Parameters["@Birth"].Value = obj.Birthday;
                cmd.Parameters["@Image"].Value = obj.Image;

                cmd.ExecuteNonQuery();
            }
        }

        ///Resume
        public void AddResume(Resume obj)
        {
            string sql = string.Format("INSERT INTO Resume VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, '{7}', @DatePost, @TimePost);",
                obj.Applicant, obj.Position, obj.Salary, obj.W_Time, obj.Education, obj.Skill, obj.Sex, obj.Description);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@DatePost", SqlDbType.Date);
                cmd.Parameters["@DatePost"].Value = obj.DatePost;
                cmd.Parameters.Add("@TimePost", SqlDbType.Date);
                cmd.Parameters["@TimePost"].Value = obj.TimePost;
                cmd.ExecuteNonQuery();
            }
        }

        public void EditResume(Resume obj)
        {
            string sql = string.Format("UPDATE Resume SET [Applicant] = {0}, [Position] = {1}, [Salary] = {2}, [WorkTime] = {3}, [Education] = {4}, [Skill] = {5}, [Sex] = {6}, [Description] = '{7}', [DatePost] = @DatePost, [TimePost] = @TimePost WHERE ID = {8};",
                obj.Applicant, obj.Position, obj.Salary, obj.W_Time, obj.Education, obj.Skill, obj.Sex, obj.Description, obj.ID);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@DatePost", SqlDbType.Date);
                cmd.Parameters["@DatePost"].Value = obj.DatePost;
                cmd.Parameters.Add("@TimePost", SqlDbType.Date);
                cmd.Parameters["@TimePost"].Value = obj.TimePost;
                cmd.ExecuteNonQuery();
            }
        }

        public void DelItem(int id, string field, string table)
        {
            string sql = string.Format("DELETE FROM {0} WHERE {1} = {2};", table, field, id);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public int ClearBase(string table, DateTime date)
        {
            string sql = string.Format("DELETE FROM {0} WHERE TimePost <= @Param;", table);
            using (SqlCommand cmd = new SqlCommand(sql, this.sqlCon))
            {
                cmd.Parameters.Add("@Param", SqlDbType.Date);
                cmd.Parameters["@Param"].Value = date;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
