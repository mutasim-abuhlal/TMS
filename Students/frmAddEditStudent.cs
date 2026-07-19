using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMS.Global_Classes;
using TMS_Business;

namespace TMS.Students
{
    public partial class frmAddEditStudent : Form
    {
        private enum enMode { AddNew,Update};
        private enMode _Mode;

        private int _StudentID;
        private clsStudent _Student;

        public frmAddEditStudent()
        {
            InitializeComponent();

            _StudentID = -1;
            _Mode = enMode.AddNew;
        }

        public frmAddEditStudent(int StudentID)
        {
            InitializeComponent();

            _StudentID = StudentID;
            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {
            ctrlFindPerson1.FilterFoucs();
            lbCreatedBy.Text = clsGlobal.User.UserName;
            lbEnrollmentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if(_Mode == enMode.Update)
            {
                lbTitle.Text = "Update Student";
                _Student = clsStudent.FindStudentByStudentID(_StudentID);

                if(_Student == null)
                {
                    MessageBox.Show("Could not find Student with ID = " + _StudentID.ToString(),"Not Found",
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    tpStudentInfo.Enabled = false;
                    return;
                }

                //incase Student was found
                ctrlFindPerson1.FilterEnabled = false;
                ctrlFindPerson1.LoadPersonInfo(_Student.PersonID);
                lbStudentID.Text = _StudentID.ToString();
                txtNotes.Text = _Student.Notes;

                btnSave.Enabled = true;
                tpStudentInfo.Enabled = true;
            }
            else
            {
                lbTitle.Text = "Add New Student";
                _Student = new clsStudent();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.AddNew)
            {
                if(ctrlFindPerson1.SelectedPerson == null)
                {
                    MessageBox.Show("you have to select a person!", "Confirm!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  
                }
            }

            btnSave.Enabled = true;
            tpStudentInfo.Enabled = true;

            tabControl1.SelectedTab = tabControl1.TabPages["tpStudentInfo"];
            txtNotes.Focus();
        }

        private void ctrlFindPerson1_OnSelectPerson(int PersonID)
        {
            if(clsStudent.IsStudentExistByPersonID(PersonID))
            {
                MessageBox.Show("Selected Person with ID = " + PersonID.ToString() +
                     " is already a Student.\nSelect another person","Not Allowed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNext.Enabled = false;
                return;
            }

            if (clsTeacher.IsTeacherExistByPersonID(PersonID))
            {
                MessageBox.Show("Selected Person with ID = " + PersonID.ToString() +
                    " is already a Teacher.\nSelect another person", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnNext.Enabled = false;
                return;
            }

            _Student.PersonID = PersonID;
            btnNext.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are some empty fields please fill them.", "Wraning",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                _Student.CreatedByUserID = clsGlobal.User.UserID;
                _Student.CreationDate = DateTime.Now;
            }

            _Student.Notes = txtNotes.Text.Trim();

            if(_Student.Save())
            {
                lbTitle.Text = "Update Student";
                _Mode = enMode.Update;
                _StudentID = _Student.StudentID;
                lbStudentID.Text = _Student.StudentID.ToString();
                MessageBox.Show("Data Saved Successfully!", "Confirm!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data did saved!", "Error!", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
        }
    }
}
