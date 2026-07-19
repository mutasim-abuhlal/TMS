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

namespace TMS.Majors
{
    public partial class frmListMajors : Form
    {
        private DataTable _dtMajors;

        public frmListMajors()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListMajors_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            this._dtMajors = clsMajor.GetAllMajors();
            dgvSubjects.DataSource = _dtMajors;
            lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();

            if(dgvSubjects.Rows.Count > 0)
            {
                dgvSubjects.Columns[0].HeaderText = "Major ID";
                dgvSubjects.Columns[0].Width = 100;

                dgvSubjects.Columns[1].HeaderText = "Major Name";
                dgvSubjects.Columns[1].Width = 250;
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Major ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Major ID":
                    FilterColumn = "MajorID";
                    break;
                case "Major Name":
                    FilterColumn = "MajorName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text == "")
            {
                _dtMajors.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "MajorID")
                _dtMajors.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtMajors.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();
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
    }
}
