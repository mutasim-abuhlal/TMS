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

namespace TMS.Teachers
{
    public partial class frmListTeachers : Form
    {
        private DataTable _dtTeachers;

        public frmListTeachers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTeachers_Load(object sender, EventArgs e)
        {
            _dtTeachers = clsTeacher.GetAllTeachers();
            dgvTeachers.DataSource = _dtTeachers;
            lbTotalRecords.Text = dgvTeachers.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvTeachers.Rows.Count > 0 )
            {
                dgvTeachers.Columns[0].HeaderText = "Teacher ID";
                dgvTeachers.Columns[0].Width = 100;

                dgvTeachers.Columns[1].HeaderText = "Major";
                dgvTeachers.Columns[1].Width = 190;

                dgvTeachers.Columns[2].HeaderText = "National No";
                dgvTeachers.Columns[2].Width = 130;

                dgvTeachers.Columns[3].HeaderText = "Full Name";
                dgvTeachers.Columns[3].Width = 300;

                dgvTeachers.Columns[4].HeaderText = "Enroll Date";
                dgvTeachers.Columns[4].Width = 190;
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Teacher ID")
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
                case "Teacher ID":
                    FilterColumn = "TeacherID";
                    break;
                case "Major":
                    FilterColumn = "MajorName";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtTeachers.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvTeachers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "TeacherID")
                _dtTeachers.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtTeachers.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbTotalRecords.Text = dgvTeachers.Rows.Count.ToString();
        }

        private void btnAddNewTeacher_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditTeacher();
            frm.ShowDialog();

            frmListTeachers_Load(null, null);
        }

        private void addNewTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewTeacher_Click(null, null);
        }

        private void editTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditTeacher((int)dgvTeachers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListTeachers_Load(null, null);
        }

        private void deleteTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TeacherID = (int)dgvTeachers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete teacher with ID = " + TeacherID.ToString(), "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsTeacher.DeleteTeacher(TeacherID))
            {
                MessageBox.Show($"Teacher with ID = {TeacherID} has been deleted successfully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmListTeachers_Load(null, null);
            }
            else
                MessageBox.Show("Cannot delete teacher due to he has data linked with him.", "Not Allowed",
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

        private void showTeacherDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmTeacherDetails((int)dgvTeachers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvTeachers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showTeacherDetailsToolStripMenuItem_Click(null, null);
        }
    }
}
