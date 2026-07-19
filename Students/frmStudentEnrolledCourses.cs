using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Students
{
    public partial class frmStudentEnrolledCourses : Form
    {
        private int _StudentID;

        public frmStudentEnrolledCourses(int StudentID)
        {
            InitializeComponent();

            this._StudentID = StudentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentEnrolledCourses_Load(object sender, EventArgs e)
        {
            ctrlStudentCard1.LoadStudentInfo(_StudentID);
            ctrlStudentEnrolledCourses1.LoadStudentEnrolledCourses(_StudentID);
        }
    }
}
