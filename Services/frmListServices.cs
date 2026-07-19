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

namespace TMS.Services
{
    public partial class frmListServices : Form
    {
        private DataTable _dtServices;

        public frmListServices()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListServices_Load(object sender, EventArgs e)
        {
            _dtServices = clsService.GetAllServices();
            dgvServices.DataSource = _dtServices;
            lbTotalRecords.Text = dgvServices.Rows.Count.ToString();

            if(dgvServices.Rows.Count > 0)
            {
                dgvServices.Columns[0].HeaderText = "Service ID";
                dgvServices.Columns[0].Width = 100;

                dgvServices.Columns[1].HeaderText = "Service Name";
                dgvServices.Columns[1].Width = 200;

                dgvServices.Columns[2].HeaderText = "Service Description";
                dgvServices.Columns[2].Width = 400;

                dgvServices.Columns[3].HeaderText = "Service Fees";
                dgvServices.Columns[3].Width = 150;
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Service ID":
                    FilterColumn = "ServiceID";
                    break;
                case "Service Name":
                    FilterColumn = "ServiceName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text == "")
            {
                _dtServices.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvServices.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "ServiceID")
                _dtServices.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtServices.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvServices.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Service ID")
                e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar));
        }
    }
}
