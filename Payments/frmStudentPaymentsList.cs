using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Payments
{
    public partial class frmStudentPaymentsList : Form
    {
        private int _StudentID;
        public frmStudentPaymentsList(int StudentID)
        {
            InitializeComponent();

            this._StudentID = StudentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStudentPaymentsList_Load(object sender, EventArgs e)
        {
            ctrlStudentCard1.LoadStudentInfo(_StudentID);
            ctrlStudentPayments1.LoadStudentPayments(_StudentID);
        }
    }
}
