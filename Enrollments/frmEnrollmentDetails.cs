using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMS.Enrollments
{
    public partial class frmEnrollmentDetails : Form
    {
        private int _EnrollmentID;

        public frmEnrollmentDetails(int EnrollmentID)
        {
            InitializeComponent();

            this._EnrollmentID = EnrollmentID;
        }

        private void frmEnrollmentDetails_Load(object sender, EventArgs e)
        {
            ctrlEnrollmentCard1.LoadEnrollmentInfo(_EnrollmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
