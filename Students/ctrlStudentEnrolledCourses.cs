using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;

namespace TMS.Students
{
   
    public partial class ctrlStudentEnrolledCourses : UserControl
    {
        private DataTable _dtCources;
        private int _StudentID;

        public ctrlStudentEnrolledCourses()
        {
            InitializeComponent();
        }

        public void LoadStudentEnrolledCourses(int StudentID)
        {
            this._StudentID = StudentID;
            _dtCources = clsCourse.GetAllCourses(_StudentID);
            dgvCourses.DataSource = _dtCources;
            lbTotalRecords.Text = dgvCourses.Rows.Count.ToString();

            if(dgvCourses.Rows.Count > 0)
            {
                dgvCourses.Columns[0].HeaderText = "Student ID";
                dgvCourses.Columns[0].Width = 100;

                dgvCourses.Columns[1].HeaderText = "Student Name";
                dgvCourses.Columns[1].Width = 250;

                dgvCourses.Columns[2].HeaderText = "Course Name";
                dgvCourses.Columns[2].Width = 200;

                dgvCourses.Columns[3].HeaderText = "Teacher ID";
                dgvCourses.Columns[3].Width = 100;

                dgvCourses.Columns[4].HeaderText = "Subject Name";
                dgvCourses.Columns[4].Width = 200;
            }

        }
    }
}
