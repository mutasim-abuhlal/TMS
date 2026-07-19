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
using TMS;
using TMS.People;

namespace TMS.Users
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
            cbFilterBy.SelectedIndex = 0;

            lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();

            if(dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 100;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 160;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 100;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Is Active");
            cbIsActive.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text == "Is Active");

            if(txtFilterValue.Visible)
            {
                this.ActiveControl = txtFilterValue;
                txtFilterValue.Text = "";
            }

            if(cbIsActive.Visible)
            {
                this.ActiveControl = cbIsActive;
                cbIsActive.SelectedIndex = 0;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "UserID" || FilterColumn == "PersonID")
                _dtUsers.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtUsers.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbIsActive.Text == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if(cbIsActive.Text == "Yes")
                _dtUsers.DefaultView.RowFilter = string.Format("{0} = {1}", "IsActive", true);
            else
                _dtUsers.DefaultView.RowFilter = string.Format("{0} = {1}", "IsActive", false);

            lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmPersonDetails((int)dgvUsers.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void showUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete User with ID = " + UserID.ToString(), "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (clsUser.DeleteUser(UserID))
                MessageBox.Show("User has been deleted Successfully", "Confirm!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature isn't implemented yet");
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddEditUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form frm = new frmUserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnLogsList_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsersLogs();
            frm.ShowDialog();
        }
    }
}
