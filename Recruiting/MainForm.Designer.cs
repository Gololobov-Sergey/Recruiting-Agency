namespace Recruiting
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.educationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacancyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.applicantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.positionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.workTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearBaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.educationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employersToolStripMenuItem,
            this.vacancyToolStripMenuItem,
            this.applicantToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employersToolStripMenuItem
            // 
            this.employersToolStripMenuItem.Name = "employersToolStripMenuItem";
            this.employersToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.employersToolStripMenuItem.Text = "Employers";
            // 
            // vacancyToolStripMenuItem
            // 
            this.vacancyToolStripMenuItem.Name = "vacancyToolStripMenuItem";
            this.vacancyToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.vacancyToolStripMenuItem.Text = "Vacancy";
            // 
            // applicantToolStripMenuItem
            // 
            this.applicantToolStripMenuItem.Name = "applicantToolStripMenuItem";
            this.applicantToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.applicantToolStripMenuItem.Text = "Applicants";
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.resumeToolStripMenuItem.Text = "Resume";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionToolStripMenuItem,
            this.workTimesToolStripMenuItem,
            this.educationToolStripMenuItem,
            this.clearBaseToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // positionToolStripMenuItem
            // 
            this.positionToolStripMenuItem.Name = "positionToolStripMenuItem";
            this.positionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.positionToolStripMenuItem.Text = "Position";
            this.positionToolStripMenuItem.Click += new System.EventHandler(this.positionToolStripMenuItem_Click);
            // 
            // workTimesToolStripMenuItem
            // 
            this.workTimesToolStripMenuItem.Name = "workTimesToolStripMenuItem";
            this.workTimesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.workTimesToolStripMenuItem.Text = "Work Times";
            this.workTimesToolStripMenuItem.Click += new System.EventHandler(this.workTimesToolStripMenuItem_Click);
            // 
            // educationToolStripMenuItem
            // 
            this.educationToolStripMenuItem.Name = "educationToolStripMenuItem";
            this.educationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.educationToolStripMenuItem.Text = "Education";
            this.educationToolStripMenuItem.Click += new System.EventHandler(this.educationToolStripMenuItem_Click);
            // 
            // clearBaseToolStripMenuItem
            // 
            this.clearBaseToolStripMenuItem.Name = "clearBaseToolStripMenuItem";
            this.clearBaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearBaseToolStripMenuItem.Text = "Clear base";
            this.clearBaseToolStripMenuItem.Click += new System.EventHandler(this.clearBaseToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employerToolStripMenuItem,
            this.vacancyToolStripMenuItem1,
            this.applicantsToolStripMenuItem,
            this.resumeToolStripMenuItem1,
            this.positionToolStripMenuItem1,
            this.workTimeToolStripMenuItem,
            this.educationToolStripMenuItem1,
            this.clearBaseToolStripMenuItem1});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // employerToolStripMenuItem
            // 
            this.employerToolStripMenuItem.Name = "employerToolStripMenuItem";
            this.employerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.employerToolStripMenuItem.Text = "Employers";
            this.employerToolStripMenuItem.Visible = false;
            this.employerToolStripMenuItem.Click += new System.EventHandler(this.employerToolStripMenuItem_Click);
            // 
            // vacancyToolStripMenuItem1
            // 
            this.vacancyToolStripMenuItem1.Name = "vacancyToolStripMenuItem1";
            this.vacancyToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.vacancyToolStripMenuItem1.Text = "Vacancy";
            this.vacancyToolStripMenuItem1.Visible = false;
            this.vacancyToolStripMenuItem1.Click += new System.EventHandler(this.vacancyToolStripMenuItem1_Click);
            // 
            // applicantsToolStripMenuItem
            // 
            this.applicantsToolStripMenuItem.Name = "applicantsToolStripMenuItem";
            this.applicantsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.applicantsToolStripMenuItem.Text = "Applicants";
            this.applicantsToolStripMenuItem.Visible = false;
            this.applicantsToolStripMenuItem.Click += new System.EventHandler(this.applicantsToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem1
            // 
            this.resumeToolStripMenuItem1.Name = "resumeToolStripMenuItem1";
            this.resumeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.resumeToolStripMenuItem1.Text = "Resume";
            this.resumeToolStripMenuItem1.Visible = false;
            this.resumeToolStripMenuItem1.Click += new System.EventHandler(this.resumeToolStripMenuItem1_Click);
            // 
            // positionToolStripMenuItem1
            // 
            this.positionToolStripMenuItem1.Name = "positionToolStripMenuItem1";
            this.positionToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.positionToolStripMenuItem1.Text = "Position";
            this.positionToolStripMenuItem1.Visible = false;
            this.positionToolStripMenuItem1.Click += new System.EventHandler(this.positionToolStripMenuItem1_Click);
            // 
            // workTimeToolStripMenuItem
            // 
            this.workTimeToolStripMenuItem.Name = "workTimeToolStripMenuItem";
            this.workTimeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.workTimeToolStripMenuItem.Text = "Work time";
            this.workTimeToolStripMenuItem.Visible = false;
            this.workTimeToolStripMenuItem.Click += new System.EventHandler(this.workTimeToolStripMenuItem_Click);
            // 
            // clearBaseToolStripMenuItem1
            // 
            this.clearBaseToolStripMenuItem1.Name = "clearBaseToolStripMenuItem1";
            this.clearBaseToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.clearBaseToolStripMenuItem1.Text = "Clear base";
            this.clearBaseToolStripMenuItem1.Visible = false;
            this.clearBaseToolStripMenuItem1.Click += new System.EventHandler(this.clearBaseToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(856, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // educationToolStripMenuItem1
            // 
            this.educationToolStripMenuItem1.Name = "educationToolStripMenuItem1";
            this.educationToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.educationToolStripMenuItem1.Text = "Education";
            this.educationToolStripMenuItem1.Visible = false;
            this.educationToolStripMenuItem1.Click += new System.EventHandler(this.educationToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 547);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recruiting agency";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacancyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workTimesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem educationToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem employerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem vacancyToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem applicantsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem positionToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem workTimeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearBaseToolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem educationToolStripMenuItem1;
    }
}

