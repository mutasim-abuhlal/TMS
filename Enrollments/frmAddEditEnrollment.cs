using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Courses;
using TMS.Global_Classes;
using TMS_Business;

namespace TMS.Enrollments
{
    public partial class frmAddEditEnrollment : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        private readonly string _ServiceName = "Enroll in course";

        private int _EnrollmentID;
        private clsEnrollment _Enrollment;
        private clsPayment _Payment;
        public frmAddEditEnrollment()
        {
            InitializeComponent();

            _EnrollmentID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditEnrollment(int EnrollmentID)
        {
            InitializeComponent();

            _EnrollmentID = EnrollmentID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _FillPaymentMethodsInComboBox()
        {
            foreach(DataRow row in clsPaymentMethod.GetAllPaymentMethods().Rows)
            {
                cbPaymentMethod.Items.Add(row["MethodName"]);
            }
        }

        private void frmAddEditEnrollment_Load(object sender, EventArgs e)
        {
            _FillPaymentMethodsInComboBox();
            cbPaymentMethod.SelectedIndex = 0;

            tabControl1.SelectedIndex = 0;
            lbCreatedBy.Text = clsGlobal.User.UserName;
            lbEnrollDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            lbTotalFees.Text = clsService.Find(_ServiceName).ServiceFees.ToString();

            if(_Mode == enMode.Update)
            {
                lbTitle.Text = "Update Enrollment";
                _Enrollment = clsEnrollment.Find(_EnrollmentID);
               

                if (_Enrollment == null)
                {
                    MessageBox.Show("Could not find Enrollment with ID = " + _EnrollmentID.ToString(),
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _Payment = clsPayment.FindByEnrollmentID(_EnrollmentID);
                if (_Payment == null)
                {
                    MessageBox.Show("Could not find Payment with Enrollment ID = " + _EnrollmentID.ToString(),
                        "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //incase enrollment was found

                ctrlClassCardWithFilter1.FilterEnabled = false;
                ctrlStudentCardWithFilter1.FilterEnabled = false;
                ctrlClassCardWithFilter1.LoadClassInfo(_Enrollment.ClassID);
                ctrlStudentCardWithFilter1.LoadStudentInfo(_Enrollment.StudentID);

                lbEnrollmentID.Text = _Enrollment.EnrollmentID.ToString();
                lbCreatedBy.Text = _Enrollment.UserInfo.UserName;
                lbEnrollDate.Text = _Enrollment.EnrollDate.ToString("dd/MMM/yyyy");
                txtNotes.Text = _Enrollment.Notes;

                //load payment data
                cbPaymentMethod.SelectedIndex = cbPaymentMethod.FindString(_Payment.PaymentMethodInfo.MethodName);
            }
            else
            {
                ctrlStudentCardWithFilter1.FilterFoucs();
                lbTitle.Text = "Add New Enrollment";
                _Enrollment = new clsEnrollment();
                _Payment = new clsPayment();
            }
        }

        private void btnStudentNext_Click(object sender, EventArgs e)
        {
            if(ctrlStudentCardWithFilter1.SelectedStudent == null)
            {
                MessageBox.Show("Please select a student", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpClassInfo"];
            ctrlClassCardWithFilter1.FilterFoucs();
        }

        private void lbCourseNext_Click(object sender, EventArgs e)
        {
            if (ctrlClassCardWithFilter1.SelectedClass == null)
            {
                MessageBox.Show("Please select an class", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(ctrlClassCardWithFilter1.SelectedClass.NumberOfStudents ==
                ctrlClassCardWithFilter1.SelectedClass.ClassroomInfo.MaxNumberOfStudents)
            {
                MessageBox.Show("Cannot add more enrollments because\nthe classroom is already full.", 
                    "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tabControl1.SelectedTab = tabControl1.TabPages["tpEnrollmentInfo"];
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                if(clsStudent.IsStudentEnrolledInThisCourseBefore(_Enrollment.StudentID,_Enrollment.ClassID))
                {
                    MessageBox.Show("this student has been enrolled in this course before.\nPlease select another one",
                        "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

                _Enrollment.EnrollDate = DateTime.Now;
                _Enrollment.CreatedByUserID = clsGlobal.User.UserID;

                _Payment.CreatedByUserID = clsGlobal.User.UserID;
                _Payment.PaymentDate = _Enrollment.EnrollDate;
            }

            _Enrollment.ClassID = ctrlClassCardWithFilter1.ClassID;
            _Enrollment.StudentID = ctrlStudentCardWithFilter1.StudentID;
            _Enrollment.Notes = txtNotes.Text;

            _Payment.ServiceID = clsService.Find(_ServiceName).ServiceID;
            _Payment.PaymentMethodID = clsPaymentMethod.Find(cbPaymentMethod.Text).MethodID;

            if (_Enrollment.Save())
            {
                _EnrollmentID = _Enrollment.EnrollmentID;
                _Payment.EnrollmentID = _Enrollment.EnrollmentID;

                if(_Payment.Save())
                {
                    lbEnrollmentID.Text = _EnrollmentID.ToString();
                    lbTitle.Text = "Update Enrollment";
                    MessageBox.Show("Data Saved Successfully", "Confirm!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Data did not saved","Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Data did not saved", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ctrlStudentCardWithFilter1_OnStudentSelected(int StudentID)
        {
            _Enrollment.StudentID = StudentID;
        }

        private void ctrlClassCardWithFilter1_OnCourseSelected(int ClassID)
        {
            _Enrollment.ClassID = ClassID;
        }
    }
}
