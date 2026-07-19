using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;
using TMS.People;
using TMS.Payments;

namespace TMS.Students
{
    public partial class frmListStudents : Form
    {
        private DataTable _dtStudents;
        public frmListStudents()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListStudents_Load(object sender, EventArgs e)
        {
            _dtStudents = clsStudent.GetAllStudents();
            dgvStudents.DataSource = _dtStudents;
            cbFilterBy.SelectedIndex = 0;

            lbTotalRecords.Text = dgvStudents.Rows.Count.ToString();

            if(dgvStudents.Rows.Count > 0)
            {
                dgvStudents.Columns[0].HeaderText = "Student ID";
                dgvStudents.Columns[0].Width = 100;

                dgvStudents.Columns[1].HeaderText = "PersonID ID";
                dgvStudents.Columns[1].Width = 100;

                dgvStudents.Columns[2].HeaderText = "National No";
                dgvStudents.Columns[2].Width = 100;

                dgvStudents.Columns[3].HeaderText = "Full Name";
                dgvStudents.Columns[3].Width = 300;

                dgvStudents.Columns[4].HeaderText = "Created by";
                dgvStudents.Columns[4].Width = 100;

                dgvStudents.Columns[5].HeaderText = "Enrollment Date";
                dgvStudents.Columns[5].Width = 170;
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Student ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if(txtFilterValue.Visible)
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
                case "Student ID":
                    FilterColumn = "StudentID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Created By":
                    FilterColumn = "CreatedBy";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtStudents.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvStudents.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "StudentID" || FilterColumn == "PersonID")
                _dtStudents.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtStudents.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvStudents.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmStudentDetails((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditStudent();
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditStudent();
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditStudent((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListStudents_Load(null, null);
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int StudentID = (int)dgvStudents.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete Student with ID = " + StudentID + " ?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsStudent.DeleteStudent(StudentID))
            {
                MessageBox.Show($"Student with ID {StudentID} has been deleted successfully!", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmListStudents_Load(null, null);
            }
            else
                MessageBox.Show("Cannot delete student due to he has data linked to him", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet");
        }

        private void callPhoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet");
        }

        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmStudentDetails((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void paymentsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmStudentPaymentsList((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void enrolledCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmStudentEnrolledCourses((int)dgvStudents.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
