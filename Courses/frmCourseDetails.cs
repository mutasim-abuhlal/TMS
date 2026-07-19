using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Courses
{
    public partial class frmCourseDetails : Form
    {
        private int _CourseID;

        public frmCourseDetails(int courseID)
        {
            InitializeComponent();
            _CourseID = courseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCourseDetails_Load(object sender, EventArgs e)
        {
            ctrlCourseCard1.LoadCourse(_CourseID);
        }
    }
}
