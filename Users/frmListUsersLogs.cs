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

namespace TMS.Users
{
    public partial class frmListUsersLogs : Form
    {
        private DataTable _dtLogs;

        public frmListUsersLogs()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListUsersLogs_Load(object sender, EventArgs e)
        {
            _dtLogs = clsUser.GetAllUsersLogs();
            dgvLogs.DataSource = _dtLogs;
            cbFilterBy.SelectedIndex = 0;

            lbTotalRecords.Text = dgvLogs.Rows.Count.ToString();

            if(dgvLogs.Rows.Count > 0 )
            {
                dgvLogs.Columns[0].HeaderText = "Log ID";
                dgvLogs.Columns[0].Width = 100;

                dgvLogs.Columns[1].HeaderText = "Full Name";
                dgvLogs.Columns[1].Width = 300;

                dgvLogs.Columns[2].HeaderText = "User Name";
                dgvLogs.Columns[2].Width = 170;

                dgvLogs.Columns[3].HeaderText = "Log Action";
                dgvLogs.Columns[3].Width = 130;
               
                dgvLogs.Columns[4].HeaderText = "Log Date";
                dgvLogs.Columns[4].Width = 130;
            }

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Log ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text != "Log Action");
            cbLogAction.Visible = (cbFilterBy.Text != "None" && cbFilterBy.Text == "Log Action");

            if(txtFilterValue.Visible)
            {
                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }

            if(cbLogAction.Visible)
            {
                cbLogAction.SelectedIndex = 0;
                cbLogAction.Focus();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Log ID":
                    FilterColumn = "LogID";
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

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtLogs.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvLogs.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LogID")
                _dtLogs.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _dtLogs.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbTotalRecords.Text = dgvLogs.Rows.Count.ToString();
        }

        private void cbLogAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLogAction.Text == "All")
            {
                _dtLogs.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvLogs.Rows.Count.ToString();
                return;
            }

            if (cbLogAction.Text == "Login")
                _dtLogs.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "LogAction", "Login");
            else
                _dtLogs.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", "LogAction", "Logout");

            lbTotalRecords.Text = dgvLogs.Rows.Count.ToString();
        }
    }
}
