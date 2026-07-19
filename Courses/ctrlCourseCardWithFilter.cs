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
    public partial class ctrlCourseCardWithFilter : UserControl
    {
        public int CourseID { get { return ctrlCourseCard1.CourseID; } }
        public clsCourse SelectedCourse { get { return ctrlCourseCard1.SelectedCourse; } }

        public bool FilterEnabled { get { return groupBox1.Enabled; } set {  groupBox1.Enabled = value; } }

        public void FilterFocus()
        {
            this.ActiveControl = txtFilterValue;
        }

        public delegate void CourseSelected(int CourseID);
        public event CourseSelected OnCourseSelected;

        public ctrlCourseCardWithFilter()
        {
            InitializeComponent();
        }

        private void FindNow()
        {
            int CourseID = Convert.ToInt32(txtFilterValue.Text.Trim());
            ctrlCourseCard1.LoadCourse(CourseID);

            if (OnCourseSelected != null)
                OnCourseSelected?.Invoke(CourseID);
        }

        public void LoadCourseInfo(int CourseID)
        {
            txtFilterValue.Text = CourseID.ToString();
            ctrlCourseCard1.LoadCourse(CourseID);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();

          
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
                if (!string.IsNullOrEmpty(txtFilterValue.Text))
                    FindNow();

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
