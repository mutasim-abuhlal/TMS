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
using TMS.Courses.Classes;

namespace TMS.Courses
{
    public partial class frmListCourses : Form
    {
        private DataTable _dtCourses;

        public frmListCourses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListCourses_Load(object sender, EventArgs e)
        {
            _dtCourses = clsCourse.GetAllCourses();
            dgvCourses.DataSource = _dtCourses;
            cbFilterBy.SelectedIndex = 0;

            lbTotalRecords.Text = dgvCourses.Rows.Count.ToString();

            if(dgvCourses.Rows.Count > 0 )
            {
                dgvCourses.Columns[0].HeaderText = "Course ID";
                dgvCourses.Columns[0].Width = 100;

                dgvCourses.Columns[1].HeaderText = "Course Name";
                dgvCourses.Columns[1].Width = 300;

                dgvCourses.Columns[2].HeaderText = "Teacher ID";
                dgvCourses.Columns[2].Width = 100;

                dgvCourses.Columns[3].HeaderText = "Subject Name";
                dgvCourses.Columns[3].Width = 200;

                dgvCourses.Columns[4].HeaderText = "Start Date";
                dgvCourses.Columns[4].Width = 160;

                dgvCourses.Columns[5].HeaderText = "End Date";
                dgvCourses.Columns[5].Width = 160;
            }

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if(txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
                txtFilterValue.Text = "";
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Course ID" || cbFilterBy.Text == "TeacherID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Course ID":
                    FilterColumn = "ClassID";
                    break;
                case "Course Name":
                    FilterColumn = "CourseName";
                    break;
                case "Teacher ID":
                    FilterColumn = "TeacherID";
                    break;
                case "Subject Name":
                    FilterColumn = "SubjectName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtCourses.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvCourses.Rows.Count.ToString();

                return;
            }

            if (FilterColumn == "ClassID" || FilterColumn == "TeacherID")
                _dtCourses.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtCourses.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvCourses.Rows.Count.ToString();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditCourse();
            frm.ShowDialog();

            frmListCourses_Load(null, null);
        }

        private void editCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditCourse((int)dgvCourses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListCourses_Load(null, null);
        }

        private void addNewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddCourse.PerformClick();
        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CourseID = (int)dgvCourses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are you sure you want to delete course with ID = {CourseID}", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsCourse.DeleteCourse(CourseID))
            {
                MessageBox.Show("Course has been Deleted Succesffully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmListCourses_Load(null, null);
            }
            else
                MessageBox.Show($"Cannot delete course with ID = {CourseID} due to \nit has data linked to it",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showCourseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmCourseDetails((int)dgvCourses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();        
        }

        private void dgvCourses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showCourseDetailsToolStripMenuItem_Click(null, null);
        }

        private void setClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListClasses((int)dgvCourses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
