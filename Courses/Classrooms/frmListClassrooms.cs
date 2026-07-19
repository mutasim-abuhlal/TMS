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

namespace TMS.Courses.Classrooms
{
    public partial class frmListClassrooms : Form
    {
        private DataTable _dtClassrooms;

        public frmListClassrooms()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListClassrooms_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            this._dtClassrooms = clsClassroom.GetAllClassrooms();
            dgvClassrooms.DataSource = _dtClassrooms;
            lbTotalRecords.Text = dgvClassrooms.Rows.Count.ToString();

            if(dgvClassrooms.Rows.Count > 0 )
            {
                dgvClassrooms.Columns[0].HeaderText = "Classroom ID";
                dgvClassrooms.Columns[0].Width = 100;

                dgvClassrooms.Columns[1].HeaderText = "Max number of students";
                dgvClassrooms.Columns[1].Width = 300;
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Classroom ID":
                    FilterColumn = "ClassroomID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text == "")
            {
                _dtClassrooms.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvClassrooms.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "ClassroomID")
                _dtClassrooms.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtClassrooms.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvClassrooms.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Classroom ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
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
