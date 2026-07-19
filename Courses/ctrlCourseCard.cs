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

namespace TMS.Courses
{
    public partial class ctrlCourseCard : UserControl
    {
        private int _CourseID;
        private clsCourse _Course;

        public int CourseID { get { return _CourseID; } }
        public clsCourse SelectedCourse { get { return _Course; } }

        public ctrlCourseCard()
        {
            InitializeComponent();
        }

        public void LoadCourse(int CourseID)
        {
            _CourseID = CourseID;
            _Course = clsCourse.Find(_CourseID);

            if(_Course == null)
            {
                MessageBox.Show("Could not find course with ID = " + CourseID.ToString(),"Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //incase Course was found
            lbCourseID.Text = _CourseID.ToString();
            lbTeacherName.Text = _Course.TeacherInfo.PersonInfo.FullName;
            lbTeacherID.Text = _Course.TeacherID.ToString();
            lbMajor.Text = _Course.TeacherInfo.MajorInfo.MajorName;
            lbStartDate.Text = _Course.StartDate.ToString("dd/MMM/yyyy");
            lbEndDate.Text = _Course.EndDate.ToString("dd/MMM/yyyy");
            lbCreatedBy.Text = _Course.UserInfo.UserName;
            lbSubject.Text = _Course.SubjectInfo.SubjectName;
        }
        
    }
}
