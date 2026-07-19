using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS_Business;

namespace TMS.Courses.Classes.ClassAppointments
{
    public partial class frmAppointmentsList : Form
    {
        private int _ClassID;
        private DataTable _dtAppointments;

        public frmAppointmentsList(int ClassID)
        {
            InitializeComponent();
            _ClassID = ClassID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAppointmentsList_Load(object sender, EventArgs e)
        {
            ctrlClassCard1.LoadClassInfo(_ClassID);

            _dtAppointments = clsClassAppointment.GetAllAppointmentsForOneClass(_ClassID);
            dgvAppointments.DataSource = _dtAppointments;
            this.lbTotalRecords.Text = dgvAppointments.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvAppointments.Rows.Count > 0)
            {
                dgvAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvAppointments.Columns[0].Width = 120;

                dgvAppointments.Columns[1].HeaderText = "Day";
                dgvAppointments.Columns[1].Width = 120;

                dgvAppointments.Columns[2].HeaderText = "Start At";
                dgvAppointments.Columns[2].Width = 160;

                dgvAppointments.Columns[3].HeaderText = "End At";
                dgvAppointments.Columns[3].Width = 160;

                dgvAppointments.Columns[4].HeaderText = "Creation Date";
                dgvAppointments.Columns[4].Width = 160;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Day");
            cbDays.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text == "Day");

            if(txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            if(cbDays.Visible)
            {
                cbDays.SelectedIndex = 0;
                cbDays.Focus();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "AppointmentID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDays.Text == "All")
            {
                _dtAppointments.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvAppointments.Rows.Count.ToString();
                return;
            }

            //if cbDays.Text does not equal All we will filter accroding to selected day

            _dtAppointments.DefaultView.RowFilter
                = string.Format("{0} LIKE '{1}%'", dgvAppointments.Columns[1], cbDays.Text);
            lbTotalRecords.Text = dgvAppointments.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Appointment ID":
                    FilterColumn = "AppointmentID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtAppointments.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvAppointments.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "AppointmentID")
                _dtAppointments.DefaultView.RowFilter = 
                    string.Format("{0} = {1}",FilterColumn,txtFilterValue.Text);
            else
                _dtAppointments.DefaultView.RowFilter = 
                    string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);


            lbTotalRecords.Text = dgvAppointments.Rows.Count.ToString();

        }

        private void btnAddSession_Click(object sender, EventArgs e)
        {
            if(dgvAppointments.Rows.Count > 3)
            {
                MessageBox.Show("Cannot create more than 3 appointments for each Session.", "Not Allowed!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frm = new frmAddEditAppointment(_ClassID);
            frm.ShowDialog();

            frmAppointmentsList_Load(null, null);
        }

        private void addNewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddSession_Click(null, null);
        }

        private void editAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditAppointment(_ClassID, 
                           (int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmAppointmentsList_Load(null, null);
        }

        private void deleteAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Are you sure you want to delete appointment with ID = {AppointmentID}",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsClassAppointment.DeleteAppointment(AppointmentID))
            {
                MessageBox.Show($"Appointment with ID = {AppointmentID} has been deleted successfully",
                    "Confirm!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmAppointmentsList_Load(null, null);
            }
            else
                MessageBox.Show($"Cannot delete appointment with ID = {AppointmentID} due to\nit has data linked to it",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showAppointmentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAppointmentDetails((int)dgvAppointments.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvAppointments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            showAppointmentDetailsToolStripMenuItem_Click(null, null);
        }
    }
}
