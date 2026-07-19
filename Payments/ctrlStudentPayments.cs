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

namespace TMS.Payments
{
    public partial class ctrlStudentPayments : UserControl
    {
        private DataTable _dtPayments;
        private int _StudentID;

        public ctrlStudentPayments()
        {
            InitializeComponent();
        }

        public void LoadStudentPayments(int StudentID)
        {
            _StudentID = StudentID;
            _dtPayments = clsPayment.GetAllPaymentsPerStudent(_StudentID);
            dgvPayments.DataSource = _dtPayments;
            lbTotalRecords.Text = dgvPayments.Rows.Count.ToString();

            if(dgvPayments.Rows.Count > 0 )
            {
                dgvPayments.Columns[0].HeaderText = "Payment ID";
                dgvPayments.Columns[0].Width = 100;

                dgvPayments.Columns[1].HeaderText = "Enrollment ID";
                dgvPayments.Columns[1].Width = 100;

                dgvPayments.Columns[2].HeaderText = "Payment Method";
                dgvPayments.Columns[2].Width = 100;

                dgvPayments.Columns[3].HeaderText = "Service Name";
                dgvPayments.Columns[3].Width = 170;

                dgvPayments.Columns[4].HeaderText = "Payment Date";
                dgvPayments.Columns[4].Width = 170;
            }
        }
    }
}
