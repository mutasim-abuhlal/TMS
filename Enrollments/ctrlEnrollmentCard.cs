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

namespace TMS.Enrollments
{
    public partial class ctrlEnrollmentCard : UserControl
    {
        private int _EnrollmentID;
        private clsEnrollment _Enrollment;

        public ctrlEnrollmentCard()
        {
            InitializeComponent();
        }

        public void LoadEnrollmentInfo(int EnrollmentID)
        {
            this._EnrollmentID = EnrollmentID;
            this._Enrollment = clsEnrollment.Find(this._EnrollmentID);

            if(this._Enrollment == null)
            {
                MessageBox.Show("Could not find Enrollment with ID = " + this._EnrollmentID.ToString(),
                    "Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbEnrollmentID.Text = this._EnrollmentID.ToString();
            lbStudentName.Text = this._Enrollment.StudentInfo.PersonInfo.FullName;
            lbClassID.Text = this._Enrollment.ClassInfo.ClassID.ToString();
            lbTotalFees.Text = clsPayment.FindByEnrollmentID(_EnrollmentID).ServiceInfo.ServiceFees.ToString();
            lbCreatedBy.Text = _Enrollment.UserInfo.UserName;
            lbEnrollDate.Text = _Enrollment.EnrollDate.ToString("dd/MM/yyyy");
        }
    }
}
