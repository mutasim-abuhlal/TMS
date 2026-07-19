using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Global_Classes;
using TMS.People;
using TMS.Users;
using TMS.Students;
using TMS.Teachers;
using TMS.Courses;
using TMS.Enrollments;
using TMS.Services;
using TMS.Courses.Classrooms;
using TMS.Subjects;
using TMS.Majors;

namespace TMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void currentUsersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserDetails(clsGlobal.User.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(clsGlobal.User.UserID);
            frm.ShowDialog();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListStudents();
            frm.ShowDialog();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTeachers();
            frm.ShowDialog();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListCourses();
            frm.ShowDialog();
        }

        private void enrollmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEnrollmentsList();
            frm.ShowDialog();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListServices();
            frm.ShowDialog();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListClassrooms();
            frm.ShowDialog();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListSubjects();
            frm.ShowDialog();
        }

        private void majorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListMajors();
            frm.ShowDialog();
        }
    }
}
