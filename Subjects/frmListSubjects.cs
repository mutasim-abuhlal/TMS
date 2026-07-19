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

namespace TMS.Subjects
{
    public partial class frmListSubjects : Form
    {
        private DataTable _dtSubjects;

        public frmListSubjects()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListSubjects_Load(object sender, EventArgs e)
        {
            this._dtSubjects = clsSubject.GetAllSubjects();
            dgvSubjects.DataSource = _dtSubjects;
            lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();

            if(dgvSubjects.Rows.Count > 0 )
            {
                dgvSubjects.Columns[0].HeaderText = "Subject ID";
                dgvSubjects.Columns[0].Width = 100;

                dgvSubjects.Columns[1].HeaderText = "Subject Name";
                dgvSubjects.Columns[1].Width = 200;

                dgvSubjects.Columns[2].HeaderText = "Subject Description";
                dgvSubjects.Columns[2].Width = 350;
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
                case "Subject ID":
                    FilterColumn = "SubjectID";
                    break;
                case "Subject Name":
                    FilterColumn = "SubjectName";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text == "")
            {
                _dtSubjects.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "SubjectID")
                _dtSubjects.DefaultView.RowFilter = string.Format("{0} = {1}", FilterColumn, txtFilterValue.Text);
            else
                _dtSubjects.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", FilterColumn, txtFilterValue.Text);

            lbTotalRecords.Text = dgvSubjects.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Subject ID")
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
    }
}
