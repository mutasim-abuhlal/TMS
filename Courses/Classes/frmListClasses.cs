using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;

namespace TMS.Courses.Classes
{
    public partial class frmListClasses : Form
    {
        private DataTable _dtClasses;
        private int _CourseID;
        public frmListClasses(int CourseID)
        {
            InitializeComponent();
            _CourseID = CourseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListClasses_Load(object sender, EventArgs e)
        {
            ctrlCourseCard1.LoadCourse(_CourseID);
            _dtClasses = clsClass.GetAllClasses(_CourseID);
            dgvClasses.DataSource = _dtClasses;
            lbTotalRecords.Text = dgvClasses.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvClasses.Rows.Count > 0)
            {
                dgvClasses.Columns[0].HeaderText = "Class ID";
                dgvClasses.Columns[0].Width = 100;

                dgvClasses.Columns[1].HeaderText = "Classroom ID";
                dgvClasses.Columns[1].Width = 100;

                dgvClasses.Columns[2].HeaderText = "Course Name";
                dgvClasses.Columns[2].Width = 200;

                dgvClasses.Columns[3].HeaderText = "Teacher Name";
                dgvClasses.Columns[3].Width = 300;

                dgvClasses.Columns[4].HeaderText = "Number Of Students";
                dgvClasses.Columns[4].Width = 200;
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Class ID" || cbFilterBy.Text == "Classroom ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Class ID":
                    FilterColumn = "ClassID";
                    break;
                case "Classroom ID":
                    FilterColumn = "ClassroomID";
                    break;
                case "Course Name":
                    FilterColumn = "CourseName";
                    break;
                case "Teacher Name":
                    FilterColumn = "TeacherName";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtClasses.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvClasses.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "ClassID" || FilterColumn == "ClassroomID")
                _dtClasses.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtClasses.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbTotalRecords.Text = dgvClasses.Rows.Count.ToString();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if(dgvClasses.Rows.Count == 3)
            {
                MessageBox.Show($"Cannot add more than {dgvClasses.Rows.Count} Classes for each course.\nContact admin for more details", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                    
            }

            Form frm = new frmAddEditClass(_CourseID);
            frm.ShowDialog();

            frmListClasses_Load(null, null);
        }

        private void editClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditClass(_CourseID, (int)dgvClasses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListClasses_Load(null, null);
        }

        private void deleteClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ClassID = (int)dgvClasses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete an Class with ID = " + ClassID.ToString(),
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsClass.DeleteClass(ClassID))
            {
                MessageBox.Show($"Class with ID = {ClassID} has been deleted successfully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListClasses_Load(null, null);
            }
            else
                MessageBox.Show("Cannot delete an Class due to it has data linked to it", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showClassDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmClassDetails((int)dgvClasses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void setAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new TMS.Courses.Classes.ClassAppointments.
                frmAppointmentsList((int)dgvClasses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddClass_Click(null, null);
        }
    }
}
