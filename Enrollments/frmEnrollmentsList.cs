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

namespace TMS.Enrollments
{
    public partial class frmEnrollmentsList : Form
    {
        private DataTable _dtEnrollments;

        public frmEnrollmentsList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmEnrollmentsList_Load(object sender, EventArgs e)
        {
            _dtEnrollments = clsEnrollment.GetAllEnrollments();
            dgvEnrollments.DataSource = _dtEnrollments;
            lbTotalRecords.Text = dgvEnrollments.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvEnrollments.Rows.Count > 0)
            {
                dgvEnrollments.Columns[0].HeaderText = "Enrollment ID";
                dgvEnrollments.Columns[0].Width = 100;

                dgvEnrollments.Columns[1].HeaderText = "Class ID";
                dgvEnrollments.Columns[1].Width = 120;

                dgvEnrollments.Columns[2].HeaderText = "Full Name";
                dgvEnrollments.Columns[2].Width = 300;

                dgvEnrollments.Columns[3].HeaderText = "Enrollment Date";
                dgvEnrollments.Columns[3].Width = 150;
            }
            
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            Dictionary<string,string> MappingColumnName = new Dictionary<string,string>();
            MappingColumnName.Add("Enrollment ID", "EnrollmentID");
            MappingColumnName.Add("Class ID", "ClassID");
            MappingColumnName.Add("Full Name", "FullName");

            if(cbFilterBy.Text == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtEnrollments.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvEnrollments.Rows.Count.ToString();
                return;
            }

            string FilterColumn = MappingColumnName[cbFilterBy.Text];

            if (FilterColumn == "EnrollmentID" || FilterColumn == "ClassID")
                _dtEnrollments.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtEnrollments.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);
        }

        private void btnAddSEnrollment_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEnrollment();
            frm.ShowDialog();

            frmEnrollmentsList_Load(null, null);
        }

        private void editEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditEnrollment((int)dgvEnrollments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmEnrollmentsList_Load(null, null);
        }

        private void deleteEnrollmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int EnrollmentID = (int)dgvEnrollments.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are you sure you want to delete Enrollment with ID = {EnrollmentID.ToString()}",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if(clsEnrollment.DeleteEnrollment(EnrollmentID))
            {
                MessageBox.Show($"Enrollment with ID = {EnrollmentID.ToString()} has been deleted successfully",
                    "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmEnrollmentsList_Load(null, null);
            }
            else
                MessageBox.Show($"Could not delete enrollment due to it has data linked to it",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showEnrollmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmEnrollmentDetails((int)dgvEnrollments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvEnrollments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showEnrollmentDetailsToolStripMenuItem_Click(null, null);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Enrollment ID" || cbFilterBy.Text == "Class ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
    }
}
